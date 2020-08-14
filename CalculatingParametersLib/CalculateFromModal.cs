using System;


namespace CalculatingParametersLib
{
    /// <summary>
    /// Калькулятор для расчета из модальных
    /// </summary>
    public class CalculateFromModal
    {
        private Params _currentParams = new Params();

        private ParametersCalculator _calculator = new ParametersCalculator();

        public Params CalculateAll(double z0, double k, double rc, double rp, double erc, double erp)
        {
            _currentParams = new Params();
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

        private void CalculateResistors(double rc, double rp, double zp1, double zp2, double z0, double zc1, double zc2, double z12)
        {
            _currentParams.Z01 = _calculator.Z01(rc,zp1,rp,zc1);

            _currentParams.Z02 = _calculator.Z02(z0, _currentParams.Z01);

            _currentParams.Z1p = _calculator.Z1p(zc2,rc,zp2,rp);

            _currentParams.Z2p = _calculator.Z2p(zc2, rc, zp2 ,rp);

            _currentParams.Rz = _calculator.Rz(_currentParams.Z12, _currentParams.Z22, _currentParams.Z11,
                _currentParams.Rc, _currentParams.Rp);
            //_currentParams.Rz = _calculator.Rz(_currentParams.Z2p, _currentParams.Z1p);

            _currentParams.Z1c = _calculator.Z1с(_currentParams.Z2p,z0);

            _currentParams.Z2c = _calculator.Z2с(_currentParams.Z1p,z0);

            _currentParams.Zm = _calculator.Zm(z12,z0);


        }

        private void CalculateKoeff(double erc, double erp)
        {
            _currentParams.kl = _calculator.Kl(_currentParams.L12, _currentParams.L11, _currentParams.L22);

            _currentParams.kc = _calculator.Kc(_currentParams.C12, _currentParams.C11, _currentParams.C22);

            _currentParams.klc = _calculator.Klc(_currentParams.kl, _currentParams.kc);

            _currentParams.ke = _calculator.Ke(erc,erp);

            _currentParams.kv = _calculator.Kv(erc,erp);

            _currentParams.m = _calculator.M(_currentParams.Erc, _currentParams.Erp);
            //_currentParams.m = Math.Sqrt(_currentParams.Erp) / Math.Sqrt(_currentParams.Erc);

            _currentParams.S21 = -20 * Math.Log10(_currentParams.k);

        }

        private void CalculatePogonnie(double z0, double k, double rc, double rp, double erc, double erp)
        {
            _currentParams.N = _calculator.N(_currentParams.Rc, _currentParams.Rp, _currentParams.k);

            _currentParams.Zok = _calculator.Zok(_currentParams.Z0, _currentParams.k);

            _currentParams.Z11 = _calculator.Z11(_currentParams.Zok, _currentParams.N);

            _currentParams.Z12 = _calculator.Z12(_currentParams.Zok, _currentParams.k);

            _currentParams.Z22 = _calculator.Z22(_currentParams.Zok, _currentParams.N);

            _currentParams.Zp1 = _calculator.Zp1(rc, rp, k, z0);

            _currentParams.Zc1 = _calculator.Zc1(rc, rp, k, z0);
            
            _currentParams.L11 = Math.Round(_calculator.L11(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -6), 4); 
 
            _currentParams.L12 = Math.Round(_calculator.L12(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -6), 4);

            _currentParams.L22 = Math.Round(_calculator.L22(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -6), 4);

            _currentParams.C11 = Math.Round(_calculator.C11(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -12), 3);

            _currentParams.C12 = Math.Round(_calculator.C12(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -12), 3);

            _currentParams.C22 = Math.Round(_calculator.C22(erc, erp, _currentParams.Zp1, _currentParams.Zc1, rc, rp) / Math.Pow(10, -12), 3);

            _currentParams.Q11 = _calculator.Q11(_currentParams.L11, _currentParams.C11, _currentParams.L12, _currentParams.C12);
            _currentParams.Q12 = _calculator.Q12(_currentParams.L11, _currentParams.C22, _currentParams.L12, _currentParams.C12);
            _currentParams.Q21 = _calculator.Q21(_currentParams.L22, _currentParams.C11, _currentParams.L12, _currentParams.C12);
            _currentParams.Q22 = _calculator.Q22(_currentParams.L12, _currentParams.C12, _currentParams.L22, _currentParams.C22);
            _currentParams.D = _calculator.D(_currentParams.Q11, _currentParams.Q12, _currentParams.Q22, _currentParams.Q21);

        }

        private void CalculateImpedanceProvodimosti(double rc, double rp, double zc1, double zp1,double z0)
        {
            var d = _calculator.DForImpedance(rc, rp);

            //_currentParams.Z11 = _calculator.Z11(rc, rp, zc1, zp1, d);

            //_currentParams.Z12 = _calculator.Z12(rc, rp, zc1, zp1, d);

            _currentParams.Zm = _calculator.Zm(_currentParams.Z12, z0);

            //_currentParams.Z22 = _calculator.Z22(rc, rp, zc1, zp1, d);

            _currentParams.Y11 = _calculator.Y11(_currentParams.Z11, _currentParams.Z12, _currentParams.Z22);

            _currentParams.Y12 = _calculator.Y12(_currentParams.Zm, _currentParams.Z12, _currentParams.Z22);

            _currentParams.Y22 = _calculator.Y22(_currentParams.Z11, _currentParams.Z12, _currentParams.Z22);
        }

        private void CalculateImpedance(double l11, double c11, double l22, double c22, double zc1,double zp1, double rc, double rp)
        {
            _currentParams.Z1 = _calculator.Z1OrZ2(_currentParams.L11, _currentParams.C11) * 1000;

            _currentParams.Z2 = _calculator.Z1OrZ2(_currentParams.L22, _currentParams.C22) * 1000;

            _currentParams.Zc = _calculator.Zc(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);

            _currentParams.Zp = _calculator.Zp(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);

            _currentParams.Zc2 = _calculator.Zc2OrZp2(rc,rp,zc1);

            _currentParams.Zp2 = _calculator.Zc2OrZp2(rc, rp, zp1);
        }

    }
}