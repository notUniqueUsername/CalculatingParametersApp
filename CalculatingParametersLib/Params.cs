﻿using System;
using System.Diagnostics.Eventing.Reader;

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
            set => _l11 = value;
        }
        public static double L12
        {
            get => _l12;
            set => _l12 = value;
        }
        public static double L22
        {
            get => _l22;
            set => _l22 = value;
        }
        private static double _c11;
        private static double _c12;
        private static double _c22;
        public static double C11
        {
            get => _c11;
            set => _c11 = value;
        }
        public static double C12
        {
            get => _c12;
            set => _c12 = value;
        }
        public static double C22
        {
            get => _c22;
            set => _c22 = value;
        }


        private static double _z0;
        private static double _k;
        private static double _rp;
        private static double _rc;
        private static double _erc;
        private static double _erp;
        public static double Z0
        {
            get => _z0;
            set => _z0 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double k
        {
            get => _k;
            set => _k = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Rc
        {
            get => _rc;
            set => _rc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Rp
        {
            get => _rp;
            set => _rp = value;
        }
        public static double Erc
        {
            get => _erc;
            set => _erc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Erp
        {
            get => _erp;
            set => _erp = Math.Round(value / Math.Pow(10, 0), 3);
        }


        private static double _kl;
        private static double _kc;
        private static double _klc;
        private static double _ke;
        private static double _kv;
        private static double _m;
        public static double kl
        {
            get => _kl;
            set => _kl = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double kc
        {
            get => _kc;
            set => _kc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double klc
        {
            get => _klc;
            set => _klc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double ke
        {
            get => _ke;
            set => _ke= Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double kv
        {
            get => _kv;
            set => _kv = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double m
        {
            get => _m;
            set => _m = Math.Round(value / Math.Pow(10, 0), 3);
        }

        private static double _z11;
        private static double _z12;
        private static double _z22;
        public static double Z11
        {
            get => _z11;
            set => _z11 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Z12
        {
            get => _z12;
            set => _z12 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Z22
        {
            get => _z22;
            set => _z22 = Math.Round(value / Math.Pow(10, 0), 3);
        }

        private static double _y11;
        private static double _y12;
        private static double _y22;
        public static double Y11
        {
            get => _y11;
            set => _y11 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Y12
        {
            get => _y12;
            set => _y12 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Y22
        {
            get => _y22;
            set => _y22 = Math.Round(value / Math.Pow(10, 0), 3);
        }

        private static double _z1;
        private static double _z2;
        private static double _zc;
        private static double _zp;
        private static double _zc1;
        private static double _zp1;
        private static double _zc2;
        private static double _zp2;
        public static double Z1
        {
            get => _z1;
            set => _z1 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Z2
        {
            get => _z2;
            set => _z2 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Zc
        {
            get => _zc;
            set => _zc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Zp
        {
            get => _zp;
            set
            {
                if (value < Math.Pow(10, -3) || value > Math.Pow(10, 5))
                {
                    _zp = value;
                }
                else
                {
                    _zp = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            //set => _zp = value;
            //set => _zp = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Zc1
        {
            get => _zc1;
            set
            {
                if (value < Math.Pow(10, -3) || value > Math.Pow(10, 5))
                {
                    _zc1 = value;
                }
                else
                {
                    _zc1 = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            
            //set => _zc1 = value;
            //set => _zc1 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Zp1
        {
            get => _zp1;
            set
            {
                if (value < Math.Pow(10, -3) || value > Math.Pow(10, 5))
                {
                    _zp1 = value;
                }
                else
                {
                    _zp1 = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            //set => _zp1 = value;
            //set => _zp1 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Zc2
        {
            get => _zc2;
            set
            {
                if (value < Math.Pow(10, -3) || value > Math.Pow(10, 5))
                {
                    _zc2 = value;
                }
                else
                {
                    _zc2 = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            //set => _zc2 = value;
            //set => _zc2 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Zp2
        {
            get => _zp2;
            set
            {
                if (value < Math.Pow(10, -3) || value > Math.Pow(10, 5))
                {
                    _zp2 = value;
                }
                else
                {
                    _zp2 = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            //set => _zp2 = value;
            //set => _zp2 = Math.Round(value / Math.Pow(10, 0), 3);
        }

        private static double _z01;
        private static double _z02;
        private static double _z1c;
        private static double _z2c;
        private static double _zm;
        private static double _z1p;
        private static double _z2p;
        private static double _s21;
        public static double Z01
        {
            get => _z01;
            set => _z01 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Z02
        {
            get => _z02;
            set => _z02 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Z1c
        {
            get => _z1c;
            set
            {
                if (value < Math.Pow(10, -3) || value > Math.Pow(10, 5))
                {
                    _z1c = value;
                }
                else
                {
                    _z1c = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            //set => _z1c = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Z2c
        {
            get => _z2c;
            set
            {
                if (value < Math.Pow(10, -3) || value > Math.Pow(10, 5))
                {
                    _z2c = value;
                }
                else
                {
                    _z2c = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            //set => _z2c = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Zm
        {
            get => _zm;
            set => _zm = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Z1p
        {
            get => _z1p;
            set
            {
                if (value<Math.Pow(10,-3) || value>Math.Pow(10,5))
                {
                   _z1p = value; 
                }
                else
                {
                    _z1p = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            
            //set => _z1p = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public static double Z2p
        {
            get => _z2p;
            set
            {
                if (value < Math.Pow(10, -3) || value > Math.Pow(10, 5))
                {
                    _z2p = value;
                }
                else
                {
                    _z2p = Math.Round(value / Math.Pow(10, 0), 3);
                }
            }
            //set => _z2p = Math.Round(value / Math.Pow(10, 0), 3);
        }

        public static double S21
        {
            get => _s21;
            set => _s21 = Math.Round(value / Math.Pow(10, 0), 3);
        }

        public static bool PhysRelease()
        {
            bool result = _c11 > 0 && _c12 > 0 && _c22 > 0 && _l11 > 0 && _l12 > 0 && _l22 > 0;
            if (Rp>Rc)
            {
                var swapData = Rc;
                Rc = Rp;
                Rp = swapData;
                swapData = Erc;
                Erc = Erp;
                Erp = swapData;
            }
            return result;
        }
    }
}