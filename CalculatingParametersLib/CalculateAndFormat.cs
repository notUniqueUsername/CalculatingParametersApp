using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CalculatingParametersLib
{
    public class CalculateAndFormat
    {
        private Params1 _currentParams = new Params1();

        private ParametersCalculator _calculator = new ParametersCalculator();

        public Params1 CalculateAll(double z0, double k, double rc, double rp, double erc, double erp)
        {
            _currentParams = new Params1();
            _currentParams.Z0 = z0;
            _currentParams.k = k;
            _currentParams.Rc = rc;
            _currentParams.Rp = rp;
            _currentParams.Erc = erc;
            _currentParams.Erp = erp;
            CalculatePogonnie(_currentParams.Z0, _currentParams.k, _currentParams.Rc, _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

            CalculateImpedanceProvodimosti(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1, _currentParams.Z0);

            CalculateImpedance(_currentParams.L11, _currentParams.C11, _currentParams.L22, _currentParams.C22, _currentParams.Zc1, _currentParams.Zp1, _currentParams.Rc, _currentParams.Rp);

            CalculateKoeff(_currentParams.Erc, _currentParams.Erp);

            CalculateResistors(_currentParams.Rc, _currentParams.Rp, _currentParams.Zp1, _currentParams.Zp2, _currentParams.Z0, _currentParams.Zc1, _currentParams.Zc2, _currentParams.Z12);

            return _currentParams;
        }

        public List<double> CalculateResistors(double rc, double rp, double zp1, double zp2, double z0, double zc1, double zc2, double z12)
        {
            var list = new List<double>();
            _currentParams.Z01 = _calculator.Z01(rc,zp1,rp,zc1);
            list.Add(_currentParams.Z01);
            _currentParams.Z02 = _calculator.Z02(z0, _currentParams.Z01);
            list.Add(_currentParams.Z02);
            _currentParams.Z1p = _calculator.Z1p(zc2,rc,zp2,rp);
            list.Add(_currentParams.Z1p);
            _currentParams.Z2p = _calculator.Z2p(zc2, rc, zp2 ,rp);
            list.Add(_currentParams.Z2p);
            _currentParams.Z1c = _calculator.Z1с(_currentParams.Z2p,z0);
            list.Add(_currentParams.Z1c);
            _currentParams.Z2c = _calculator.Z2с(_currentParams.Z1p,z0);
            list.Add(_currentParams.Z2c);
            _currentParams.Zm = _calculator.Zm(z12,z0);
            list.Add(_currentParams.Zm);
            
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
            _currentParams.kl = _calculator.Kl(_currentParams.L12, _currentParams.L11, _currentParams.L22);
            list.Add(_currentParams.kl);
            _currentParams.kc = _calculator.Kc(_currentParams.C12, _currentParams.C11, _currentParams.C22);
            list.Add(_currentParams.kc);
            _currentParams.klc = _calculator.Klc(_currentParams.kl, _currentParams.kc);
            list.Add(_currentParams.klc);
            _currentParams.ke = _calculator.Ke(erc,erp);
            list.Add(_currentParams.ke);
            _currentParams.kv = _calculator.Kv(erc,erp);
            list.Add(_currentParams.kv);
            _currentParams.m = Math.Sqrt(_currentParams.Erp)/ Math.Sqrt(_currentParams.Erc);
            _currentParams.S21 = -20 * Math.Log10(_currentParams.k);
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
            _currentParams.Zp1 = _calculator.Zp1(rc, rp, k, z0);
            _currentParams.Zc1 = _calculator.Zc1(rc, rp, k, z0);
            
            _currentParams.L11 = Math.Round(_calculator.L11(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -6), 3); 
            list.Add(_currentParams.L11);
            _currentParams.L12 = Math.Round(_calculator.L12(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -6), 3);
            list.Add(_currentParams.L12);
            _currentParams.L22 = Math.Round(_calculator.L22(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -6), 3);
            list.Add(_currentParams.L22);

            _currentParams.C11 = Math.Round(_calculator.C11(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -12), 3);
            list.Add(_currentParams.C11);
            _currentParams.C12 = Math.Round(_calculator.C12(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -12), 3);
            list.Add(_currentParams.C12);
            _currentParams.C22 = Math.Round(_calculator.C22(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -12), 3);
            list.Add(_currentParams.C22);
            //6
            list.Add(_currentParams.Zc1);
            //7
            list.Add(_currentParams.Zp1);
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
            _currentParams.Z11 = _calculator.Z11(rc, rp, zc1, zp1, d);
            list.Add(_currentParams.Z11);
            _currentParams.Z12 = _calculator.Z12(rc, rp, zc1, zp1, d);
            list.Add(_currentParams.Z12);
            _currentParams.Zm = _calculator.Zm(_currentParams.Z12, z0);
            _currentParams.Z22 = _calculator.Z22(rc, rp, zc1, zp1, d);
            list.Add(_currentParams.Z22);
            _currentParams.Y11 = _calculator.Y11(_currentParams.Z11, _currentParams.Z12, _currentParams.Z22);
            list.Add(_currentParams.Y11);
            _currentParams.Y12 = _calculator.Y12(_currentParams.Zm, _currentParams.Z12, _currentParams.Z22);
            list.Add(_currentParams.Y12);
            _currentParams.Y22 = _calculator.Y22(_currentParams.Z11, _currentParams.Z12, _currentParams.Z22);
            list.Add(_currentParams.Y22);
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

            _currentParams.Z1 = _calculator.Z1OrZ2(_currentParams.L11, _currentParams.C11) * 1000;
            list.Add(_currentParams.Z1);
            _currentParams.Z2 = _calculator.Z1OrZ2(_currentParams.L22, _currentParams.C22) * 1000;
            list.Add(_currentParams.Z2);
            _currentParams.Zc = _calculator.Zc(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);
            list.Add(_currentParams.Zc);
            _currentParams.Zp = _calculator.Zp(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);
            list.Add(_currentParams.Zp);
            list.Add(_currentParams.Zc1);
            list.Add(_currentParams.Zp1);
            _currentParams.Zc2 = _calculator.Zc2OrZp2(rc,rp,zc1);
            list.Add(_currentParams.Zc2);
            _currentParams.Zp2 = _calculator.Zc2OrZp2(rc, rp, zp1);
            list.Add(_currentParams.Zp2);
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