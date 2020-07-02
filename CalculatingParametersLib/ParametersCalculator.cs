using System;

namespace CalculatingParametersLib
{
    public class ParametersCalculator
    {
        private const double SpeedOfLight = 300000000;

        public double Rz(double z2p, double z1p)
        {
            return z2p / z1p;
        }

        public double Zc1(double rc, double rp, double k,double z0)
        {
            var x = (1-Math.Pow(k,2)*(rc/rp+rp/rc)/2)/(1 - Math.Pow(k, 2));
            var e = Math.Sqrt(x+Math.Sqrt(Math.Pow(x,2)-1));
            return z0*e/Math.Sqrt(-rc*rp);
        }

        public double Zp1(double rc, double rp, double k, double z0)
        {
            var x = (1 - Math.Pow(k, 2) * (rc / rp + rp / rc) / 2) / (1 - Math.Pow(k, 2));
            var e = Math.Sqrt(x + Math.Sqrt(Math.Pow(x, 2) - 1));
            return z0 / (Math.Sqrt(-rc * rp)* e) ;
        }

        public double Z1OrZ2(double l, double c)
        {
            return Math.Sqrt(l / c);
        }

        public double Kc(double c12, double c11,double c22)
        {
            return Math.Abs(c12) / Math.Sqrt(c11 * c22);
        }

        public double Kl(double l12, double l11, double l22)
        {
            return l12 / Math.Sqrt(l11 * l22);
        }

        public double Klc(double kl, double kc)
        {
            return (kl-kc)/(1-kl*kc);
        }

        public double D(double q11, double q12, double q22, double q21)
        {
            return Math.Sqrt(Math.Pow(q11-q22,2)+4*q12*q21);
        }
        public double Q11(double l11, double c11, double l12, double c12)
        {
            return l11 * c11 - l12 * c12;
        }
        public double Q22(double l12, double c12, double l22, double c22)
        {
            return -l12 * c12 + l22 * c22;
        }
        public double Q12(double l11, double c22, double l12, double c12)
        {
            return -l11 * c12 + l12 * c22;
        }
        public double Q21(double l22, double c11, double l12, double c12)
        {
            return l12 * c11 - l22 * c12;
        }

        public double Erc(double q11, double q22, double d)
        {
            //double q11 = l11 * c11 - l12 * c12;
            //double q22 = -l12 * c12 + l22 * c22;
            //double q12 = -l11 * c12 + l12 * c22;
            //double q21 = l12 * c11 - l22 * c12;
            //double d = D(q11,q12,q22,q21);
            //double d = Math.Sqrt(Math.Pow(q11 - q22, 2) + 4 * q12 * q21);
            return (Math.Pow(SpeedOfLight,2)/2) * (q11+q22+d);
        }

        public double Erp(double q11, double q22, double d)
        {
            //double q11 = l11 * c11 - l12 * c12;
            //double q22 = -l12 * c12 + l22 * c22;
            //double q12 = -l11 * c12 + l12 * c22;
            //double q21 = l12 * c11 - l22 * c12;
            //double d = D(q11, q12, q22, q21);
            //double d = Math.Sqrt(Math.Pow(q11 - q22, 2) + 4 * q12 * q21);
            return (Math.Pow(SpeedOfLight, 2) / 2) * (q11 + q22 - d);
        }

        public double Rc(double q11, double q22, double d, double q12)
        {
            //double q11 = l11 * c11 - l12 * c12;
            //double q22 = -l12 * c12 + l22 * c22;
            //double q12 = -l11 * c12 + l12 * c22;
            //double q21 = l12 * c11 - l22 * c12;
            //double d = D(q11, q12, q22, q21);
            //double d = Math.Sqrt(Math.Pow(q11 - q22, 2) + 4 * q12 * q21);
            return (q22 - q11 + d)/(2 * q12);
        }

        public double Rp(double q11, double q22, double d, double q12)
        {
            //double q11 = l11 * c11 - l12 * c12;
            //double q22 = -l12 * c12 + l22 * c22;
            //double q12 = -l11 * c12 + l12 * c22;
            //double q21 = l12 * c11 - l22 * c12;
            //double d = D(q11, q12, q22, q21);
            //double d = Math.Sqrt(Math.Pow(q11 - q22, 2) + 4 * q12 * q21);
            return (q22 - q11 - d) / (2 * q12);
        }

        /// <summary>
        /// Модальные импедансы Zc1 , Zp1.
        /// </summary>
        /// <param name="c11"></param>
        /// <param name="c12"></param>
        /// <param name="ercOrErp"></param>
        /// <param name="rcOrRp"></param>
        /// <returns></returns>
        public double Zc1OrZp1(double c11, double c12, double ercOrErp, double rcOrRp)
        {
            return 1/SpeedOfLight * (Math.Sqrt(ercOrErp) /(c11-c12 * rcOrRp));
        }

        public double Zc2OrZp2(double rc, double rp, double zc1OrZp1)
        {
            return -rc*rp*zc1OrZp1;
        }

        public double DForImpedance(double rc, double rp)
        {
            return Math.Pow(rc - rp, -1);
        }

        public double Z11(double rc, double rp, double zc1, double zp1, double d)
        {
            return (zp1 * rc - zc1 * rp) * d;
        }

        public double Z22(double rc, double rp, double zc1, double zp1, double d)
        {
            return (zp1 * rp - zc1 * rc) * rc * rp * d;
        }

