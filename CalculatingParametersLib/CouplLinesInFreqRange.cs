using System;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace CalculatingParametersLib
{
    public class CouplLinesInFreqRange
    {
        private double _fmin = 0;
        private double _fmax = 15;
        private int _nf = 500;

        private Vector<double> _fi;
        private Vector<double> _wi;
        private Matrix<double> _um;
        private Matrix<double> _im;
        private Vector<Complex> _electricalLengthForC;
        private Vector<Complex> _electricalLengthForP;
        private double _z1in;
        private double _z2in;
        private double _z1out;
        private double _z2out;
        private double _l = 0.01;
        private double _c = 0.2998;
        private double _zo;
        private readonly Complex _j = Complex.ImaginaryOne;
        public CouplLinesInFreqRange(Params currentParams)
        {
            _zo = Math.Sqrt(currentParams.Zp1 * currentParams.Zc2);
            var range = Vector<double>.Build.Dense(_nf, i => i);
            _fi = Vector<double>.Build.Dense(_nf, i => ((_fmax - _fmin) / (_nf - 1)) * (i+1) + _fmin);
            _wi = _fi.Multiply(2 * Math.PI);
            _um = Matrix<double>.Build.Dense(2, 2);
            _um[0, 0] = 1;
            _um[0, 1] = 1;
            _um[1, 0] = currentParams.Rc;
            _um[1, 1] = currentParams.Rp;

            _im = Matrix<double>.Build.Dense(2, 2);
            _im[0, 0] = Math.Pow(currentParams.Zc1,-1);
            _im[0, 1] = Math.Pow(currentParams.Zp1, -1);
            _im[1, 0] = -Math.Pow(currentParams.Zc1 * currentParams.Rp, -1);
            _im[1, 1] = -Math.Pow(currentParams.Zp1 * currentParams.Rc, -1);

            _electricalLengthForC = Vector<Complex>.Build.Dense(_nf, i => _j * _wi[i] * (Math.Sqrt(currentParams.Erc) / _c) * _l);
            _electricalLengthForP = Vector<Complex>.Build.Dense(_nf, i => _j * _wi[i] * (Math.Sqrt(currentParams.Erp) / _c) * _l);
            var erere = Matrix<Complex>.Build.Dense(2, _nf);
            for (int i = 0; i < _nf; i++)
            {
                erere[0, i] = _electricalLengthForC[i];
                erere[1, i] = _electricalLengthForP[i];
            }


            var re = new Complex[_nf][];
            for (int i = 0; i < _nf; i++)
            {
                re[i] = new Complex[2] { _electricalLengthForC[i], _electricalLengthForP[i]};
            }

            var tet = new Vector<Complex>[_nf];
            for (int i = 0; i < _nf; i++)
            {
                tet[i] = Vector<Complex>.Build.Dense(new[] { _electricalLengthForC[i], _electricalLengthForP[i] });
            }

            var coIntermediate = new Vector<Complex>[_nf];
            var co = new Vector<Complex>[_nf];
            for (int i = 0; i < _nf; i++)
            {
                var coIntermediate1 = Vector<Complex>.Build.Dense(2);
                var coIntermediate2 = Vector<Complex>.Build.Dense(2);
                coIntermediate[i]=tet[i];
                coIntermediate[i].PointwiseTanh(coIntermediate1);
                coIntermediate1.DivideByThis(1,coIntermediate2);
                co[i] = coIntermediate2;
            }

            var scIntermediate = new Vector<Complex>[_nf];
            var sc = new Vector<Complex>[_nf];
            for (int i = 0; i < _nf; i++)
            {
                var scIntermediate1 = Vector<Complex>.Build.Dense(2);
                var scIntermediate2 = Vector<Complex>.Build.Dense(2);
                scIntermediate[i] = tet[i];
                scIntermediate[i].PointwiseSinh(scIntermediate1);
                scIntermediate1.DivideByThis(1, scIntermediate2);
                sc[i] = scIntermediate2;
            }

            var diagCo = new Matrix<Complex>[_nf];
            for (int i = 0; i < _nf; i++)
            {
                diagCo[i] = Matrix<Complex>.Build.DenseOfDiagonalVector(co[i]);
            }

            var diagSc = new Matrix<Complex>[_nf];
            for (int i = 0; i < _nf; i++)
            {
                diagSc[i] = Matrix<Complex>.Build.DenseOfDiagonalVector(sc[i]);
            }

            //var testt = _um.Inverse();
            var yaa = new Matrix<Complex>[_nf];
            var imIntermediate = Matrix<Complex>.Build.Dense(2, 2);
            var umIntermediate = Matrix<Complex>.Build.Dense(2, 2);
            imIntermediate = _im.ToComplex();
            umIntermediate = _um.Inverse().ToComplex();
            var diagCoIntermediate = diagCo;
            for (int i = 0; i < _nf; i++)
            {
                yaa[i] = imIntermediate.Multiply(diagCoIntermediate[i]).Multiply(umIntermediate);
            }


            var yab = new Matrix<Complex>[_nf];
            var diagScIntermediate = diagSc;
            for (int i = 0; i < _nf; i++)
            {
                yab[i] = imIntermediate.Multiply(diagScIntermediate[i]).Multiply(umIntermediate);
            }

            var yaayab1 = new Matrix<Complex>[_nf];
            var yaayab2 = new Matrix<Complex>[_nf];
            var yo = new Matrix<Complex>[_nf];
            for (int i = 0; i < _nf; i++)
            {
                yaayab1[i] = yaa[i].Append(yab[i]);
                yaayab2[i] = yab[i].Append(yaa[i]);
                yo[i] = yaayab1[i].Stack(yaayab2[i]);
            }

            var E4 = Matrix<double>.Build.DenseIdentity(4);
            var Zl = Matrix<double>.Build.DenseIdentity(4);
            _z1in = 25;
            _z2in = 50;
            _z1out = 25;
            _z2out = 50;
            Zl[0, 0] = Math.Sqrt(_z1in);
            Zl[1, 1] = Math.Sqrt(_z2in);
            Zl[2, 2] = Math.Sqrt(_z1out);
            Zl[3, 3] = Math.Sqrt(_z2out);
            var ZlComplex = Zl.ToComplex();
            var E4Complex = E4.ToComplex();
            var Y = new Matrix<Complex>[_nf];
            for (int i = 0; i < _nf; i++)
            {
                Y[i] = ZlComplex.Multiply(yo[i]).Multiply(ZlComplex);
            }
            var SS = new Matrix<Complex>[_nf];
            for (int i = 0; i < _nf; i++)
            {
                SS[i] = 2 * (E4Complex + Y[i]).Inverse() - E4Complex;
            }

            var S11
            //var t11 = SS[1][0, 0];
            //var t12 = SS[1][0, 1];
            //var t13 = SS[1][0, 2];
            //var t14 = SS[1][0, 3];

            //var t21 = SS[1][1, 0];
            //var t22 = SS[1][1, 1];
            //var t23 = SS[1][1, 2];
            //var t24 = SS[1][1, 3];

            //var t31 = SS[1][2, 0];
            //var t32 = SS[1][2, 1];
            //var t33 = SS[1][2, 2];
            //var t34 = SS[1][2, 3];

            //var t41 = SS[1][3, 0];
            //var t42 = SS[1][3, 1];
            //var t43 = SS[1][3, 2];
            //var t44 = SS[1][3, 3];
        }
    }
}