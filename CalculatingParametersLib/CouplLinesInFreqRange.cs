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
        /// <summary>
        /// задание частотного диапазона (ГГц) (1 to nf)
        /// </summary>
        private double _freqRange;

        private double[] _fi;
        private double _electricalLengthForC;
        private double _electricalLengthForP;
        private double _z1in;
        private double _z2in;
        private double _z1out;
        private double _z2out;

        public CouplLinesInFreqRange(Params currentParams)
        {
            var range = Vector<double>.Build.Dense(_nf, i => i);
            var vector2 = Vector<double>.Build.Dense(_nf, i => ((_fmax - _fmin) / (_nf - 1)) * i + _fmin);
            var vector3 = Vector<double>.Build.Dense(5, i => i + 3.0);
        }
    }
}