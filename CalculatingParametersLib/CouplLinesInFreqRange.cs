using System;
using System.ComponentModel;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

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
        private double _electricalLengthForC;
        private double _electricalLengthForP;
        private double _z1in;
        private double _z2in;
        private double _z1out;
        private double _z2out;
        private double _l = 0.1;
        private double _c = 0.2998;
        private double _zo;
        public CouplLinesInFreqRange(Params currentParams)
        {
            _zo = Math.Sqrt(currentParams.Zp1 * currentParams.Zc2);
            var range = Vector<double>.Build.Dense(_nf, i => i);
            _fi = Vector<double>.Build.Dense(_nf, i => ((_fmax - _fmin) / (_nf - 1)) * (i+1) + _fmin);
            _wi = _fi.Multiply(2 * Math.PI);
            _um = Matrix<double>.Build.Dense(2, 2);
            _um[1, 1] = 1;
            _um[1, 2] = 1;
            _um[2, 1] = currentParams.Rc;
            _um[2, 2] = currentParams.Rp;

            _im = Matrix<double>.Build.Dense(2, 2);
            _im[1, 1] = Math.Pow(currentParams.Zc1,-1);
            _im[1, 2] = Math.Pow(currentParams.Zp1, -1);
            _im[2, 1] = Math.Pow(-currentParams.Zc1 * currentParams.Rp, -1);
            _im[2, 2] = Math.Pow(-currentParams.Zp1 * currentParams.Rp, -1);

        }
    }
}