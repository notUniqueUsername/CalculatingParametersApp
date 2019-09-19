using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingParametersLib
{
    public class ParametersCalculator
    {
        private const double SpeedOfLight = 299792458;

        public double Z1OrZ2(double l, double c)
        {
            return Math.Sqrt(l / c);
        }

        public double Kc(double c12, double c11,double c22)
        {
            return Math.Abs(c12) / Math.Sqrt(c11 * c22);
        }

        public double Kl(double c12, double c11, double c22)
        {
            return c12 / Math.Sqrt(c11 * c22);
        }

        public double Klc(double kl, double kc)
        {
            return (kl-kc)/(1-kl*kc);
        }

        public double D(double q11, double q12, double q22, double q21)
        {
            return Math.Sqrt(Math.Pow(q11-q22,2)+4*q12*q21);
        }

        public double Erc(double q11, double q22, double d)
        {
            return (Math.Pow(SpeedOfLight,2)/2) * (q11+q22+d);
        }

        public double Erp(double q11, double q22, double d)
        {
            return (Math.Pow(SpeedOfLight, 2) / 2) * (q11 + q22 - d);
        }

        public double Rc(double q11, double q22, double q12, double d)
        {
            return (q22 - q11 + d)/(2 * q12);
        }

        public double Rp(double q11, double q22, double q12, double d)
        {
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
    }
}
