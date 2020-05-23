using System;

namespace CalculatingParametersLib
{
    public class CalculateFromZC1ZC2ZP1ZP2
    {
        private Params1 _currentParams = new Params1();
        public CalculateFromZC1ZC2ZP1ZP2()
        { }
        private ParametersCalculator _calculator = new ParametersCalculator();
        public Params1 CalculateWithZc1Zp1(double zc1, double zp1, double rc, double rp, double erc, double erp)
        {
            _currentParams = new Params1();
            _currentParams.Zc1 = zc1;
            _currentParams.Zp1 = zp1;
            _currentParams.Erc = erc;
            _currentParams.Erp = erp;
            _currentParams.Rp = rp;
            _currentParams.Rc = rc;
            _currentParams.Zp2 = _calculator.Zc2OrZp2(_currentParams.Rc, _currentParams.Rp, _currentParams.Zp1);
            _currentParams.Zc2 = _calculator.Zc2OrZp2(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1);
            _currentParams.C11 = _calculator.C11(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.C12 = _calculator.C12(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.C22 = _calculator.C22(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.L11 = _calculator.L11(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.L12 = _calculator.L12(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.L22 = _calculator.L22(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);


            _currentParams.kl = _calculator.Kl(_currentParams.L12, _currentParams.L11, _currentParams.L22);
            _currentParams.kc = _calculator.Kc(_currentParams.C12, _currentParams.C11, _currentParams.C22);
            _currentParams.klc = _calculator.Klc(_currentParams.kl, _currentParams.kc);

            _currentParams.Erc = _calculator.Erc(_currentParams.C11, _currentParams.C12, _currentParams.C22, _currentParams.L11, _currentParams.L12, _currentParams.L22);
            _currentParams.Erp = _calculator.Erp(_currentParams.C11, _currentParams.C12, _currentParams.C22, _currentParams.L11, _currentParams.L12, _currentParams.L22);
            _currentParams.Rp = _calculator.Rp(_currentParams.C11, _currentParams.C12, _currentParams.C22, _currentParams.L11, _currentParams.L12, _currentParams.L22);
            _currentParams.Rc = _calculator.Rc(_currentParams.C11, _currentParams.C12, _currentParams.C22, _currentParams.L11, _currentParams.L12, _currentParams.L22);
            _currentParams.Zc1 = _calculator.Zc1OrZp1(_currentParams.C11, _currentParams.C12, _currentParams.Erc, _currentParams.Rc);
            _currentParams.Zp1 = _calculator.Zc1OrZp1(_currentParams.C11, _currentParams.C12, _currentParams.Erp, _currentParams.Rp);
            _currentParams.Zp2 = _calculator.Zc2OrZp2(_currentParams.Rc, _currentParams.Rp, _currentParams.Zp1);
            _currentParams.Zc2 = _calculator.Zc2OrZp2(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1);
            _currentParams.Z0 = _calculator.Z0(_currentParams.Zc2, _currentParams.Zp1);
            _currentParams.Z11 = _calculator.Z11(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.Z12 = _calculator.Z12(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.Z22 = _calculator.Z22(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.k = _calculator.K(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);
            _currentParams.kl = _calculator.Kl(_currentParams.L12, _currentParams.L11, _currentParams.L22);
            _currentParams.kc = _calculator.Kc(_currentParams.C12, _currentParams.C11, _currentParams.C22);
            _currentParams.klc = _calculator.Klc(_currentParams.kl, _currentParams.kc);
            _currentParams.kv = _calculator.Kv(_currentParams.Erc, _currentParams.Erp);
            _currentParams.ke = _calculator.Ke(_currentParams.Erc, _currentParams.Erp);
            _currentParams.m = Math.Sqrt(_currentParams.Erp) / Math.Sqrt(_currentParams.Erc);
            _currentParams.Zm = _calculator.Zm(_currentParams.Z12, _currentParams.Z0);

            _currentParams.Z01 = _calculator.Z01(_currentParams.Rc, _currentParams.Zp1, _currentParams.Rp, _currentParams.Zc1);
            _currentParams.Z02 = _calculator.Z02(_currentParams.Z0, _currentParams.Z01);

            _currentParams.Zc = _calculator.Zc(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);
            _currentParams.Zp = _calculator.Zp(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);

            _currentParams.Z2p = _calculator.Z2p(_currentParams.Zc2, _currentParams.Rc, _currentParams.Zp2, _currentParams.Rp);
            _currentParams.Z1p = _calculator.Z1p(_currentParams.Zc2, _currentParams.Rc, _currentParams.Zp2, _currentParams.Rp);
            _currentParams.Z2c = _calculator.Z2с(_currentParams.Z1p, _currentParams.Z0);
            _currentParams.Z1c = _calculator.Z1с(_currentParams.Z2p, _currentParams.Z0);

            _currentParams.S21 = -20 * Math.Log10(_currentParams.k);

            _currentParams.C11 = Math.Round(
                _currentParams.C11 *
                Math.Pow(10, 12), 3);
            _currentParams.L11 = Math.Round(
                _calculator.L11(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                Math.Pow(10, 6), 3);
            _currentParams.C22 = Math.Round(
                _calculator.C22(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                Math.Pow(10, 12), 3);
            _currentParams.L22 =
                Math.Round(
                    _calculator.L22(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                    Math.Pow(10, 6), 3);
            _currentParams.C12 = Math.Round(
                _calculator.C12(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                Math.Pow(10, 12), 3);
            _currentParams.L12 = Math.Round(
                _calculator.L12(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                Math.Pow(10, 6), 3);
            _currentParams.Z1 = _calculator.Z1OrZ2(_currentParams.L11, _currentParams.C11) * 1000;
            _currentParams.Z2 = _calculator.Z1OrZ2(_currentParams.L22, _currentParams.C22) * 1000;
            return _currentParams;
        }
        public Params1 CalculateZc2Zp1(double zc2, double zp1, double rc, double rp, double erc, double erp)
        {
            _currentParams = new Params1();
            _currentParams.Zc2 = zc2;
            _currentParams.Zp1 = zp1;
            _currentParams.Erc = erc;
            _currentParams.Erp = erp;
            _currentParams.Rp = rp;
            _currentParams.Rc = rc;
            _currentParams.Zp2 = _calculator.Zc2OrZp2(_currentParams.Rc, _currentParams.Rp, _currentParams.Zp1);
            _currentParams.Zc1 = _currentParams.Zc2 / (-_currentParams.Rc * _currentParams.Rp);
            _currentParams.C11 = _calculator.C11(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1,_currentParams.Rc,_currentParams.Rp);
            _currentParams.C12 = _calculator.C12(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.C22 = _calculator.C22(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.L11 = _calculator.L11(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.L12 = _calculator.L12(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);
            _currentParams.L22 = _calculator.L22(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp);


            _currentParams.kl = _calculator.Kl(_currentParams.L12, _currentParams.L11, _currentParams.L22);
            _currentParams.kc = _calculator.Kc(_currentParams.C12, _currentParams.C11, _currentParams.C22);
            _currentParams.klc = _calculator.Klc(_currentParams.kl, _currentParams.kc);

            
            
            
            
            
            
            _currentParams.Z0 = _calculator.Z0(_currentParams.Zc2, _currentParams.Zp1);
            _currentParams.Z11 = _calculator.Z11(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.Z12 = _calculator.Z12(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.Z22 = _calculator.Z22(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.k = _calculator.K(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);
            _currentParams.kl = _calculator.Kl(_currentParams.L12, _currentParams.L11, _currentParams.L22);
            _currentParams.kc = _calculator.Kc(_currentParams.C12, _currentParams.C11, _currentParams.C22);
            _currentParams.klc = _calculator.Klc(_currentParams.kl, _currentParams.kc);
            _currentParams.kv = _calculator.Kv(_currentParams.Erc, _currentParams.Erp);
            _currentParams.ke = _calculator.Ke(_currentParams.Erc, _currentParams.Erp);
            _currentParams.m = Math.Sqrt(_currentParams.Erp) / Math.Sqrt(_currentParams.Erc);
            _currentParams.Zm = _calculator.Zm(_currentParams.Z12, _currentParams.Z0);

            _currentParams.Z01 = _calculator.Z01(_currentParams.Rc, _currentParams.Zp1, _currentParams.Rp, _currentParams.Zc1);
            _currentParams.Z02 = _calculator.Z02(_currentParams.Z0, _currentParams.Z01);

            _currentParams.Zc = _calculator.Zc(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);
            _currentParams.Zp = _calculator.Zp(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);

            _currentParams.Z2p = _calculator.Z2p(_currentParams.Zc2, _currentParams.Rc, _currentParams.Zp2, _currentParams.Rp);
            _currentParams.Z1p = _calculator.Z1p(_currentParams.Zc2, _currentParams.Rc, _currentParams.Zp2, _currentParams.Rp);
            _currentParams.Z2c = _calculator.Z2с(_currentParams.Z1p, _currentParams.Z0);
            _currentParams.Z1c = _calculator.Z1с(_currentParams.Z2p, _currentParams.Z0);

            _currentParams.S21 = -20 * Math.Log10(_currentParams.k);
            _currentParams.Z1 = _calculator.Z1OrZ2(_currentParams.L11, _currentParams.C11);
            _currentParams.Z2 = _calculator.Z1OrZ2(_currentParams.L22, _currentParams.C22);
            _currentParams.C11 = Math.Round(
                _currentParams.C11 *
                Math.Pow(10, 12), 3);
            _currentParams.L11 = Math.Round(
                _calculator.L11(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                Math.Pow(10, 6), 3);
            _currentParams.C22 = Math.Round(
                _calculator.C22(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                Math.Pow(10, 12), 3);
            _currentParams.L22 =
                Math.Round(
                    _calculator.L22(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                    Math.Pow(10, 6), 3);
            _currentParams.C12 = Math.Round(
                _calculator.C12(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                Math.Pow(10, 12), 3);
            _currentParams.L12 = Math.Round(
                _calculator.L12(_currentParams.Erc, _currentParams.Erp, _currentParams.Zp1, _currentParams.Zc1, _currentParams.Rc, _currentParams.Rp) *
                Math.Pow(10, 6), 3);

            return _currentParams;

        }
    }
}