﻿using System;

namespace CalculatingParametersLib
{
    public class CalculateFromPogonie
    {
        public CalculateFromPogonie()
        { }
        private ParametersCalculator _calculator = new ParametersCalculator();
        public void Calculate(double c11, double c12, double c22, double l11, double l12, double l22)
        {
            Params.C11 = c11 * Math.Pow(10,-12);
            Params.C12 = c12 * Math.Pow(10, -12); 
            Params.C22 = c22 * Math.Pow(10, -12); 

            Params.L11 = l11 * Math.Pow(10, -6); 
            Params.L12 = l12 * Math.Pow(10, -6); 
            Params.L22 = l22 * Math.Pow(10, -6); 

            Params.Z1 = _calculator.Z1OrZ2(Params.L11, Params.C11);
            Params.Z2 = _calculator.Z1OrZ2(Params.L11, Params.C11);

            Params.kl = _calculator.Kl(Params.L12, Params.L11, Params.L22);
            Params.kc = _calculator.Kc(Params.C12, Params.C11, Params.C22);
            Params.klc = _calculator.Klc(Params.kl, Params.kc);

            Params.Erc = _calculator.Erc(Params.C11, Params.C12, Params.C22, Params.L11, Params.L12, Params.L22);
            Params.Erp = _calculator.Erp(Params.C11, Params.C12, Params.C22, Params.L11, Params.L12, Params.L22);
            Params.Rp = _calculator.Rp(Params.C11, Params.C12, Params.C22, Params.L11, Params.L12, Params.L22);
            Params.Rc = _calculator.Rc(Params.C11, Params.C12, Params.C22, Params.L11, Params.L12, Params.L22);
            Params.Zc1 = _calculator.Zc1OrZp1(Params.C11, Params.C12, Params.Erc, Params.Rc);
            Params.Zp1 = _calculator.Zc1OrZp1(Params.C11, Params.C12, Params.Erp, Params.Rp);
            Params.Zp2 = _calculator.Zc2OrZp2(Params.Rc, Params.Rp, Params.Zp1);
            Params.Zc2 = _calculator.Zc2OrZp2(Params.Rc, Params.Rp, Params.Zc1);
            Params.Z0 = _calculator.Z0(Params.Zc2, Params.Zp1);
            Params.Z11 = _calculator.Z11(Params.Rc, Params.Rp, Params.Zc1, Params.Zp1,
                _calculator.DForImpedance(Params.Rc, Params.Rp));
            Params.Z12 = _calculator.Z12(Params.Rc, Params.Rp, Params.Zc1, Params.Zp1,
                _calculator.DForImpedance(Params.Rc, Params.Rp));
            Params.Z22 = _calculator.Z22(Params.Rc, Params.Rp, Params.Zc1, Params.Zp1,
                _calculator.DForImpedance(Params.Rc, Params.Rp));
            Params.k = _calculator.K(Params.Z12,Params.Z11,Params.Z22);
            Params.kl = _calculator.Kl(Params.L12, Params.L11, Params.L22);
            Params.kc = _calculator.Kc(Params.C12, Params.C11, Params.C22);
            Params.klc = _calculator.Klc(Params.kl, Params.kc);
            Params.kv = _calculator.Kv(Params.Erc, Params.Erp);
            Params.ke = _calculator.Ke(Params.Erc, Params.Erp);
            Params.m = Math.Sqrt(Params.Erp) / Math.Sqrt(Params.Erc);
            Params.Zm = _calculator.Zm(Params.Z12, Params.Z0);

            Params.Z01 = _calculator.Z01(Params.Rc, Params.Zp1, Params.Rp, Params.Zc1);
            Params.Z02 = _calculator.Z02(Params.Z0, Params.Z01);

            Params.Zc = _calculator.Zc(Params.Z12, Params.Z11, Params.Z22);
            Params.Zp = _calculator.Zp(Params.Z12, Params.Z11, Params.Z22);

            Params.Z2p = _calculator.Z2p(Params.Zc2, Params.Rc, Params.Zp2, Params.Rp);
            Params.Z1p = _calculator.Z1p(Params.Zc2, Params.Rc, Params.Zp2, Params.Rp);
            Params.Z2c = _calculator.Z2с(Params.Z1p, Params.Z0);
            Params.Z1c = _calculator.Z1с(Params.Z2p, Params.Z0);

            Params.S21 = -20 * Math.Log10(Params.k);

            Params.C11 = c11;
            Params.C12 = c12;
            Params.C22 = c22;

            Params.L11 = l11;
            Params.L12 = l12;
            Params.L22 = l22;
        }
    }
}