﻿using System;

namespace CalculatingParametersLib
{
    /// <summary>
    /// Калькулятор для расчета из погонных
    /// </summary>
    public class CalculateFromPogonie
    {
        private Params _currentParams = new Params();
        private ParametersCalculator _calculator = new ParametersCalculator();
        public Params Calculate(double c11, double c12, double c22, double l11, double l12, double l22)
        {
            _currentParams = new Params();
            _currentParams.C11 = c11 * Math.Pow(10, -12);
            _currentParams.C12 = c12 * Math.Pow(10, -12); 
            _currentParams.C22 = c22 * Math.Pow(10, -12); 

            _currentParams.L11 = l11 * Math.Pow(10, -6); 
            _currentParams.L12 = l12 * Math.Pow(10, -6); 
            _currentParams.L22 = l22 * Math.Pow(10, -6); 

            _currentParams.Z1 = _calculator.Z1OrZ2(_currentParams.L11, _currentParams.C11);
            _currentParams.Z2 = _calculator.Z1OrZ2(_currentParams.L22, _currentParams.C22);

            _currentParams.kl = _calculator.Kl(_currentParams.L12, _currentParams.L11, _currentParams.L22);
            _currentParams.kc = _calculator.Kc(_currentParams.C12, _currentParams.C11, _currentParams.C22);
            _currentParams.klc = _calculator.Klc(_currentParams.kl, _currentParams.kc);

            _currentParams.Q11 = _calculator.Q11(_currentParams.L11, _currentParams.C11, _currentParams.L12, _currentParams.C12);
            _currentParams.Q12 = _calculator.Q12(_currentParams.L11, _currentParams.C22, _currentParams.L12, _currentParams.C12);
            _currentParams.Q21 = _calculator.Q21(_currentParams.L22, _currentParams.C11, _currentParams.L12, _currentParams.C12);
            _currentParams.Q22 = _calculator.Q22(_currentParams.L12, _currentParams.C12, _currentParams.L22, _currentParams.C22);
            _currentParams.D = _calculator.D(_currentParams.Q11,_currentParams.Q12,_currentParams.Q22,_currentParams.Q21);

            #region Rp_Rc_Erc_Erp_Calculate

            _currentParams.Rp = _calculator.Rp(_currentParams.Q11, _currentParams.Q22, _currentParams.D, _currentParams.Q12);
            _currentParams.Rc = _calculator.Rc(_currentParams.Q11, _currentParams.Q22, _currentParams.D, _currentParams.Q12);
            _currentParams.RpRcCheck();
            _currentParams.Erc = _calculator.Erc(_currentParams.Q11, _currentParams.Q22, _currentParams.D);
            _currentParams.Erp = _calculator.Erp(_currentParams.Q11, _currentParams.Q22, _currentParams.D);

            #endregion

            _currentParams.Zc1 = _calculator.Zc1OrZp1(_currentParams.C11, _currentParams.C12, _currentParams.Erc, _currentParams.Rc);
            _currentParams.Zp1 = _calculator.Zc1OrZp1(_currentParams.C11, _currentParams.C12, _currentParams.Erp, _currentParams.Rp);
            _currentParams.Zp2 = _calculator.Zc2OrZp2(_currentParams.Rc, _currentParams.Rp, _currentParams.Zp1);
            _currentParams.Zc2 = _calculator.Zc2OrZp2(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1);
            _currentParams.Z0 = _calculator.Z0(_currentParams.Zc2, _currentParams.Zp1);

            //#region NewFormulsUse

            //_currentParams.N = _calculator.N(_currentParams.Rc, _currentParams.Rp, _currentParams.k);

            //_currentParams.Rz = _calculator.Rz(_currentParams.Z12, _currentParams.Z22, _currentParams.Z11,
            //    _currentParams.Rc, _currentParams.Rp);

            //_currentParams.k = _calculator.K(_currentParams.Rz, _currentParams.N);

            //_currentParams.Zok = _calculator.Zok(_currentParams.Z0, _currentParams.k);

            //_currentParams.Z11 = _calculator.Z11(_currentParams.Zok, _currentParams.N);

            //_currentParams.Z12 = _calculator.Z12(_currentParams.Zok, _currentParams.k);

            //_currentParams.Z22 = _calculator.Z22(_currentParams.Zok, _currentParams.N);

            
            //_currentParams.Zp1 = _calculator.Zp1(_currentParams.Z11, _currentParams.Z12, _currentParams.Rc);

            //_currentParams.Zc1 = _calculator.Zc1(_currentParams.Z11, _currentParams.Z12, _currentParams.Rp);

            //#endregion

            _currentParams.Z11 = _calculator.Z11(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.Z12 = _calculator.Z12(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.Z22 = _calculator.Z22(_currentParams.Rc, _currentParams.Rp, _currentParams.Zc1, _currentParams.Zp1,
                _calculator.DForImpedance(_currentParams.Rc, _currentParams.Rp));
            _currentParams.k = _calculator.K(_currentParams.Z12,_currentParams.Z11,_currentParams.Z22);

            //_currentParams.N = _calculator.N(_currentParams.Rc, _currentParams.Rp, _currentParams.k, _currentParams.RzNegativeStatus);
            _currentParams.N = _calculator.N(_currentParams.Z11, _currentParams.Z22);

            _currentParams.kl = _calculator.Kl(_currentParams.L12, _currentParams.L11, _currentParams.L22);
            _currentParams.kc = _calculator.Kc(_currentParams.C12, _currentParams.C11, _currentParams.C22);
            _currentParams.klc = _calculator.Klc(_currentParams.kl, _currentParams.kc);
            _currentParams.kv = _calculator.Kv(_currentParams.Erc, _currentParams.Erp);
            _currentParams.ke = _calculator.Ke(_currentParams.Erc, _currentParams.Erp);
            _currentParams.m = _calculator.M(_currentParams.Erc, _currentParams.Erp);
            //_currentParams.m = Math.Sqrt(_currentParams.Erp) / Math.Sqrt(_currentParams.Erc);
            _currentParams.Zm = _calculator.Zm(_currentParams.Z12, _currentParams.Z0);

            _currentParams.Z01 = _calculator.Z01(_currentParams.Rc, _currentParams.Zp1, _currentParams.Rp, _currentParams.Zc1);
            _currentParams.Z02 = _calculator.Z02(_currentParams.Z0, _currentParams.Z01);

            _currentParams.Zc = _calculator.Zc(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);
            _currentParams.Zp = _calculator.Zp(_currentParams.Z12, _currentParams.Z11, _currentParams.Z22);

            _currentParams.Z2p = _calculator.Z2p(_currentParams.Zc2, _currentParams.Rc, _currentParams.Zp2, _currentParams.Rp);
            _currentParams.Z1p = _calculator.Z1p(_currentParams.Zc2, _currentParams.Rc, _currentParams.Zp2, _currentParams.Rp);
            _currentParams.Rz = _calculator.Rz(_currentParams.Z2p, _currentParams.Z1p);
            _currentParams.Z2c = _calculator.Z2с(_currentParams.Z1p, _currentParams.Z0);
            _currentParams.Z1c = _calculator.Z1с(_currentParams.Z2p, _currentParams.Z0);

            _currentParams.EEE = _calculator.EEE(_currentParams.Erp, _currentParams.Erc);

            _currentParams.S21 = _calculator.S21(_currentParams.k);

            _currentParams.C11 = c11;
            _currentParams.C12 = c12;
            _currentParams.C22 = c22;

            _currentParams.L11 = l11;
            _currentParams.L12 = l12;
            _currentParams.L22 = l22;

            _currentParams.Emax = _calculator.Mmax(_currentParams.Rc, _currentParams.Rp, _currentParams.Erc,
                _currentParams.Erp, _currentParams.Zc1, _currentParams.Zp1);

            return _currentParams;
        }
    }
}