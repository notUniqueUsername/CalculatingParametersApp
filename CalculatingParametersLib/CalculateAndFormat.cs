using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CalculatingParametersLib
{
    public class CalculateAndFormat
    {
        private ParametersCalculator _calculator = new ParametersCalculator();

        public List<double> CalculateResistors(double rc, double rp, double zp1, double zp2, double z0, double zc1, double zc2, double z12)
        {
            var list = new List<double>();
            Params.Z01 = _calculator.Z01(rc,zp1,rp,zc1);
            list.Add(Params.Z01);
            Params.Z02 = _calculator.Z02(rc,zp2,rp,zc2);
            list.Add(Params.Z02);
            Params.Z1p = _calculator.Z1p(zc2,rc,zp2,rp);
            list.Add(Params.Z1p);
            Params.Z2p = _calculator.Z2p(zc2, rc, zp2 ,rp);
            list.Add(Params.Z2p);
            Params.Z1c = _calculator.Z1с(Params.Z2p,z0);
            list.Add(Params.Z1c);
            Params.Z2c = _calculator.Z2с(Params.Z1p,z0);
            list.Add(Params.Z2c);
            Params.Zm = _calculator.Zm(z12,z0);
            list.Add(Params.Zm);
            
            list.Add(z12);

            return list;
        }

        public List<string> ResistorsItem(List<double> list)
        {
            var item = new List<string>
            {
                "Z01=" + Math.Round(list[0] / Math.Pow(10, 0), 1).ToString(),
                "Z02=" + Math.Round(list[1] / Math.Pow(10, 0), 1).ToString(),
                "Z1c=" + Math.Round(list[4] / Math.Pow(10, 0), 1).ToString(),
                "Z2c=" + Math.Round(list[5] / Math.Pow(10, 0), 1).ToString(),
                "Zm=" + Math.Round(list[6] / Math.Pow(10, 0), 1).ToString(),
                "Z1p=" + Math.Round(list[2] / Math.Pow(10, 0), 1).ToString(),
                "Z2p=" + Math.Round(list[3] / Math.Pow(10, 0), 1).ToString(),
                "Z12=" + Math.Round(list[7] / Math.Pow(10, 0), 1).ToString()
            };
            return item;
        }

        public List<double> CalculateKoeff(double erc, double erp)
        {
            var list = new List<double>();
            Params.kl = _calculator.Kl(Params.L12, Params.L11, Params.L22);
            list.Add(Params.kl);
            Params.kc = _calculator.Kc(Params.C12, Params.C11, Params.C22);
            list.Add(Params.kc);
            Params.klc = _calculator.Klc(Params.kl, Params.kc);
            list.Add(Params.klc);
            Params.ke = _calculator.Ke(erc,erp);
            list.Add(Params.ke);
            Params.kv = _calculator.Kv(erc,erp);
            list.Add(Params.kv);
            Params.m = Math.Sqrt(Params.Erp)/ Math.Sqrt(Params.Erc);
            Params.S21 = -20 * Math.Log10(Params.k);
            return list;
        }

        public List<string> KoeffItem(List<double> list)
        {
            var item = new List<string>
            {
                "Kl=" + Math.Round(list[0] / Math.Pow(10, 0), 3).ToString(),
                "Kc=" + Math.Round(list[1] / Math.Pow(10, 0), 3).ToString(),
                "Klc=" + Math.Round(list[2] / Math.Pow(10, 0), 3).ToString(),
                "Ke=" + Math.Round(list[3] / Math.Pow(10, 0), 3).ToString(),
                "Kv=" + Math.Round(list[4] / Math.Pow(10, 0), 3).ToString()
            };

            return item;
        }

        public List<double> CalculatePogonnie(double z0, double k, double rc, double rp, double erc, double erp)
        {
            var list = new List<double>();
            Params.Zp1 = _calculator.Zp1(rc, rp, k, z0);
            Params.Zc1 = _calculator.Zc1(rc, rp, k, z0);
            Params.L11 = _calculator.L11(erc, erp, Params.Zp1, Params.Zc1, rc, rp);
            list.Add(Params.L11);
            Params.L12 = _calculator.L12(erc, erp, Params.Zp1, Params.Zc1, rc, rp);
            list.Add(Params.L12);
            Params.L22 = _calculator.L22(erc, erp, Params.Zp1, Params.Zc1, rc, rp);
            list.Add(Params.L22);

            Params.C11 = _calculator.C11(erc, erp, Params.Zp1, Params.Zc1, rc, rp);
            list.Add(Params.C11);
            Params.C12 = _calculator.C12(erc, erp, Params.Zp1, Params.Zc1, rc, rp);
            list.Add(Params.C12);
            Params.C22 = _calculator.C22(erc, erp, Params.Zp1, Params.Zc1, rc, rp);
            list.Add(Params.C22);
            //6
            list.Add(Params.Zc1);
            //7
            list.Add(Params.Zp1);
            return list;
        }



        public List<string> PogonieItem(List<double> list)
        {
            var item = new List<string>
            {
                "L11=" + Math.Round(list[0] / Math.Pow(10, -6), 4).ToString(),
                "L12=" + Math.Round(list[1] / Math.Pow(10, -6), 4).ToString(),
                "L22=" + Math.Round(list[2] / Math.Pow(10, -6), 4).ToString(),
                "C11=" + Math.Round(list[3] / Math.Pow(10, -12), 4).ToString(),
                "C12=" + Math.Round(list[4] / Math.Pow(10, -12), 4).ToString(),
                "C22=" + Math.Round(list[5] / Math.Pow(10, -12), 4).ToString()
            };

            return item;
        }

        public List<double> CalculateImpedanceProvodimosti(double rc, double rp, double zc1, double zp1,double z0)
        {
            var list = new List<double>();
            
            var d = _calculator.DForImpedance(rc, rp);
            Params.Z11 = _calculator.Z11(rc, rp, zc1, zp1, d);
            list.Add(Params.Z11);
            Params.Z12 = _calculator.Z12(rc, rp, zc1, zp1, d);
            list.Add(Params.Z12);
            Params.Zm = _calculator.Zm(Params.Z12, z0);
            Params.Z22 = _calculator.Z22(rc, rp, zc1, zp1, d);
            list.Add(Params.Z22);
            Params.Y11 = _calculator.Y11(Params.Z11, Params.Z12, Params.Z22);
            list.Add(Params.Y11);
            Params.Y12 = _calculator.Y12(Params.Zm, Params.Z12, Params.Z22);
            list.Add(Params.Y12);
            Params.Y22 = _calculator.Y22(Params.Z11, Params.Z12, Params.Z22);
            list.Add(Params.Y22);
            return list;
        }

        public List<string> ImpedanceProvodimostiItem(List<double> list)
        {
            var item = new List<string>
            {
                "Z11=" + Math.Round(list[0] / Math.Pow(10, 0), 4).ToString(),
                "Z12=" + Math.Round(list[1] / Math.Pow(10, 0), 4).ToString(),
                "Z22=" + Math.Round(list[2] / Math.Pow(10, 0), 4).ToString(),
                "Y11=" + Math.Round(list[3] / Math.Pow(10, 0), 4).ToString(),
                "Y12=" + Math.Round(list[4] / Math.Pow(10, 0), 4).ToString(),
                "Y22=" + Math.Round(list[5] / Math.Pow(10, 0), 4).ToString()
            };

            return item;
        }

        public List<double> CalculateImpedance(double l11, double c11, double l22, double c22, double zc1,double zp1, double rc, double rp)
        {
            var list = new List<double>();

            Params.Z1 = _calculator.Z1OrZ2(l11, c11);
            list.Add(Params.Z1);
            Params.Z2 = _calculator.Z1OrZ2(l22, c22);
            list.Add(Params.Z2);
            Params.Zc = _calculator.Zc(Params.Z12, Params.Z11, Params.Z22);
            list.Add(Params.Zc);
            Params.Zp = _calculator.Zp(Params.Z12, Params.Z11, Params.Z22);
            list.Add(Params.Zp);
            list.Add(Params.Zc1);
            list.Add(Params.Zp1);
            Params.Zc2 = _calculator.Zc2OrZp2(rc,rp,zc1);
            list.Add(Params.Zc2);
            Params.Zp2 = _calculator.Zc2OrZp2(rc, rp, zp1);
            list.Add(Params.Zp2);
            return list;
        }

        public List<string> ImpedanceItem(List<double> list)
        {
            var item = new List<string>
            {
                "Z1=" + Math.Round(list[0] / Math.Pow(10, 0), 4).ToString(),
                "Z2=" + Math.Round(list[1] / Math.Pow(10, 0), 4).ToString(),
                "Zc=" + Math.Round(list[2] / Math.Pow(10, 0), 4).ToString(),
                "Zp=" + Math.Round(list[3] / Math.Pow(10, 0), 4).ToString(),
                "Zc1=" + Math.Round(list[4] / Math.Pow(10, 0), 4).ToString(),
                "Zp1=" + Math.Round(list[5] / Math.Pow(10, 0), 4).ToString(),
                "Zc2=" + Math.Round(list[6] / Math.Pow(10, 0), 4).ToString(),
                "Zp2=" + Math.Round(list[7] / Math.Pow(10, 0), 4).ToString()
            };

            return item;
        }
    }
}