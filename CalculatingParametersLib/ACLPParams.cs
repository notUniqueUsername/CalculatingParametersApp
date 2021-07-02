using System;

namespace CalculatingParametersLib
{
    public class ACLPParams
    {
        private double _fmin;
        private double _l;
        private double _fmax;
        private double _z2out;
        private double _z1out;
        private double _z2in;
        private double _z1in;
        private int _nf;
        private Params _params = new Params();
        private SetOfParametersEnum _setOfParameters;
        private SetOfShematicEnum _setOfShematic;
        private CalculateFromModal _modalCalculateor = new CalculateFromModal();
        private CalculateFromPogonie _pogonCalculateor =new CalculateFromPogonie();
        private CalculateFromZC1ZC2ZP1ZP2 _zC1ZC2ZP1ZP2Calculateor = new CalculateFromZC1ZC2ZP1ZP2();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startParams">0: L11;1: L22;2: L12;3: C11;4: C22;5: -C12;
        /// 6: fmin;7: fmax;8: l;
        /// 9: z2out;10: z1out;11: z2in;
        /// 12: z1in;13: nf;</param>
        /// <param name="setOfParams">Номер набора параметров начинается с 1, или строка с неазванием параметра</param>
        /// <param name="setOfShematic">Номер набора схемы начинается с 0, или строка с неазванием параметра</param>
        public ACLPParams(double[] startParams, string setOfParams, string setOfShematic)
        {
            if (!Enum.TryParse(setOfParams, out _setOfParameters))
            {
                throw new ArgumentException("Неверный набор параметров");
            }
            if (!Enum.TryParse(setOfShematic, out _setOfShematic))
            {
                throw new ArgumentException("Неверный набор параметров");
            }

            switch (_setOfParameters)
            {
                case SetOfParametersEnum.Pogonie:
                    _params.L11 = startParams[0];
                    _params.L22 = startParams[1];
                    _params.L12 = startParams[2];
                    _params.C11 = startParams[3];
                    _params.C22 = startParams[4];
                    _params.C12 = startParams[5];
                    _params = _pogonCalculateor.Calculate(_params.C11, _params.C12,
                        _params.C22, _params.L11, _params.L12, _params.L22);
                    break;
                case SetOfParametersEnum.Pogonie_pF_nGn:
                    _params.L11 = startParams[0];
                    _params.L22 = startParams[1];
                    _params.L12 = startParams[2];
                    _params.C11 = startParams[3];
                    _params.C22 = startParams[4];
                    _params.C12 = startParams[5];
                    _params = _pogonCalculateor.Calculate(_params.C11, _params.C12,
                        _params.C22, _params.L11, _params.L12, _params.L22);
                    break;
                case SetOfParametersEnum.Modalnie:
                    _params.Z0 = startParams[0];
                    _params.k = startParams[1];
                    _params.Rc = startParams[2];
                    _params.Rp = startParams[3];
                    _params.Erc = startParams[4];
                    _params.Erp = startParams[5];
                    _params = _modalCalculateor.CalculateAll(_params.Z0, _params.k, _params.Rc, _params.Rp, _params.Erc, _params.Erp);
                    break;
                case SetOfParametersEnum.Zc1_Zp1:
                    _params.Zc1 = startParams[0];
                    _params.Zp1 = startParams[1];
                    _params.Rc = startParams[2];
                    _params.Rp = startParams[3];
                    _params.Erc = startParams[4];
                    _params.Erp = startParams[5];
                    _params = _zC1ZC2ZP1ZP2Calculateor.CalculateWithZc1Zp1(_params.Zc1, _params.Zp1, _params.Rc,
                        _params.Rp, _params.Erc, _params.Erp);
                    break;
                case SetOfParametersEnum.Zp1_Zc2:
                    _params.Zc2 = startParams[0];
                    _params.Zp1 = startParams[1];
                    _params.Rc = startParams[2];
                    _params.Rp = startParams[3];
                    _params.Erc = startParams[4];
                    _params.Erp = startParams[5];
                    _params = _zC1ZC2ZP1ZP2Calculateor.CalculateZc2Zp1(_params.Zc2, _params.Zp1,
                        _params.Rc, _params.Rp, _params.Erc, _params.Erp);
                    break;
                case SetOfParametersEnum.Zp1_Zc2_RcOne_RpZero:
                    _params.Zc2 = startParams[0];
                    _params.Zp1 = startParams[1];
                    _params.Rc = startParams[2];
                    _params.Rp = startParams[3];
                    _params.Erc = startParams[4];
                    _params.Erp = startParams[5];
                    _params = _zC1ZC2ZP1ZP2Calculateor.CalculateZc2Zp1(_params.Zc2, _params.Zp1,
                        _params.Rc, _params.Rp, _params.Erc, _params.Erp);
                    break;
                case SetOfParametersEnum.ModalnieSymm:
                    _params.Z0 = startParams[0];
                    _params.k = startParams[1];
                    _params.Rc = startParams[2];
                    _params.Rp = startParams[3];
                    _params.Erc = startParams[4];
                    _params.Erp = startParams[5];
                    _params = _modalCalculateor.CalculateAll(_params.Z0, _params.k, _params.Rc,
                        _params.Rp, _params.Erc, _params.Erp);
                    break;
            }

            _l = startParams[8];
            _fmin = startParams[6];
            _fmax = startParams[7];
            _nf = (int)startParams[13];
            _z1in = startParams[12];
            _z2in = startParams[11];
            switch (_setOfShematic)
            {
                case SetOfShematicEnum.CLike:
                    _z1out = Math.Pow(10, 10);
                    _z2out = Math.Pow(10, 10);
                    break;
                case SetOfShematicEnum.General:
                    _z1out = startParams[10];
                    _z2out = startParams[9];
                    break;
                case SetOfShematicEnum.LineToLine:
                    _z1out = _z1in;
                    _z2out = _z2in;
                    break;
            }
            var sParamData = new CouplLinesInFreqRange(_params, _l, _fmin, _fmax, _nf, _z1in, _z2in, _z1out, _z2out);
            _params.Length = _l;
            _params.FreqRange = sParamData.GetFi();
            _params.Points = _nf;
            _params.SParamMagnitudes = sParamData.GetSParamMagnitude();
            _params.SParamPhases = sParamData.GetSParamPhase();
            _params._z1in = _z1in;
            _params._z1out = _z1out;
            _params._z2in = _z2in;
            _params._z2out = _z2out;

        }

        public Params GetACLPParams()
        {
            return _params;
        }
    }
}