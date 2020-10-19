using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CalculatingParametersLib
{
    public static class ParamFileSaveLoader
    {
        public static void Save(string fileName, Params currentParams)
        {
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                file.WriteLine("C11, pF/m=" + currentParams.C11.ToString());
                file.WriteLine("C22, pF/m=" + currentParams.C22.ToString());
                file.WriteLine("C12, pF/m=" + currentParams.C12.ToString());
                file.WriteLine("Z0, Ω=" + currentParams.Z0.ToString());
                file.WriteLine("k=" + currentParams.k.ToString());
                file.WriteLine("Rc=" + currentParams.Rc.ToString());
                file.WriteLine("Rп=" + currentParams.Rp.ToString());
                file.WriteLine("Erc=" + currentParams.Erc.ToString());
                file.WriteLine("Erп=" + currentParams.Erp.ToString());
                file.WriteLine("Zc, Ω=" + currentParams.Zc.ToString());
                file.WriteLine("Zп, Ω=" + currentParams.Zp.ToString());
                file.WriteLine("Z1, Ω=" + currentParams.Z1.ToString());
                file.WriteLine("Z2, Ω=" + currentParams.Z2.ToString());
                file.WriteLine("n=" + currentParams.N.ToString());
                file.WriteLine("Rz=" + currentParams.Rz.ToString());
                file.WriteLine("Z1c, Ω=" + currentParams.Z1c.ToString());
                file.WriteLine("Z2c, Ω=" + currentParams.Z2c.ToString());
                file.WriteLine("Zm, Ω=" + currentParams.Zm.ToString());
                file.WriteLine("S21, dB=" + currentParams.S21.ToString());

                file.WriteLine("L11, μH/m=" + currentParams.L11.ToString());
                file.WriteLine("L22, μH/m=" + currentParams.L22.ToString());
                file.WriteLine("L12, μH/m=" + currentParams.L12.ToString());
                file.WriteLine("kl=" + currentParams.kl.ToString());
                file.WriteLine("kc=" + currentParams.kc.ToString());
                file.WriteLine("klc=" + currentParams.klc.ToString());
                file.WriteLine("kε=" + currentParams.ke.ToString());
                file.WriteLine("m=" + currentParams.m.ToString());
                file.WriteLine("Erп/Erc=" + currentParams.EEE.ToString());
                file.WriteLine("Zc1, Ω=" + currentParams.Zc1.ToString());
                file.WriteLine("Zп1, Ω=" + currentParams.Zp1.ToString());
                file.WriteLine("Zc2, Ω=" + currentParams.Zc2.ToString());
                file.WriteLine("Zп2, Ω=" + currentParams.Zp2.ToString());
                file.WriteLine("Z11, Ω=" + currentParams.Z11.ToString());
                file.WriteLine("Z22, Ω=" + currentParams.Z22.ToString());
                file.WriteLine("Z1п, Ω=" + currentParams.Z1p.ToString());
                file.WriteLine("Z2п, Ω=" + currentParams.Z2p.ToString());
                file.WriteLine("Z12, Ω=" + currentParams.Z12.ToString());
                file.WriteLine("Result=" + currentParams.Result.ToString());
            }
        }
    }
}
