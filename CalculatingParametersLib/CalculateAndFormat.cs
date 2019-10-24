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
            var z01 = _calculator.Z01(rc,zp1,rp,zc1);
            list.Add(z01);
            var z02 = _calculator.Z02(rc,zp2,rp,zc2);
            list.Add(z02);
            var z1p = _calculator.Z1p(zc2,rc,zp2,rp);
            list.Add(z1p);
            var z2p = _calculator.Z2p(zc2, rc, zp2 ,rp);
            list.Add(z2p);
            var z1c = _calculator.Z1с(z2p,z0);
            list.Add(z1c);
            var z2c = _calculator.Z2с(z1p,z0);
            list.Add(z2c);
            var zm = _calculator.Zm(z12,z0);
            list.Add(zm);
            
            list.Add(z12);

            return list;
        }

        public List<string> ResistorsItem(List<double> list)
        {
            var item = new List<string>();
            item.Add("Z01=" + Math.Round(list[0] / Math.Pow(10, 0), 1).ToString());
            item.Add("Z02=" + Math.Round(list[1] / Math.Pow(10, 0), 1).ToString());
            item.Add("Z1c=" + Math.Round(list[4] / Math.Pow(10, 0), 1).ToString());
            item.Add("Z2c=" + Math.Round(list[5] / Math.Pow(10, 0), 1).ToString());
            item.Add("Zm=" + Math.Round(list[6] / Math.Pow(10, 0), 1).ToString());
            item.Add("Z1p=" + Math.Round(list[2] / Math.Pow(10, 0), 1).ToString());
            item.Add("Z2p=" + Math.Round(list[3] / Math.Pow(10, 0), 1).ToString());
            item.Add("Z12=" + Math.Round(list[7] / Math.Pow(10, 0), 1).ToString());
            return item;
        }

        public List<double> CalculateKoeff(List<double> pogonie, double erc, double erp)
        {
            var list = new List<double>();
            var kl = _calculator.Kl(pogonie[1], pogonie[0], pogonie[2]);
            list.Add(kl);
            var kc = _calculator.Kc(pogonie[4], pogonie[3], pogonie[5]);
            list.Add(kc);
            var klc = _calculator.Klc(kl,kc);
            list.Add(klc);
            var ke = _calculator.Ke(erc,erp);
            list.Add(ke);
            var kv = _calculator.Kv(erc,erp);
            list.Add(kv);
            return list;
        }

        public List<string> KoeffItem(List<double> list)
        {
            var item = new List<string>();
            item.Add("Kl=" + Math.Round(list[0] / Math.Pow(10, 0), 3).ToString());
            item.Add("Kc=" + Math.Round(list[1] / Math.Pow(10, 0), 3).ToString());
            item.Add("Klc=" + Math.Round(list[2] / Math.Pow(10, 0), 3).ToString());
            item.Add("Ke=" + Math.Round(list[3] / Math.Pow(10, 0), 3).ToString());
            item.Add("Kv=" + Math.Round(list[4] / Math.Pow(10, 0), 3).ToString());

            return item;
        }

        public List<double> CalculatePogonnie(double z0, double k, double rc, double rp, double erc, double erp)
        {
            var list = new List<double>();
            var zp1 = _calculator.Zp1(rc, rp, k, z0);
            var zc1 = _calculator.Zc1(rc, rp, k, z0);
            var l11 = _calculator.L11(erc, erp, zp1, zc1, rc, rp);
            list.Add(l11);
            var l12 = _calculator.L12(erc, erp, zp1, zc1, rc, rp);
            list.Add(l12);
            var l22 = _calculator.L22(erc, erp, zp1, zc1, rc, rp);
            list.Add(l22);
            
            var c11 = _calculator.C11(erc, erp, zp1, zc1, rc, rp);
            list.Add(c11);
            var c12 = _calculator.C12(erc, erp, zp1, zc1, rc, rp);
            list.Add(c12);
            var c22 = _calculator.C22(erc, erp, zp1, zc1, rc, rp);
            list.Add(c22);
            //6
            list.Add(zc1);
            //7
            list.Add(zp1);
            return list;
        }



        public List<string> PogonieItem(List<double> list)
        {
            var item = new List<string>();
            item.Add("L11=" + Math.Round(list[0] / Math.Pow(10,-6),4).ToString());
            item.Add("L12=" + Math.Round(list[1] / Math.Pow(10, -6), 4).ToString());
            item.Add("L22=" + Math.Round(list[2] / Math.Pow(10, -6), 4).ToString());
            item.Add("C11=" + Math.Round(list[3] / Math.Pow(10, -12), 4).ToString());
            item.Add("C12=" + Math.Round(list[4] / Math.Pow(10, -12), 4).ToString());
            item.Add("C22=" + Math.Round(list[5] / Math.Pow(10, -12), 4).ToString());
            
            return item;
        }

        public List<double> CalculateImpedanceProvodimosti(double rc, double rp, double zc1, double zp1,double z0)
        {
            var list = new List<double>();
            
            var d = _calculator.DForImpedance(rc, rp);
            var z11 = _calculator.Z11(rc, rp, zc1, zp1, d);
            list.Add(z11);
            var z12 = _calculator.Z12(rc, rp, zc1, zp1, d);
            list.Add(z12);
            var zm = _calculator.Zm(z12, z0);
            var z22 = _calculator.Z22(rc, rp, zc1, zp1, d);
            list.Add(z22);
            var y11 = _calculator.Y11(z11, z12, z22);
            list.Add(y11);
            var y12 = _calculator.Y12(zm, z12, z22);
            list.Add(y12);
            var y22 = _calculator.Y22(z11, z12, z22);
            list.Add(y22);
            return list;
        }

        public List<string> ImpedanceProvodimostiItem(List<double> list)
        {
               var item = new List<string>();
            item.Add("Z11=" + Math.Round(list[0] / Math.Pow(10, 0), 4).ToString());
            item.Add("Z12=" + Math.Round(list[1] / Math.Pow(10, 0), 4).ToString());
            item.Add("Z22=" + Math.Round(list[2] / Math.Pow(10, 0), 4).ToString());
            item.Add("Y11=" + Math.Round(list[3] / Math.Pow(10, 0), 4).ToString());
            item.Add("Y12=" + Math.Round(list[4] / Math.Pow(10, 0), 4).ToString());
            item.Add("Y22=" + Math.Round(list[5] / Math.Pow(10, 0), 4).ToString());

            return item;
        }

        public List<double> CalculateImpedance(double l11, double c11, double l22, double c22, double zc1,double zp1, double rc, double rp, List<double> listWithZ11Z12Z22)
        {
            var list = new List<double>();

            var z1 = _calculator.Z1OrZ2(l11, c11);
            list.Add(z1);
            var z2 = _calculator.Z1OrZ2(l22, c22);
            list.Add(z2);
            var zc = _calculator.Zc(listWithZ11Z12Z22[1], listWithZ11Z12Z22[0], listWithZ11Z12Z22[2]);
            list.Add(zc);
            var zp = _calculator.Zp(listWithZ11Z12Z22[1], listWithZ11Z12Z22[0], listWithZ11Z12Z22[2]);
            list.Add(zp);
            list.Add(zc1);
            list.Add(zp1);
            var zc2 = _calculator.Zc2OrZp2(rc,rp,zc1);
            list.Add(zc2);
            var zp2 = _calculator.Zc2OrZp2(rc, rp, zp1);
            list.Add(zp2);
            return list;
        }

        public List<string> ImpedanceItem(List<double> list)
        {
            var item = new List<string>();
            item.Add("Z1=" + Math.Round(list[0] / Math.Pow(10, 0), 4).ToString());
            item.Add("Z2=" + Math.Round(list[1] / Math.Pow(10, 0), 4).ToString());
            item.Add("Zc=" + Math.Round(list[2] / Math.Pow(10, 0), 4).ToString());
            item.Add("Zp=" + Math.Round(list[3] / Math.Pow(10, 0), 4).ToString());
            item.Add("Zc1=" + Math.Round(list[4] / Math.Pow(10, 0), 4).ToString());
            item.Add("Zp1=" + Math.Round(list[5] / Math.Pow(10, 0), 4).ToString());
            item.Add("Zc2=" + Math.Round(list[6] / Math.Pow(10, 0), 4).ToString());
            item.Add("Zp2=" + Math.Round(list[7] / Math.Pow(10, 0), 4).ToString());

            return item;
        }
    }
}