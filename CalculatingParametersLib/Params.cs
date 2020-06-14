using System;

namespace CalculatingParametersLib
{
    public class Params
    {
        private double _d;
        public double D
        {
            get => _d;
            set => _d = value;
        }
        private double _q11;
        public double Q11
        {
            get => _q11;
            set => _q11 = value;
        }
        private double _q12;
        public double Q12
        {
            get => _q12;
            set => _q12 = value;
        }
        private double _q22;
        public double Q22
        {
            get => _q22;
            set => _q22 = value;
        }
        private double _q21;
        public double Q21
        {
            get => _q21;
            set => _q21 = value;
        }
        private double _l11;
        private double _l12;
        private double _l22;
        public double L11
        {
            get => _l11;
            set => _l11 = value;
        }
        public double L12
        {
            get => _l12;
            set => _l12 = value;
        }
        public double L22
        {
            get => _l22;
            set => _l22 = value;
        }
        private double _c11;
        private double _c12;
        private double _c22;
        public double C11
        {
            get => _c11;
            set => _c11 = value;
        }
        public double C12
        {
            get => _c12;
            set => _c12 = value;
        }
        public double C22
        {
            get => _c22;
            set => _c22 = value;
        }


        private double _z0;
        private double _k;
        private double _rp;
        private double _rc;
        private double _erc;
        private double _erp;
        public double Z0
        {
            get => _z0;
            set => _z0 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double k
        {
            get => _k;
            set => _k = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Rc
        {
            get => _rc;
            set => _rc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Rp
        {
            get => _rp;
            set
            {
                if (value == 0)
                {
                    _rp = -1e-10;
                }
                else
                {
                    _rp = value;
                }
            }
        }
        public double Erc
        {
            get => _erc;
            set => _erc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Erp
        {
            get => _erp;
            set => _erp = Math.Round(value / Math.Pow(10, 0), 3);
        }


        private double _kl;
        private double _kc;
        private double _klc;
        private double _ke;
        private double _kv;
        private double _m;
        public double kl
        {
            get => _kl;
            set => _kl = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double kc
        {
            get => _kc;
            set => _kc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double klc
        {
            get => _klc;
            set => _klc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double ke
        {
            get => _ke;
            set => _ke= Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double kv
        {
            get => _kv;
            set => _kv = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double m
        {
            get => _m;
            set => _m = Math.Round(value / Math.Pow(10, 0), 3);
        }

        private double _z11;
        private double _z12;
        private double _z22;
        public double Z11
        {
            get => _z11;
            set => _z11 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Z12
        {
            get => _z12;
            set => _z12 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Z22
        {
            get => _z22;
            set => _z22 = Math.Round(value / Math.Pow(10, 0), 3);
        }

        private double _y11;
        private double _y12;
        private double _y22;
        public double Y11
        {
            get => _y11;
            set => _y11 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Y12
        {
            get => _y12;
            set => _y12 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Y22
        {
            get => _y22;
            set => _y22 = Math.Round(value / Math.Pow(10, 0), 3);
        }

        private double _z1;
        private double _z2;
        private double _zc;
        private double _zp;
        private double _zc1;
        private double _zp1;
        private double _zc2;
        private double _zp2;
        public double Z1
        {
            get => _z1;
            set => _z1 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Z2
        {
            get => _z2;
            set => _z2 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Zc
        {
            get => _zc;
            set => _zc = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Zp
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
        public double Zc1
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
        public double Zp1
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
        public double Zc2
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
        public double Zp2
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

        private double _z01;
        private double _z02;
        private double _z1c;
        private double _z2c;
        private double _zm;
        private double _z1p;
        private double _z2p;
        private double _s21;
        public double Z01
        {
            get => _z01;
            set => _z01 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Z02
        {
            get => _z02;
            set => _z02 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Z1c
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
        public double Z2c
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
        public double Zm
        {
            get => _zm;
            set => _zm = Math.Round(value / Math.Pow(10, 0), 3);
        }
        public double Z1p
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
        public double Z2p
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

        public double S21
        {
            get => _s21;
            set => _s21 = Math.Round(value / Math.Pow(10, 0), 3);
        }
        /// <summary>
        /// Необходимо выполнять перед расчетом параметров зависящих от Erc Erp Rc Rp, но после расчета Rc Rp Erc Erp
        /// </summary>
        public void RpRcCheck()
        {
            if (Rc == null || Rp == null || Erc == null || Erp == null)
            {
                throw new ArgumentNullException("RpRcCheck()", "Необходимо выполнять перед расчетом параметров зависящих от Erc Erp Rc Rp, но после расчета Rc Rp Erc Erp");
            }
            if (Rp > Rc)
            {
                var swapData = Rc;
                Rc = Rp;
                Rp = swapData;
                swapData = Erc;
                Erc = Erp;
                Erp = swapData;
                if (Rp > 0 && Rc > 0)
                {
                    swapData = Rc;
                    Rc = Rp;
                    Rp = swapData;
                    swapData = Erc;
                    Erc = Erp;
                    Erp = swapData;
                }
            }
        }

        public bool PhysRelease()
        {
            bool result = _c11 - _c12 > 0
                          && _c22 - _c12 > 0 
                          && _c12 > 0 
                          && _l11 - _l12 > 0 
                          && _l22 - _l12 > 0 
                          && _l12 > -1e-10;

            return result;
        }
    }
}