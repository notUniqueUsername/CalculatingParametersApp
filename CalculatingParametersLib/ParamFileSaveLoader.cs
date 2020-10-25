using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;

namespace CalculatingParametersLib
{
    public static class ParamFileSaveLoader
    {
        public static SortedList<string, string> Load(string fileName)
        {
            var loadedParams = new SortedList<string, string>();
            string line;
            var c11 = "";
            var c22 = "";
            var c12 = "";
            var l11 = "";
            var l22 = "";
            var l12 = "";
            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    var i = 0;
                    if (line.Contains("C11, pF/m="))
                    {
                        var index = line.IndexOf('=');
                        c11 = line.Substring(index + 1);
                        i++;
                    }

                    if (line.Contains("C22, pF/m="))
                    {
                        var index = line.IndexOf('=');
                        c22 = line.Substring(index + 1);
                        i++;
                    }

                    if (line.Contains("C12, pF/m="))
                    {
                        var index = line.IndexOf('=');
                        c12 = line.Substring(index + 1);
                        i++;
                    }

                    if (line.Contains("L11, μH/m="))
                    {
                        var index = line.IndexOf('=');
                        l11 = line.Substring(index + 1);
                        i++;
                    }

                    if (line.Contains("L22, μH/m="))
                    {
                        var index = line.IndexOf('=');
                        l22 = line.Substring(index + 1);
                        i++;
                    }

                    if (line.Contains("L12, μH/m="))
                    {
                        var index = line.IndexOf('=');
                        l12 = line.Substring(index + 1);
                        i++;
                    }

                    if (i == 6)
                    {
                        sr.Close();
                        break;
                    }
                }
            }

