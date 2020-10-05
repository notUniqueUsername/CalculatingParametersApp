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
        private double Fmin { get; }
        private double Fmax { get; }
        private int Nf { get; }

        private Vector<double> Fi { get; }
        private Vector<double> Wi { get; }
        private Matrix<double> Um { get; }
        private Matrix<double> Im { get; }
        private Vector<Complex> ElectricalLengthForC { get; }
        private Vector<Complex> ElectricalLengthForP { get; }
        private Matrix<double> E4 { get; }
        private Matrix<double> Zl { get; }
        private double Z1In { get; }
        private double Z2in { get; }
        private double Z1Out { get; }
        private double Z2Out { get; }
        private double L { get; }
        private double C { get; }

        private Vector<double> S11 { get; }
        private Vector<double> S12 { get; }
        private Vector<double> S13 { get; }
        private Vector<double> S14 { get; }
        private Vector<double> S22 { get; }
        private Vector<double> S23 { get; }
        private Vector<double> S24 { get; }
        private Vector<double> S33 { get; }
        private Vector<double> S34 { get; }
        private Vector<double> S44 { get; }
        private Vector<double> S21 { get; }
        private Vector<double> S31 { get; }
        private Vector<double> S32 { get; }
        private Vector<double> S41 { get; }
        private Vector<double> S42 { get; }
        private Vector<double> S43 { get; }
        private Vector<double> F11 { get; }
        private Vector<double> F12 { get; }
        private Vector<double> F13 { get; }
        private Vector<double> F14 { get; }
        private Vector<double> F22 { get; }
        private Vector<double> F23 { get; }
        private Vector<double> F24 { get; }
        private Vector<double> F33 { get; }
        private Vector<double> F34 { get; }
        private Vector<double> F44 { get; }
        private Vector<double> F21 { get; }
        private Vector<double> F31 { get; }
        private Vector<double> F32 { get; }
        private Vector<double> F41 { get; }
        private Vector<double> F42 { get; }
        private Vector<double> F43 { get; }

        private Matrix<Complex> ZlComplex { get; }
        private Matrix<Complex> E4Complex { get; }
        private Matrix<Complex>[] Y { get; }

        private readonly Complex _j = Complex.ImaginaryOne;
        public CouplLinesInFreqRange(Params currentParams, double l, double fmin, double fmax, int nf, double z1In, double z2In, double z1Out, double z2Out)
        {
            L = l * Math.Pow(10,-3);
            C = 0.2998;
            Z1In = z1In;
            Z2in = z2In;
            Z1Out = z1Out;
            Z2Out = z2Out;
            Fmin = fmin;
            Fmax = fmax;
            Nf = nf;

            S11 = Vector<double>.Build.Dense(Nf);
            S12 = Vector<double>.Build.Dense(Nf);
            S13 = Vector<double>.Build.Dense(Nf);
            S14 = Vector<double>.Build.Dense(Nf);
            S22 = Vector<double>.Build.Dense(Nf);
            S24 = Vector<double>.Build.Dense(Nf);
            S23 = Vector<double>.Build.Dense(Nf);
            S33 = Vector<double>.Build.Dense(Nf);
            S34 = Vector<double>.Build.Dense(Nf);
            S44 = Vector<double>.Build.Dense(Nf);
            S21 = Vector<double>.Build.Dense(Nf);
            S31 = Vector<double>.Build.Dense(Nf);
            S32 = Vector<double>.Build.Dense(Nf);
            S41 = Vector<double>.Build.Dense(Nf);
            S42 = Vector<double>.Build.Dense(Nf);
            S43 = Vector<double>.Build.Dense(Nf);

            F11 = Vector<double>.Build.Dense(Nf);
            F12 = Vector<double>.Build.Dense(Nf);
            F13 = Vector<double>.Build.Dense(Nf);
            F14 = Vector<double>.Build.Dense(Nf);
            F22 = Vector<double>.Build.Dense(Nf);
            F24 = Vector<double>.Build.Dense(Nf);
            F23 = Vector<double>.Build.Dense(Nf);
            F33 = Vector<double>.Build.Dense(Nf);
            F34 = Vector<double>.Build.Dense(Nf);
            F44 = Vector<double>.Build.Dense(Nf);
            F21 = Vector<double>.Build.Dense(Nf);
            F31 = Vector<double>.Build.Dense(Nf);
            F32 = Vector<double>.Build.Dense(Nf);
            F41 = Vector<double>.Build.Dense(Nf);
            F42 = Vector<double>.Build.Dense(Nf);
            F43 = Vector<double>.Build.Dense(Nf);


            E4 = Matrix<double>.Build.DenseIdentity(4);
            Zl = Matrix<double>.Build.DenseIdentity(4);
            Zl[0, 0] = Math.Sqrt(Z1In);
            Zl[1, 1] = Math.Sqrt(Z2in);
            Zl[2, 2] = Math.Sqrt(Z1Out);
            Zl[3, 3] = Math.Sqrt(Z2Out);
            ZlComplex = Zl.ToComplex();
            E4Complex = E4.ToComplex();
            Y = new Matrix<Complex>[Nf];
            
            Fi = Vector<double>.Build.Dense(Nf, i => ((Fmax - Fmin) / (Nf - 1)) * (i+1) + Fmin);
            Wi = Fi.Multiply(2 * Math.PI);
            Um = Matrix<double>.Build.Dense(2, 2);
            Um[0, 0] = 1;
            Um[0, 1] = 1;
            Um[1, 0] = currentParams.Rc;
            Um[1, 1] = currentParams.Rp;

            Im = Matrix<double>.Build.Dense(2, 2);
            Im[0, 0] = Math.Pow(currentParams.Zc1,-1);
            Im[0, 1] = Math.Pow(currentParams.Zp1, -1);
            Im[1, 0] = -Math.Pow(currentParams.Zc1 * currentParams.Rp, -1);
            Im[1, 1] = -Math.Pow(currentParams.Zp1 * currentParams.Rc, -1);

            ElectricalLengthForC = Vector<Complex>.Build.Dense(Nf, i => _j * Wi[i] * (Math.Sqrt(currentParams.Erc) / C) * L);
            ElectricalLengthForP = Vector<Complex>.Build.Dense(Nf, i => _j * Wi[i] * (Math.Sqrt(currentParams.Erp) / C) * L);

            var tet = new Vector<Complex>[Nf];
            for (int i = 0; i < Nf; i++)
            {
                tet[i] = Vector<Complex>.Build.Dense(new[] { ElectricalLengthForC[i], ElectricalLengthForP[i] });
            }

            var coIntermediate = new Vector<Complex>[Nf];
            var co = new Vector<Complex>[Nf];
            for (int i = 0; i < Nf; i++)
            {
                var coIntermediate1 = Vector<Complex>.Build.Dense(2);
                var coIntermediate2 = Vector<Complex>.Build.Dense(2);
                coIntermediate[i]=tet[i];
                coIntermediate[i].PointwiseTanh(coIntermediate1);
                coIntermediate1.DivideByThis(1,coIntermediate2);
                co[i] = coIntermediate2;
            }

            var scIntermediate = new Vector<Complex>[Nf];
            var sc = new Vector<Complex>[Nf];
            for (int i = 0; i < Nf; i++)
            {
                var scIntermediate1 = Vector<Complex>.Build.Dense(2);
                var scIntermediate2 = Vector<Complex>.Build.Dense(2);
                scIntermediate[i] = tet[i];
                scIntermediate[i].PointwiseSinh(scIntermediate1);
                scIntermediate1.DivideByThis(1, scIntermediate2);
                sc[i] = scIntermediate2;
            }

            var diagCo = new Matrix<Complex>[Nf];
            for (int i = 0; i < Nf; i++)
            {
                diagCo[i] = Matrix<Complex>.Build.DenseOfDiagonalVector(co[i]);
            }

            var diagSc = new Matrix<Complex>[Nf];
            for (int i = 0; i < Nf; i++)
            {
                diagSc[i] = Matrix<Complex>.Build.DenseOfDiagonalVector(sc[i]);
            }
            
            var yaa = new Matrix<Complex>[Nf];
            var imIntermediate = Matrix<Complex>.Build.Dense(2, 2);
            var umIntermediate = Matrix<Complex>.Build.Dense(2, 2);
            imIntermediate = Im.ToComplex();
            umIntermediate = Um.Inverse().ToComplex();
            var diagCoIntermediate = diagCo;
            for (int i = 0; i < Nf; i++)
            {
                yaa[i] = imIntermediate.Multiply(diagCoIntermediate[i]).Multiply(umIntermediate);
            }


            var yab = new Matrix<Complex>[Nf];
            var diagScIntermediate = diagSc;
            for (int i = 0; i < Nf; i++)
            {
                yab[i] = imIntermediate.Multiply(diagScIntermediate[i]).Multiply(umIntermediate);
            }

            var yaayab1 = new Matrix<Complex>[Nf];
            var yaayab2 = new Matrix<Complex>[Nf];
            var yo = new Matrix<Complex>[Nf];
            for (int i = 0; i < Nf; i++)
            {
                yaayab1[i] = yaa[i].Append(yab[i]);
                yaayab2[i] = yab[i].Append(yaa[i]);
                yo[i] = yaayab1[i].Stack(yaayab2[i]);
            }

            for (int i = 0; i < Nf; i++)
            {
                Y[i] = ZlComplex.Multiply(yo[i]).Multiply(ZlComplex);
            }
            var SS = new Matrix<Complex>[Nf];
            for (int i = 0; i < Nf; i++)
            {
                SS[i] = 2 * (E4Complex + Y[i]).Inverse() - E4Complex;
            }

            var SS11 = Vector<Complex>.Build.Dense(Nf);
            var SS12 = Vector<Complex>.Build.Dense(Nf);
            var SS13 = Vector<Complex>.Build.Dense(Nf);
            var SS14 = Vector<Complex>.Build.Dense(Nf);
            var SS22 = Vector<Complex>.Build.Dense(Nf);
            var SS24 = Vector<Complex>.Build.Dense(Nf);
            var SS23 = Vector<Complex>.Build.Dense(Nf);
            var SS33 = Vector<Complex>.Build.Dense(Nf);
            var SS34 = Vector<Complex>.Build.Dense(Nf);
            var SS44 = Vector<Complex>.Build.Dense(Nf);
            var SS21 = Vector<Complex>.Build.Dense(Nf);
            var SS31 = Vector<Complex>.Build.Dense(Nf);
            var SS32 = Vector<Complex>.Build.Dense(Nf);
            var SS41 = Vector<Complex>.Build.Dense(Nf);
            var SS42 = Vector<Complex>.Build.Dense(Nf);
            var SS43 = Vector<Complex>.Build.Dense(Nf);
            for (int i = 0; i < Nf; i++)
            {
                SS11[i] = SS[i][0, 0];
                SS12[i] = SS[i][0, 1];
                SS13[i] = SS[i][0, 2];
                SS14[i] = SS[i][0, 3];
                SS22[i] = SS[i][1, 1];
                SS24[i] = SS[i][1, 3];
                SS23[i] = SS[i][1, 2];
                SS33[i] = SS[i][2, 2];
                SS34[i] = SS[i][2, 3];
                SS44[i] = SS[i][3, 3];
                SS21[i] = SS[i][1, 0];
                SS31[i] = SS[i][2, 0];
                SS32[i] = SS[i][2, 1];
                SS41[i] = SS[i][3, 0];
                SS42[i] = SS[i][3, 1];
                SS43[i] = SS[i][3, 2];
            }

            for (int i = 0; i < Nf; i++)
            {
                S11[i] = 20 * Math.Log10(SS11.PointwiseAbs()[i].Real);
                S12[i] = 20 * Math.Log10(SS12.PointwiseAbs()[i].Real);
                S13[i] = 20 * Math.Log10(SS13.PointwiseAbs()[i].Real);
                S14[i] = 20 * Math.Log10(SS14.PointwiseAbs()[i].Real);
                S22[i] = 20 * Math.Log10(SS22.PointwiseAbs()[i].Real);
                S24[i] = 20 * Math.Log10(SS24.PointwiseAbs()[i].Real);
                S23[i] = 20 * Math.Log10(SS23.PointwiseAbs()[i].Real);
                S33[i] = 20 * Math.Log10(SS33.PointwiseAbs()[i].Real);
                S34[i] = 20 * Math.Log10(SS34.PointwiseAbs()[i].Real);
                S44[i] = 20 * Math.Log10(SS44.PointwiseAbs()[i].Real);
                S21[i] = 20 * Math.Log10(SS21.PointwiseAbs()[i].Real);
                S31[i] = 20 * Math.Log10(SS31.PointwiseAbs()[i].Real);
                S32[i] = 20 * Math.Log10(SS32.PointwiseAbs()[i].Real);
                S41[i] = 20 * Math.Log10(SS41.PointwiseAbs()[i].Real);
                S42[i] = 20 * Math.Log10(SS42.PointwiseAbs()[i].Real);
                S43[i] = 20 * Math.Log10(SS43.PointwiseAbs()[i].Real);

                F11[i] = 180 / Math.PI * SS11[i].Phase;
                F12[i] = 180 / Math.PI * SS12[i].Phase;
                F13[i] = 180 / Math.PI * SS13[i].Phase;
                F14[i] = 180 / Math.PI * SS14[i].Phase;
                F22[i] = 180 / Math.PI * SS22[i].Phase;
                F24[i] = 180 / Math.PI * SS24[i].Phase;
                F23[i] = 180 / Math.PI * SS23[i].Phase;
                F33[i] = 180 / Math.PI * SS33[i].Phase;
                F34[i] = 180 / Math.PI * SS34[i].Phase;
                F44[i] = 180 / Math.PI * SS44[i].Phase;
                F21[i] = 180 / Math.PI * SS21[i].Phase;
                F31[i] = 180 / Math.PI * SS31[i].Phase;
                F32[i] = 180 / Math.PI * SS32[i].Phase;
                F41[i] = 180 / Math.PI * SS41[i].Phase;
                F42[i] = 180 / Math.PI * SS42[i].Phase;
                F43[i] = 180 / Math.PI * SS43[i].Phase;
            }
        }
        /// <summary>
        /// Возвращает амплитуды S11, S12, S13, S14, S22, S23, S24, S33, S34, S44.
        /// </summary>
        /// <returns>
        /// S11, S12, S13, S14, S22, S23, S24, S33, S34, S44.
        /// </returns>
        public double[][] GetSParamMagnitude()
        {
            double[][] sParamMagnitudes =
                {S11.ToArray(), S12.ToArray(), S13.ToArray(), S14.ToArray(), S22.ToArray(), S23.ToArray(), S24.ToArray(), S33.ToArray(), S34.ToArray(), S44.ToArray()};
            return sParamMagnitudes;
        }

        /// <summary>
        /// Возвращает фазы F11, F12, F13, F14, F22, F23, F24, F33, F34, F44.
        /// </summary>
        /// <returns>
        /// F11, F12, F13, F14, F22, F23, F24, F33, F34, F44.
        /// </returns>
        public double[][] GetSParamPhase()
        {
            double[][] sParamPhase =
                {F11.ToArray(), F12.ToArray(), F13.ToArray(), F14.ToArray(), F22.ToArray(), F23.ToArray(), F24.ToArray(), F33.ToArray(), F34.ToArray(), F44.ToArray()};
            return sParamPhase;
        }

        public double[] GetFi()
        {
            return Fi.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 0 = Magnitudes, 1 = Phases
        /// </returns>
        public double[][][] GetS4pFile()
        {
            double[][] sParamMagnitudes =
            {
                S11.ToArray(), S12.ToArray(), S13.ToArray(), S14.ToArray(), S21.ToArray(), S22.ToArray(), S23.ToArray(),
                S24.ToArray(), S31.ToArray(), S32.ToArray(), S33.ToArray(), S34.ToArray(), S41.ToArray(), S42.ToArray(),
                S43.ToArray(), S44.ToArray()
            };
            double[][] sParamPhase =
            {
                F11.ToArray(), F12.ToArray(), F13.ToArray(), F14.ToArray(), F21.ToArray(), F22.ToArray(), F23.ToArray(),
                F24.ToArray(), F31.ToArray(), F32.ToArray(), F33.ToArray(), F34.ToArray(), F41.ToArray(), F42.ToArray(),
                F43.ToArray(), F44.ToArray()
            };
            double[][][] sParams = { sParamMagnitudes, sParamPhase };
            return sParams;
        }
    }
}