        public double Z12(double rc, double rp, double zc1, double zp1, double d)
        {
            return (zp1 - zc1) * rc * rp * d;
        }

        public double Z0(double zc2, double zp1)
        {
            return Math.Sqrt(zc2*zp1);
        }

        public double Z0(double zc1, double zp1, double rc, double rp, bool c1p1Orc2p2)
        {
            if (c1p1Orc2p2)
            {
                return Math.Sqrt(-rc*rp*zc1*zp1);
            }
            return Math.Sqrt(Math.Pow(-rc * rp, -1) * zc1 * zp1);
        }

        public double K(double z12, double z11, double z22)
        {
            return z12 / Math.Sqrt(z22 * z11);
        }

        public double Zc(double z12, double z11, double z22)
        {
            return z12 + Math.Sqrt(z22 * z11);
        }

        public double Zp(double z12, double z11, double z22)
        {
            return -z12 + Math.Sqrt(z22 * z11);
        }

        public double Z2p(double zc2, double rc, double zp2, double rp)
        {
            return (zc2*(rc-1)-zp2*(rp-1))/(rc-rp);
        }

        public double Z1p(double zc2, double rc, double zp2, double rp)
        {
            return (zc2 * (1/rc - 1) - zp2 * (1/rp - 1)) / (rc - rp);
        }

        public double Z12(double zc2, double rc, double zp2, double rp)
        {
            return (zc2 - zp2) / (rc - rp);
        }

        public double Z1с(double z2p, double z0)
        {
            return Math.Pow(z0,2) / z2p;
        }

        public double Z2с(double z1p, double z0)
        {
            return Math.Pow(z0, 2) / z1p;
        }

        public double Zm(double z12, double z0)
        {
            return Math.Pow(z0, 2) / z12;
        }

        public double Z01(double rc, double zp1, double rp, double zc1)
        {
            return Math.Sqrt((rc * zp1 - rp * zc1) / (rc * Math.Pow(zp1, -1) - rp * Math.Pow(zc1, -1)));
        }

        public double Z02(double rc, double zp2, double rp, double zc2)
        {
            return Math.Sqrt((rc * zp2 - rp * zc2) / (rc * Math.Pow(zp2, -1) - rp * Math.Pow(zc2, -1)));
        }
        public double Z02(double z0, double z01)
        {
            return Math.Pow(z0, 2) / z01;
        }

        public double Ke(double erc, double erp)
        {
            return (1-Math.Pow(Math.Sqrt(erp)/Math.Sqrt(erc),2))/ (1 + Math.Pow(Math.Sqrt(erp) / Math.Sqrt(erc), 2));
            //return (erc - erp) / (erp + erc);
        }

        public double Kv(double erc, double erp)
        {
            return (1 - Math.Pow(Math.Sqrt(erp) / Math.Sqrt(erc), 1)) / (1 + Math.Pow(Math.Sqrt(erp) / Math.Sqrt(erc), 1));
            //return (Math.Sqrt(erc) - Math.Sqrt(erp)) / (Math.Sqrt(erp) + Math.Sqrt(erc));
        }

        public double L11(double erc, double erp, double zp1, double zc1, double rc, double rp)
        {
            return (Math.Sqrt(erp) * zp1 / rp - Math.Sqrt(erc) * zc1 / rc) * rc * rp * Math.Pow(rc - rp, -1) / SpeedOfLight;
        }

        public double L22(double erc, double erp, double zp1, double zc1, double rc, double rp)
        {
            return (Math.Sqrt(erp) * zp1 * rp - Math.Sqrt(erc) * zc1 * rc) * rc * rp * Math.Pow(rc - rp, -1) / SpeedOfLight;
        }

        public double L12(double erc, double erp, double zp1, double zc1, double rc, double rp)
        {
            return (Math.Sqrt(erp) * zp1 - Math.Sqrt(erc) * zc1) * rc * rp * Math.Pow(rc - rp, -1) / SpeedOfLight;
        }

        public double C11(double erc, double erp, double zp1, double zc1, double rc, double rp)
        {
            return (Math.Sqrt(erp)  * rc / zp1 - Math.Sqrt(erc) * rp / zc1) * Math.Pow(rc - rp, -1) / SpeedOfLight;
        }

        public double C22(double erc, double erp, double zp1, double zc1, double rc, double rp)
        {
            return (Math.Sqrt(erp)  / (zp1 * rc) - Math.Sqrt(erc) / (zc1 * rp)) * Math.Pow(rc - rp, -1) / SpeedOfLight;
        }

        public double C12(double erc, double erp, double zp1, double zc1, double rc, double rp)
        {
            return (Math.Sqrt(erp) / zp1 - Math.Sqrt(erc) / zc1) * Math.Pow(rc - rp, -1) / SpeedOfLight;
        }

        public double Y22(double z11, double z12, double z22)
        {
            return z11 / (z11 * z22 - Math.Pow(z12, 2));
        }

        public double Y11(double z11, double z12, double z22)
        {
            return z22 / (z11 * z22 - Math.Pow(z12, 2));
        }

        public double Y12(double zm, double z12, double z22)
        {
            return -1 / zm;
        }

        public double M(double erc, double erp)
        {
            return Math.Sqrt(erp) / Math.Sqrt(erc);
        }
    }
}