            loadedParams.Add("C11, pF/m", c11);
            loadedParams.Add("C22, pF/m", c22);
            loadedParams.Add("C12, pF/m", c12);
            loadedParams.Add("L22, μH/m", l22);
            loadedParams.Add("L12, μH/m", l12);
            loadedParams.Add("L11, μH/m", l11);
            return loadedParams;
        }

        public static void Save(string fileName, Params currentParams)
        {
            var data = formListForSave(currentParams, false);
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                foreach (var dataString in data)
                {
                    file.WriteLine(dataString);
                }
            }
        }

        private static string FormStringWithFreq(double freq, double magn1, double phn1, double magn2, double phn2,
            double magn3, double phn3, double magn4, double phn4)
        {
            var returningString = " " + freq.ToString() + "\t" + magn1 + "\t" + phn1 + "\t" + magn2 + "\t" + phn2 +
                                  "\t" + magn3 + "\t" + phn3 + "\t" + magn4 + "\t" + phn4;
            returningString = returningString.Replace(',', '.');
            return returningString;
        }

        private static string FormString(double magn1, double phn1, double magn2, double phn2, double magn3,
            double phn3, double magn4, double phn4)
        {
            var returningString = "\t" + magn1 + "\t" + phn1 + "\t" + magn2 + "\t" + phn2 + "\t" + magn3 + "\t" + phn3 +
                                  "\t" + magn4 + "\t" + phn4;
            returningString = returningString.Replace(',', '.');
            return returningString;
        }

        public static void SaveToS4p(string fileName, Params currentParams, double[][][] s4pData, double[] fi,
            SortedList<string, double> relatedData)
        {
            var data = formListForSave(currentParams, true);
            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                file.WriteLine("# GHz S DB R 50");
                file.WriteLine("! ParamApp");
                file.WriteLine("! Calculation date:" + DateTime.Now.ToString());
                file.WriteLine("! Start ParamBlock");
                foreach (var dataString in data)
                {
                    file.WriteLine(dataString);
                }

                file.WriteLine("! End ParamBlock");
                file.WriteLine("! Start RelatedDataBlock");
                file.WriteLine("!Z1in, Ω=" + relatedData["Z1inTextBox"]);
                file.WriteLine("!Z2in, Ω=" + relatedData["Z2inTextBox"]);
                file.WriteLine("!Z1out, Ω=" + relatedData["Z1outTextBox"]);
                file.WriteLine("!Z2out, Ω=" + relatedData["Z2outTextBox"]);
                file.WriteLine("!FreqMin, GHz=" + relatedData["FreqMinTextBox"]);
                file.WriteLine("!FreqMax, GHz=" + relatedData["FreqMaxTextBox"]);
                file.WriteLine("!L, mm=" + (relatedData["LengthTextBox"] * 1000));
                file.WriteLine("!Nf=" + relatedData["NfTextBox"]);
                file.WriteLine("! End RelatedDataBlock");
                for (int i = 0; i < fi.Length; i++)
                {
                    file.WriteLine(FormStringWithFreq(fi[i], s4pData[0][0][i], s4pData[1][0][i], s4pData[0][1][i],
                        s4pData[1][1][i], s4pData[0][2][i],
                        s4pData[1][2][i], s4pData[0][3][i], s4pData[1][3][i]));
                    file.WriteLine(FormString(s4pData[0][4][i], s4pData[1][4][i], s4pData[0][5][i], s4pData[1][5][i],
                        s4pData[0][6][i],
                        s4pData[1][6][i], s4pData[0][7][i], s4pData[1][7][i]));
                    file.WriteLine(FormString(s4pData[0][8][i], s4pData[1][8][i], s4pData[0][9][i], s4pData[1][9][i],
                        s4pData[0][10][i],
                        s4pData[1][10][i], s4pData[0][11][i], s4pData[1][11][i]));
                    file.WriteLine(FormString(s4pData[0][12][i], s4pData[1][12][i], s4pData[0][13][i],
                        s4pData[1][13][i], s4pData[0][14][i],
                        s4pData[1][14][i], s4pData[0][15][i], s4pData[1][15][i]));
                }
            }
        }

        private static List<string> formListForSave(Params currentParams, bool s4p)
        {
            var returnungList = new List<string>();
            if (s4p)
            {
                returnungList.Add("!C11, pF/m=" + currentParams.C11.ToString());
                returnungList.Add("!C22, pF/m=" + currentParams.C22.ToString());
                returnungList.Add("!C12, pF/m=" + currentParams.C12.ToString());
                returnungList.Add("!Z0, Ω=" + currentParams.Z0.ToString());
                returnungList.Add("!k=" + currentParams.k.ToString());
                returnungList.Add("!Rc=" + currentParams.Rc.ToString());
                returnungList.Add("!Rп=" + currentParams.Rp.ToString());
                returnungList.Add("!Erc=" + currentParams.Erc.ToString());
                returnungList.Add("!Erп=" + currentParams.Erp.ToString());
                returnungList.Add("!Zc, Ω=" + currentParams.Zc.ToString());
                returnungList.Add("!Zп, Ω=" + currentParams.Zp.ToString());
                returnungList.Add("!Z1, Ω=" + currentParams.Z1.ToString());
                returnungList.Add("!Z2, Ω=" + currentParams.Z2.ToString());
                returnungList.Add("!n=" + currentParams.N.ToString());
                returnungList.Add("!Rz=" + currentParams.Rz.ToString());
                returnungList.Add("!Z1c, Ω=" + currentParams.Z1c.ToString());
                returnungList.Add("!Z2c, Ω=" + currentParams.Z2c.ToString());
                returnungList.Add("!Zm, Ω=" + currentParams.Zm.ToString());
                returnungList.Add("!S21, dB=" + currentParams.S21.ToString());

                returnungList.Add("!L11, μH/m=" + currentParams.L11.ToString());
                returnungList.Add("!L22, μH/m=" + currentParams.L22.ToString());
                returnungList.Add("!L12, μH/m=" + currentParams.L12.ToString());
                returnungList.Add("!kl=" + currentParams.kl.ToString());
                returnungList.Add("!kc=" + currentParams.kc.ToString());
                returnungList.Add("!klc=" + currentParams.klc.ToString());
                returnungList.Add("!kε=" + currentParams.ke.ToString());
                returnungList.Add("!m=" + currentParams.m.ToString());
                returnungList.Add("!Erп/Erc=" + currentParams.EEE.ToString());
                returnungList.Add("!Zc1, Ω=" + currentParams.Zc1.ToString());
                returnungList.Add("!Zп1, Ω=" + currentParams.Zp1.ToString());
                returnungList.Add("!Zc2, Ω=" + currentParams.Zc2.ToString());
                returnungList.Add("!Zп2, Ω=" + currentParams.Zp2.ToString());
                returnungList.Add("!Z11, Ω=" + currentParams.Z11.ToString());
                returnungList.Add("!Z22, Ω=" + currentParams.Z22.ToString());
                returnungList.Add("!Z1п, Ω=" + currentParams.Z1p.ToString());
                returnungList.Add("!Z2п, Ω=" + currentParams.Z2p.ToString());
                returnungList.Add("!Z12, Ω=" + currentParams.Z12.ToString());
                returnungList.Add("!Result=" + currentParams.Result.ToString());
            }
            else
            {
                returnungList.Add("C11, pF/m=" + currentParams.C11.ToString());
                returnungList.Add("C22, pF/m=" + currentParams.C22.ToString());
                returnungList.Add("C12, pF/m=" + currentParams.C12.ToString());
                returnungList.Add("Z0, Ω=" + currentParams.Z0.ToString());
                returnungList.Add("k=" + currentParams.k.ToString());
                returnungList.Add("Rc=" + currentParams.Rc.ToString());
                returnungList.Add("Rп=" + currentParams.Rp.ToString());
                returnungList.Add("Erc=" + currentParams.Erc.ToString());
                returnungList.Add("Erп=" + currentParams.Erp.ToString());
                returnungList.Add("Zc, Ω=" + currentParams.Zc.ToString());
                returnungList.Add("Zп, Ω=" + currentParams.Zp.ToString());
                returnungList.Add("Z1, Ω=" + currentParams.Z1.ToString());
                returnungList.Add("Z2, Ω=" + currentParams.Z2.ToString());
                returnungList.Add("n=" + currentParams.N.ToString());
                returnungList.Add("Rz=" + currentParams.Rz.ToString());
                returnungList.Add("Z1c, Ω=" + currentParams.Z1c.ToString());
                returnungList.Add("Z2c, Ω=" + currentParams.Z2c.ToString());
                returnungList.Add("Zm, Ω=" + currentParams.Zm.ToString());
                returnungList.Add("S21, dB=" + currentParams.S21.ToString());

                returnungList.Add("L11, μH/m=" + currentParams.L11.ToString());
                returnungList.Add("L22, μH/m=" + currentParams.L22.ToString());
                returnungList.Add("L12, μH/m=" + currentParams.L12.ToString());
                returnungList.Add("kl=" + currentParams.kl.ToString());
                returnungList.Add("kc=" + currentParams.kc.ToString());
                returnungList.Add("klc=" + currentParams.klc.ToString());
                returnungList.Add("kε=" + currentParams.ke.ToString());
                returnungList.Add("m=" + currentParams.m.ToString());
                returnungList.Add("Erп/Erc=" + currentParams.EEE.ToString());
                returnungList.Add("Zc1, Ω=" + currentParams.Zc1.ToString());
                returnungList.Add("Zп1, Ω=" + currentParams.Zp1.ToString());
                returnungList.Add("Zc2, Ω=" + currentParams.Zc2.ToString());
                returnungList.Add("Zп2, Ω=" + currentParams.Zp2.ToString());
                returnungList.Add("Z11, Ω=" + currentParams.Z11.ToString());
                returnungList.Add("Z22, Ω=" + currentParams.Z22.ToString());
                returnungList.Add("Z1п, Ω=" + currentParams.Z1p.ToString());
                returnungList.Add("Z2п, Ω=" + currentParams.Z2p.ToString());
                returnungList.Add("Z12, Ω=" + currentParams.Z12.ToString());
                returnungList.Add("Result=" + currentParams.Result.ToString());
            }

            return returnungList;
        }

        public static LoadGraph LoadS4p(string fileName)
        {
            var loadedParams = new LoadGraph();
            string line;
            double c11 = 0;
            double c22 = 0;
            double c12 = 0;
            double l11 = 0;
            double l22 = 0;
            double l12 = 0;
            double z2Out = 0;
            double z1Out = 0;
            double z2In = 0;
            double z1In = 0;
            double nf = 0;
            double l = 0;
            double fmin = 0;
            double fmax = 0;
            var i = 0;
            var stringCounts = 0;
            bool s4pright = false;
            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("! ParamApp"))
                    {
                        s4pright = true;
                        break;
                    }
                    else
                    {
                        if (!line.Contains("#") && !line.Contains("!"))
                        {
                            stringCounts++;
                        }
                    }
                }

                sr.Close();
            }

            if (s4pright)
            {
                using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("C11, pF/m="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out c11);
                            i++;
                        }

                        if (line.Contains("C22, pF/m="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out c22);
                            i++;
                        }

                        if (line.Contains("C12, pF/m="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out c12);
                            i++;
                        }

                        if (line.Contains("L11, μH/m="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out l11);
                            i++;
                        }

                        if (line.Contains("L22, μH/m="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out l22);
                            i++;
                        }

                        if (line.Contains("L12, μH/m="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out l12);
                            i++;
                        }

                        if (line.Contains("Nf="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out nf);
                            i++;
                        }

                        if (line.Contains("L, mm="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out l);
                            i++;
                        }

                        if (line.Contains("FreqMax, GHz="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out fmax);
                            i++;
                        }

                        if (line.Contains("FreqMin, GHz="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out fmin);
                            i++;
                        }

                        if (line.Contains("Z2out, Ω="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out z2Out);
                            i++;
                        }

                        if (line.Contains("Z1out, Ω="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out z1Out);
                            i++;
                        }

                        if (line.Contains("Z2in, Ω="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out z2In);
                            i++;
                        }

                        if (line.Contains("Z1in, Ω="))
                        {
                            var index = line.IndexOf('=');
                            double.TryParse(line.Substring(index + 1), out z1In);
                            i++;
                        }

                        if (i == 14)
                        {
                            sr.Close();
                            break;
                        }
                    }
                }

                var calculator = new CalculateFromPogonie();
                loadedParams.CurrentParams = calculator.Calculate(c11, c12, c22, l11, l12, l22);
                loadedParams.RelatedData = new SortedList<string, double>
                {
                    {"Z1inTextBox", z1In},
                    {"Z2inTextBox", z2In},
                    {"Z1outTextBox", z1Out},
                    {"Z2outTextBox", z2Out},
                    {"FreqMinTextBox", fmin},
                    {"FreqMaxTextBox", fmax},
                    {"LengthTextBox", l},
                    {"NfTextBox", nf}
                };
            }
            else
            {
                loadedParams.CurrentParams = new Params();
                loadedParams.RelatedData = new SortedList<string, double>
                {
                    {"Z1inTextBox", 50},
                    {"Z2inTextBox", 50},
                    {"Z1outTextBox", 50},
                    {"Z2outTextBox", 50},
                    {"FreqMinTextBox", 0},
                    {"FreqMaxTextBox", 0},
                    {"LengthTextBox", 0},
                    {"NfTextBox", 0}
                };
                loadedParams.data = LoadLefts4p(fileName, stringCounts / 4);
            }

            loadedParams.inParams = s4pright;
            return loadedParams;
        }

        public static double[][] LoadLefts4p(string fileName, int nf)
        {
            double[] S11= new double[nf];
            double[] S12= new double[nf];
            double[] S13= new double[nf];
            double[] S14= new double[nf];
            double[] S22= new double[nf];
            double[] S23= new double[nf];
            double[] S24= new double[nf];
            double[] S33= new double[nf];
            double[] S34= new double[nf];
            double[] S44= new double[nf];
            double[] S21= new double[nf];
            double[] S31= new double[nf];
            double[] S32= new double[nf];
            double[] S41= new double[nf];
            double[] S42= new double[nf];
            double[] S43= new double[nf];
            double[] F11= new double[nf];
            double[] F12= new double[nf];
            double[] F13= new double[nf];
            double[] F14= new double[nf];
            double[] F22= new double[nf];
            double[] F23= new double[nf];
            double[] F24= new double[nf];
            double[] F33= new double[nf];
            double[] F34= new double[nf];
            double[] F44= new double[nf];
            double[] F21= new double[nf];
            double[] F31= new double[nf];
            double[] F32= new double[nf];
            double[] F41= new double[nf];
            double[] F42= new double[nf];
            double[] F43= new double[nf];
            double[] Fi = new double[nf];
            var line = "";
            var i = 0;
            var k = 0;
            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains("#") && !line.Contains("!"))
                    {
                        if (k % 4 == 0)
                        {
                            var data = ssss(line);
                            Fi[i] = double.Parse(data[0]);
                            S11[i] = double.Parse(data[1]);
                            F11[i] = double.Parse(data[2]);
                            S12[i] = double.Parse(data[3]);
                            F12[i] = double.Parse(data[4]);
                            S13[i] = double.Parse(data[5]);
                            F13[i] = double.Parse(data[6]);
                            S14[i] = double.Parse(data[7]);
                            F14[i] = double.Parse(data[8]);
                            i++;
                        }
                        if (i % 4 == 1)
                        {
                            var data = ssss1(line);

                            S21[i] = double.Parse(data[1]);
                            F21[i] = double.Parse(data[2]);
                            S22[i] = double.Parse(data[3]);
                            F22[i] = double.Parse(data[4]);
                            S23[i] = double.Parse(data[5]);
                            F23[i] = double.Parse(data[6]);
                            S24[i] = double.Parse(data[7]);
                            F24[i] = double.Parse(data[8]);
                        }
                        if (i % 4 == 2)
                        {
                            var data = ssss1(line);

                            S31[i] = double.Parse(data[1]);
                            F31[i] = double.Parse(data[2]);
                            S32[i] = double.Parse(data[3]);
                            F32[i] = double.Parse(data[4]);
                            S33[i] = double.Parse(data[5]);
                            F33[i] = double.Parse(data[6]);
                            S34[i] = double.Parse(data[7]);
                            F34[i] = double.Parse(data[8]);
                        }
                        if (i % 4 == 3)
                        {
                            var data = ssss1(line);

                            S41[i] = double.Parse(data[1]);
                            F41[i] = double.Parse(data[2]);
                            S42[i] = double.Parse(data[3]);
                            F42[i] = double.Parse(data[4]);
                            S43[i] = double.Parse(data[5]);
                            F43[i] = double.Parse(data[6]);
                            S44[i] = double.Parse(data[7]);
                            F44[i] = double.Parse(data[8]);
                        }

                        k++;
                    }
                }
            }

            return new double[][]
            {
                Fi, S11, F11, S12, F12, S13, F13, S14, F14, S21, F21, S22, F22, S23, F23, S24, F24, S31, F31, S32, F32,
                S33, F33, S34, F34, S41, F41, S42, F42, S43, F43, S44, F44
            };
        }
        private static string[] ssss(string ss)
        {
            int i0 = 0;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;
            int i5 = 0;
            int i6 = 0;
            int i7 = 0;
            int i8 = 0;
            string v0 = "";
            string v1 = "";
            string v2 = "";
            string v3 = "";
            string v4 = "";
            string v5 = "";
            string v6 = "";
            string v7 = "";
            string v8 = "";
            string s0 = "";
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";
            string s5 = "";
            string s6 = "";
            string s7 = "";
            i0 = ss.IndexOf(" ");
            s0 = ss.Substring(i0 + 1);
            i1 = s0.IndexOf("\t");
            s1 = s0.Substring(i1 + 1);
            i2 = s1.IndexOf("\t");
            s2 = s1.Substring(i2 + 1);
            i3 = s2.IndexOf("\t");
            s3 = s2.Substring(i3 + 1);
            i4 = s3.IndexOf("\t");
            s4 = s3.Substring(i4 + 1);
            i5 = s4.IndexOf("\t");
            s5 = s4.Substring(i5 + 1);
            i6 = s5.IndexOf("\t");
            s6 = s5.Substring(i6 + 1);
            i7 = s6.IndexOf("\t");
            s7 = s6.Substring(i7 + 1);
            i8 = s7.IndexOf("\t");

            v0 = ss.Substring(i0 + 1, i1);
            v1 = ss.Substring(i1 + 1, i2);
            v2 = ss.Substring(i2 + 1, i3);
            v3 = ss.Substring(i3 + 1, i4);
            v4 = ss.Substring(i4 + 1, i5);
            v5 = ss.Substring(i5 + 1, i6);
            v6 = ss.Substring(i6 + 1, i7);
            v7 = ss.Substring(i7 + 1, i8);
            v8 = ss.Substring(i8);
            return new string[] {v0,v1,v2,v3,v4,v5,v6,v7,v8};
        }
        private static string[] ssss1(string ss)
        {
            int i0 = 0;
            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;
            int i5 = 0;
            int i6 = 0;
            int i7 = 0;
            int i8 = 0;
            string v0 = "";
            string v1 = "";
            string v2 = "";
            string v3 = "";
            string v4 = "";
            string v5 = "";
            string v6 = "";
            string v7 = "";
            string v8 = "";
            string s0 = "";
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";
            string s5 = "";
            string s6 = "";
            string s7 = "";
            i1 = s0.IndexOf("\t");
            s1 = s0.Substring(i1 + 1);
            i2 = s1.IndexOf("\t");
            s2 = s1.Substring(i2 + 1);
            i3 = s2.IndexOf("\t");
            s3 = s2.Substring(i3 + 1);
            i4 = s3.IndexOf("\t");
            s4 = s3.Substring(i4 + 1);
            i5 = s4.IndexOf("\t");
            s5 = s4.Substring(i5 + 1);
            i6 = s5.IndexOf("\t");
            s6 = s5.Substring(i6 + 1);
            i7 = s6.IndexOf("\t");
            s7 = s6.Substring(i7 + 1);
            i8 = s7.IndexOf("\t");
            
            v1 = ss.Substring(i1 + 1, i2);
            v2 = ss.Substring(i2 + 1, i3);
            v3 = ss.Substring(i3 + 1, i4);
            v4 = ss.Substring(i4 + 1, i5);
            v5 = ss.Substring(i5 + 1, i6);
            v6 = ss.Substring(i6 + 1, i7);
            v7 = ss.Substring(i7 + 1, i8);
            v8 = ss.Substring(i8);
            return new string[] {v1, v2, v3, v4, v5, v6, v7, v8 };
        }
    }
    
}
