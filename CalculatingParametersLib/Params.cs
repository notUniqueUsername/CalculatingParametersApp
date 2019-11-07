using System;

namespace CalculatingParametersLib
{
    public static class Params
    {
        private static double _l11;
        private static double _l12;
        private static double _l22;
        public static double L11
        {
            get => _l11;
            set => _l11 = Math.Round(value / Math.Pow(10, -6), 4);
        }
        public static double L12
        {
            get => _l12;
            set => _l12 = Math.Round(value / Math.Pow(10, -6), 4);
        }
        public static double L22
        {
            get => _l22;
            set => _l22 = Math.Round(value / Math.Pow(10, -6), 4);
        }
        private static double _c11;
        private static double _c12;
        private static double _c22;
        public static double C11
        {
            get => _c11;
            set => _c11 = Math.Round(value / Math.Pow(10, -12), 4);
        }
        public static double C12
        {
            get => _c12;
            set => _c12 = Math.Round(value / Math.Pow(10, -12), 4);
        }
        public static double C22
        {
            get => _c22;
            set => _c22 = Math.Round(value / Math.Pow(10, -12), 4);
        }

        public static double Z0 { get; set; }
        public static double k { get; set; }
        public static double Rc { get; set; }
        public static double Rp { get; set; }
        public static double Erc { get; set; }
        public static double Erp { get; set; }

        public static double kl { get; set; }
        public static double kc { get; set; }
        public static double klc { get; set; }
        public static double ke { get; set; }
        public static double kv { get; set; }
        public static double m { get; set; }

        public static double Z11 { get; set; }
        public static double Z12 { get; set; }
        public static double Z22 { get; set; }

        public static double Y11 { get; set; }
        public static double Y12 { get; set; }
        public static double Y22 { get; set; }

        public static double Z1 { get; set; }
        public static double Z2 { get; set; }
        public static double Zc { get; set; }
        public static double Zp { get; set; }
        public static double Zc1 { get; set; }
        public static double Zp1 { get; set; }
        public static double Zc2 { get; set; }
        public static double Zp2 { get; set; }

        public static double Z01 { get; set; }
        public static double Z02 { get; set; }
        public static double Z1c { get; set; }
        public static double Z2c { get; set; }
        public static double Zm { get; set; }
        public static double Z1p { get; set; }
        public static double Z2p { get; set; }

        public static double S21 { get; set; }
    }
}