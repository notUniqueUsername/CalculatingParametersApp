using System;

namespace CalculatingParametersLib
{
    public class Params
    {
        private double _eee;

        public double EEE
        {
            get => _eee;
            set => _eee = value;
        }

        private double _d;

        private bool _rzNegativeStatus;

        public bool RzNegativeStatus 
        {
            get => _rzNegativeStatus;
            set => _rzNegativeStatus = value;
        }

        public void RzCheck()
        {
            if (Rz < 0)
            {
                RzNegativeStatus = true;
                var calculator = new ParametersCalculator();
                N = calculator.N(Rc, Rp, k, RzNegativeStatus);
                Z11 = calculator.Z11(Zok, N);
                Z22 = calculator.Z22(Zok, N);
                Z12 = calculator.Z12(Zok, k);
                Rz = calculator.Rz(Z12, Z22, Z11);
                RzNegativeStatus = Rz < 0;
            }
        }

        private double _zok;

        public double Zok
        {
            get => _zok;
            set => _zok = value;
        }

        private double _n;

        public double N
        {
            get => _n;
            set => _n = value;
        }

        private double _rz;

        public double Rz
        {
            get => _rz;
            set => _rz = value;
        }

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
            set => _z0 = value;
        }
        public double k
        {
            get => _k;
            set => _k = value;
        }
        public double Rc
        {
            get => _rc;
            set => _rc = value;
        }
        public double Rp
        {
            get => _rp;
            set
            {
                if (value == 0)
                {
                    _rp = -1e-3;
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
            set => _erc = value;
        }
        public double Erp
        {
            get => _erp;
            set => _erp = value;
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
            set => _kl = value;
        }
        public double kc
        {
            get => _kc;
            set => _kc = value;
        }
        public double klc
        {
            get => _klc;
            set => _klc = value;
        }
        public double ke
        {
            get => _ke;
            set => _ke= value;
        }
        public double kv
        {
            get => _kv;
            set => _kv = value;
        }
        public double m
        {
            get => _m;
            set => _m = value;
        }

        private double _z11;
        private double _z12;
        private double _z22;
        public double Z11
        {
            get => _z11;
            set => _z11 = value;
        }
        public double Z12
        {
            get => _z12;
            set => _z12 = value;
        }
        public double Z22
        {
            get => _z22;
            set => _z22 = value;
        }

        private double _y11;
        private double _y12;
        private double _y22;
        public double Y11
        {
            get => _y11;
            set => _y11 = value;
        }
        public double Y12
        {
            get => _y12;
            set => _y12 = value;
        }
        public double Y22
        {
            get => _y22;
            set => _y22 = value;
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
            set => _z1 = value;
        }
        public double Z2
        {
            get => _z2;
            set => _z2 = value;
        }
        public double Zc
        {
            get => _zc;
            set => _zc = value;
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
                    _zp = value;
                }
            }
            //set => _zp = value;
            //set => _zp = value;
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
                    _zc1 = value;
                }
            }
            
            //set => _zc1 = value;
            //set => _zc1 = value;
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
                    _zp1 = value;
                }
            }
            //set => _zp1 = value;
            //set => _zp1 = value;
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
                    _zc2 = value;
                }
            }
            //set => _zc2 = value;
            //set => _zc2 = value;
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
                    _zp2 = value;
                }
            }
            //set => _zp2 = value;
            //set => _zp2 = value;
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
            set => _z01 = value;
        }
        public double Z02
        {
            get => _z02;
            set => _z02 = value;
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
                    _z1c = value;
                }
            }
            //set => _z1c = value;
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
                    _z2c = value;
                }
            }
            //set => _z2c = value;
        }
        public double Zm
        {
            get => _zm;
            set => _zm = value;
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
                    _z1p = value;
                }
            }
            
            //set => _z1p = value;
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
                    _z2p = value;
                }
            }
            //set => _z2p = value;
        }

        public double S21
        {
            get => _s21;
            set => _s21 = value;
        }
        /// <summary>
        /// Необходимо выполнять перед расчетом параметров зависящих от Erc Erp Rc Rp, но после расчета Rc Rp Erc Erp
        /// </summary>
        public void RpRcCheck()
        {
            if (Rc == 0 || Rp == 0)
            {
                throw new ArgumentNullException("RpRcCheck()", "Необходимо выполнять перед расчетом параметров зависящих от Rc Rp, но после расчета Rc Rp");
            }

            if (Rc * Rp < 0)
            {
                if (Rp > Rc)
                {
                    D = -D;
                    var swapData = Rp;
                    Rp = Rc;
                    Rc = swapData;
                }
            }
            else
            {
                if (Rp < Rc)
                {
                    D = -D;
                    var swapData = Rp;
                    Rp = Rc;
                    Rc = swapData;
                }
            }

        }

        public bool PhysRelease()
        {
            Result = _c11 - _c12 > 0
                          && _c22 - _c12 > 0 
                          && _c12 > 0 
                          && _l11 - _l12 > 0 
                          && _l22 - _l12 > 0 
                          && _l12 > -1e-10;

            return Result;
        }

        private bool _result;

        public bool Result
        {
            get => _result;
            set => _result = value;
        }

        public Params GetForamttedParams()
        {
            PhysRelease();
            var formattedParams = new Params
            {
                C11 = Math.Round(C11, 3),
                C12 = Math.Round(C12, 3),
                C22 = Math.Round(C22, 3),
                Z0 = Math.Round(Z0, 3),
                k = Math.Round(k, 3),
                Rc = Math.Round(Rc, 3),
                Rp = Math.Round(Rp, 3),
                Erc = Math.Round(Erc, 3),
                Erp = Math.Round(Erp, 3),
                Zc = Math.Round(Zc, 3),
                Zp = Math.Round(Zp, 3),
                Z1 = Math.Round(Z1, 3),
                Z2 = Math.Round(Z2, 3),
                N = Math.Round(N, 3),
                Rz = Math.Round(Rz, 3),
                Z1c = Math.Round(Z1c, 3),
                Z2c = Math.Round(Z2c, 3),
                Zm = Math.Round(Zm, 3),
                S21 = Math.Round(S21, 3),
                L11 = Math.Round(L11, 3),
                L12 = Math.Round(L12, 3),
                L22 = Math.Round(L22, 3),
                kl = Math.Round(kl, 3),
                kc = Math.Round(kc, 3),
                klc = Math.Round(klc, 3),
                ke = Math.Round(ke, 3),
                m = Math.Round(m, 3),
                EEE = Math.Round(EEE, 3),
                Zc1 = Math.Round(Zc1, 3),
                Zp1 = Math.Round(Zp1, 3),
                Zc2 = Math.Round(Zc2, 3),
                Zp2 = Math.Round(Zp2, 3),
                Z11 = Math.Round(Z11, 3),
                Z22 = Math.Round(Z22, 3),
                Z1p = Math.Round(Z1p, 3),
                Z2p = Math.Round(Z2p, 3),
                Z12 = Math.Round(Z12, 3),
                Result = Result
            };
            return formattedParams;
        }
    }
}