using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CalculatingParametersLib;
using ZedGraph;

namespace ParametersApp
{
    public partial class FormForGraph : Form
    {
        private LineItem _11Curve;
        private LineItem _12Curve;
        private LineItem _13Curve;
        private LineItem _14Curve;
        private LineItem _22Curve;
        private LineItem _23Curve;
        private LineItem _24Curve;
        private LineItem _33Curve;
        private LineItem _34Curve;
        private LineItem _44Curve;
        private double _z2out;
        private double _z1out;
        private double _z2in;
        private double _z1in;
        private double _xMin;
        private double _xMax;
        private int _nf;
        private double _fmin;
        private double _l;
        private double _fmax;
        private double[][] _sParamMagnitudes;
        private double[][] _sParamPhases;
        private Params _currentParams;
        private GraphPane _graphPane;
        private CouplLinesInFreqRange _sParamData;
        private double[] _fi;

        public FormForGraph(Params currentParams)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            _currentParams = currentParams;
            _graphPane = GraphControl.GraphPane;
            SetTextToTextBoxes();
            SetTextToLabels();
            FormatAxis();
            
            GeneralRadioButton.Checked = true;
        }


        private void SetLineWidth(LineItem curve)
        {
            curve.Line.Width = 2.0f;
        }

        private void SetTextToListBox(string sOrF)
        {
            SParamListBox.Items[0] = "All";
            SParamListBox.Items[1] = sOrF + "11";
            SParamListBox.Items[2] = sOrF + "12";
            SParamListBox.Items[3] = sOrF + "13";
            SParamListBox.Items[4] = sOrF + "14";
            SParamListBox.Items[5] = sOrF + "22";
            SParamListBox.Items[6] = sOrF + "23";
            SParamListBox.Items[7] = sOrF + "24";
            SParamListBox.Items[8] = sOrF + "33";
            SParamListBox.Items[9] = sOrF + "34";
            SParamListBox.Items[10] = sOrF + "44";
        }

        private void FormatAxis()
        {
            _graphPane.XAxis.MajorGrid.IsVisible = true;
            _graphPane.XAxis.MajorGrid.DashOff = 0;
            _graphPane.XAxis.MajorGrid.Color = Color.Green;
            _graphPane.YAxis.MajorGrid.IsVisible = true;
            _graphPane.YAxis.MajorGrid.DashOff = 0;
            _graphPane.YAxis.MajorGrid.Color = Color.Green;
            _graphPane.Title.IsVisible = false;
            var yTitle = _graphPane.YAxis.Title;
            yTitle.Text = "Magnitude (dB)";
            var xTitle = _graphPane.XAxis.Title;
            xTitle.Text = "Frequency (GHz)";

            _graphPane.XAxis.Scale.IsSkipLastLabel = false;
            _graphPane.XAxis.Scale.MajorStep = 5;
            _graphPane.YAxis.Scale.IsSkipLastLabel = false;
            _graphPane.YAxis.Scale.MajorStep = 30;
        }

        private void SetMaxMinAxes(double xMin, double xMax, double[][] sParamMagnitudeOrPhase)
        {
            _graphPane.XAxis.Scale.Max = xMax;
            _graphPane.XAxis.Scale.Min = xMin;
            double yMax = sParamMagnitudeOrPhase[0].Max();
            double yMin = sParamMagnitudeOrPhase[0].Min();
            for (int i = 1; i < sParamMagnitudeOrPhase.GetLength(0); i++)
            {
                if (sParamMagnitudeOrPhase[i].Max() > yMax)
                {
                    yMax = sParamMagnitudeOrPhase[i].Max();
                }
                if (sParamMagnitudeOrPhase[i].Min() < yMin)
                {
                    yMin = sParamMagnitudeOrPhase[i].Min();
                }
            }
            _graphPane.YAxis.Scale.Max = Math.Round(yMax);
            _graphPane.YAxis.Scale.Min = Math.Round(yMin);
        }

        private void SetTextToTextBoxes()
        {
            FreqMaxTextBox.Text = "15";
            FreqMinTextBox.Text = "0";
            LengthTextBox.Text = "10";
            NfTextBox.Text = "500";
            Z1inTextBox.Text = "25";
            Z2inTextBox.Text = "50";
            Z1outTextBox.Text = "25";
            Z2outTextBox.Text = "50";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sOrF"></param>
        /// <param name="sParamMagnitudeOrPhase">
        /// фазы или магнитуды 11 = 0, 12 = 1, 13 = 2, 14 = 3, 22 = 4, 23 = 5, 24 = 6, 33 = 7, 34 = 8, 44 = 9.
        /// </param>
        private void DrawCurves(string sOrF, double[][] sParamMagnitudeOrPhase)
        {

            _11Curve = _graphPane.AddCurve(sOrF + "11", _fi, sParamMagnitudeOrPhase[0], Color.Red, SymbolType.None);
            _11Curve.Line.Style = DashStyle.Dot;
            _11Curve.Line.IsSmooth = true;
            SetLineWidth(_11Curve);

            _12Curve = _graphPane.AddCurve(sOrF + "12", _fi, sParamMagnitudeOrPhase[1], Color.Blue, SymbolType.None);
            _12Curve.Line.Style = DashStyle.Dash;
            _12Curve.Line.IsSmooth = true;
            SetLineWidth(_12Curve);

            _13Curve = _graphPane.AddCurve(sOrF + "13", _fi, sParamMagnitudeOrPhase[2], Color.Red, SymbolType.None);
            //s13curve.Line.Style = DashStyle.Dot;
            //s13curve.Line.IsSmooth = true;
            SetLineWidth(_13Curve);

            _14Curve = _graphPane.AddCurve(sOrF + "14", _fi, sParamMagnitudeOrPhase[3], Color.Black, SymbolType.None);
            _14Curve.Line.Style = DashStyle.DashDot;
            _14Curve.Line.IsSmooth = true;
            SetLineWidth(_14Curve);

            _22Curve = _graphPane.AddCurve(sOrF + "22", _fi, sParamMagnitudeOrPhase[4], Color.Black, SymbolType.None);
            _22Curve.Line.Style = DashStyle.Dot;
            _22Curve.Line.IsSmooth = true;
            SetLineWidth(_22Curve);

            _23Curve = _graphPane.AddCurve(sOrF + "23", _fi, sParamMagnitudeOrPhase[5], Color.Yellow, SymbolType.None);
            _23Curve.Line.Style = DashStyle.DashDot;
            _23Curve.Line.IsSmooth = true;
            SetLineWidth(_23Curve);

            _24Curve = _graphPane.AddCurve(sOrF + "24", _fi, sParamMagnitudeOrPhase[6], Color.Black, SymbolType.None);
            //s24curve.Line.Style = DashStyle.Dot;
            //s24curve.Line.IsSmooth = true;
            SetLineWidth(_24Curve);

            _33Curve = _graphPane.AddCurve(sOrF + "33", _fi, sParamMagnitudeOrPhase[7], Color.Blue, SymbolType.None);
            _33Curve.Line.Style = DashStyle.Dot;
            _33Curve.Line.IsSmooth = true;
            SetLineWidth(_33Curve);

            _34Curve = _graphPane.AddCurve(sOrF + "34", _fi, sParamMagnitudeOrPhase[8], Color.Green, SymbolType.None);
            _34Curve.Line.Style = DashStyle.Dash;
            _34Curve.Line.IsSmooth = true;
            SetLineWidth(_34Curve);

            _44Curve = _graphPane.AddCurve(sOrF + "44", _fi, sParamMagnitudeOrPhase[9], Color.Green, SymbolType.None);
            _44Curve.Line.Style = DashStyle.Dot;
            _44Curve.Line.IsSmooth = true;
            SetLineWidth(_44Curve);

            GraphControl.AxisChange();
            GraphControl.Invalidate();
        }

        private void SetTextToLabels()
        {
            ErcLabel.Text = "Erc = " + Math.Round(_currentParams.Erc, 3).ToString();
            ErpLabel.Text = "Erп = " + Math.Round(_currentParams.Erp, 3).ToString();
            EEELabel.Text = "Erп/Erc = " + Math.Round(_currentParams.EEE, 1).ToString();

            S21Label.Text = "S21, dB = " + Math.Round(_currentParams.S21, 1).ToString();
            RcLabel.Text = "Rc = " + Math.Round(_currentParams.Rc, 3).ToString();
            RpLabel.Text = "Rп = " + Math.Round(_currentParams.Rp, 3).ToString();

            KLabel.Text = "k = " + Math.Round(_currentParams.k, 3).ToString();
            NLabel.Text = "n = " + Math.Round(_currentParams.N, 3).ToString();
            RzLabel.Text = "Rz = " + Math.Round(_currentParams.Rz, 3).ToString();

            Z1pLabel.Text = "Z1п, Ω = " + Math.Round(_currentParams.Z1p, 3).ToString();
            Z2cLabel.Text = "Z2c, Ω = " + Math.Round(_currentParams.Z2c, 3).ToString();
            MLabel.Text = "Mmax = " + Math.Round(_currentParams.Mmax, 3).ToString();

            Z0Label.Text = "Z0, Ω = " + Math.Round(_currentParams.Z0, 1).ToString();
            Z1Label.Text = "Z1, Ω = " + Math.Round(_currentParams.Z1, 1).ToString();
            Z2Label.Text = "Z2, Ω = " + Math.Round(_currentParams.Z2, 1).ToString();
            
        }

        private void CalculateSParamData()
        {
            var sParamData = new CouplLinesInFreqRange(_currentParams, _l, _fmin, _fmax, _nf, _z1in, _z2in, _z1out, _z2out);
            _sParamData = sParamData;
            _sParamMagnitudes = _sParamData.GetSParamMagnitude();
            _sParamPhases = _sParamData.GetSParamPhase();
            _fi = _sParamData.GetFi();

        }

        private void ChangeGraph()
        {
            if (MagnitudeRadioButton.Checked)
            {
                _graphPane.CurveList.Clear();
                SetMaxMinAxes(_xMin, _xMax, _sParamMagnitudes);
                DrawCurves("S", _sParamMagnitudes);
            }
            else if (PhaseRadioButton.Checked)
            {
                _graphPane.CurveList.Clear();
                SetMaxMinAxes(_xMin, _xMax, _sParamPhases);
                DrawCurves("Φ", _sParamPhases);
            }
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            double.TryParse(LengthTextBox.Text, out _l);
            double.TryParse(FreqMinTextBox.Text, out _fmin);
            double.TryParse(FreqMaxTextBox.Text, out _fmax);
            int.TryParse(NfTextBox.Text, out _nf);
            if (GeneralRadioButton.Checked)
            {
                double.TryParse(Z1inTextBox.Text, out _z1in);
                double.TryParse(Z2inTextBox.Text, out _z2in);
                double.TryParse(Z1outTextBox.Text, out _z1out);
                double.TryParse(Z2outTextBox.Text, out _z2out);
            }
            else if (LineToLineRadioButton.Checked)
            {
                double.TryParse(Z01TextBox.Text, out _z1in);
                double.TryParse(Z02TextBox.Text, out _z2in);
                double.TryParse(Z01TextBox.Text, out _z1out);
                double.TryParse(Z02TextBox.Text, out _z2out);
            }

            CalculateSParamData();
            AllCurvesCheckState(CheckState.Checked);
            SParamListBox.SetItemCheckState(0, CheckState.Checked);
            double.TryParse(FreqMinTextBox.Text, out _xMin);
            double.TryParse(FreqMaxTextBox.Text, out _xMax);
            ChangeGraph();
        }

        private void AllCurvesCheckState(CheckState checkState)
        {
            SParamListBox.SetItemCheckState(1, checkState);
            SParamListBox.SetItemCheckState(2, checkState);
            SParamListBox.SetItemCheckState(3, checkState);
            SParamListBox.SetItemCheckState(4, checkState);
            SParamListBox.SetItemCheckState(5, checkState);
            SParamListBox.SetItemCheckState(6, checkState);
            SParamListBox.SetItemCheckState(7, checkState);
            SParamListBox.SetItemCheckState(8, checkState);
            SParamListBox.SetItemCheckState(9, checkState);
            SParamListBox.SetItemCheckState(10, checkState);
        }

        private void AllCurvesToggleVisible(bool isVisible)
        {
            _11Curve.IsVisible = isVisible;
            _11Curve.Label.IsVisible = isVisible;
            _12Curve.IsVisible = isVisible;
            _12Curve.Label.IsVisible = isVisible;
            _13Curve.IsVisible = isVisible;
            _13Curve.Label.IsVisible = isVisible;
            _14Curve.IsVisible = isVisible;
            _14Curve.Label.IsVisible = isVisible;
            _22Curve.IsVisible = isVisible;
            _22Curve.Label.IsVisible = isVisible;
            _23Curve.IsVisible = isVisible;
            _23Curve.Label.IsVisible = isVisible;
            _24Curve.IsVisible = isVisible;
            _24Curve.Label.IsVisible = isVisible;
            _33Curve.IsVisible = isVisible;
            _33Curve.Label.IsVisible = isVisible;
            _34Curve.IsVisible = isVisible;
            _34Curve.Label.IsVisible = isVisible;
            _44Curve.IsVisible = isVisible;
            _44Curve.Label.IsVisible = isVisible;
        }

        private void SParamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AllCurvesToggleVisible(false);
            }
            catch (NullReferenceException)
            {
                DrawButton.PerformClick();
            }
            
            if (SParamListBox.SelectedIndex == 0)
            {
                if (SParamListBox.GetItemCheckState(0) == CheckState.Checked)
                {
                    AllCurvesCheckState(CheckState.Checked);
                    AllCurvesToggleVisible(true);
                }
                else
                {
                    AllCurvesCheckState(CheckState.Unchecked);
                    AllCurvesToggleVisible(false);
                }
            }
            else
            {
                for (int i = 0; i < SParamListBox.Items.Count; i++)
                {
                    if (SParamListBox.CheckedIndices.Contains(i))
                    {
                        switch (i)
                        {
                            case 1:
                                _11Curve.IsVisible = true;
                                _11Curve.Label.IsVisible = true;
                                break;
                            case 2:
                                _12Curve.IsVisible = true;
                                _12Curve.Label.IsVisible = true;
                                break;
                            case 3:
                                _13Curve.IsVisible = true;
                                _13Curve.Label.IsVisible = true;
                                break;
                            case 4:
                                _14Curve.IsVisible = true;
                                _14Curve.Label.IsVisible = true;
                                break;
                            case 5:
                                _22Curve.IsVisible = true;
                                _22Curve.Label.IsVisible = true;
                                break;
                            case 6:
                                _23Curve.IsVisible = true;
                                _23Curve.Label.IsVisible = true;
                                break;
                            case 7:
                                _24Curve.IsVisible = true;
                                _24Curve.Label.IsVisible = true;
                                break;
                            case 8:
                                _33Curve.IsVisible = true;
                                _33Curve.Label.IsVisible = true;
                                break;
                            case 9:
                                _34Curve.IsVisible = true;
                                _34Curve.Label.IsVisible = true;
                                break;
                            case 10:
                                _44Curve.IsVisible = true;
                                _44Curve.Label.IsVisible = true;
                                break;
                            case 0:
                                break;
                        }
                    }
                }
            }

            if (!(_11Curve.IsVisible && _12Curve.IsVisible && _13Curve.IsVisible && _14Curve.IsVisible && _22Curve.IsVisible && _23Curve.IsVisible 
                  && _24Curve.IsVisible && _33Curve.IsVisible && _34Curve.IsVisible && _44Curve.IsVisible))
            {
                SParamListBox.SetItemCheckState(0, CheckState.Unchecked);
            }
            if (_11Curve.IsVisible && _12Curve.IsVisible && _13Curve.IsVisible && _14Curve.IsVisible && _22Curve.IsVisible && _23Curve.IsVisible
                && _24Curve.IsVisible && _33Curve.IsVisible && _34Curve.IsVisible && _44Curve.IsVisible)
            {
                SParamListBox.SetItemCheckState(0, CheckState.Checked);
            }
            GraphControl.AxisChange();
            GraphControl.Invalidate();
        }

        private void MagnitudeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetTextToListBox("S");
            //DrawButton.PerformClick();
            ChangeGraph();
        }

        private void PhaseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetTextToListBox("Φ");
            //DrawButton.PerformClick();
            ChangeGraph();
        }

        private void GeneralRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var ss = (RadioButton) sender;
            ZInOutFlowLayoutPanel.Enabled = ss.Checked;
            Z01Z02FlowLayoutPanel.Enabled = !ss.Checked;
            DrawButton.Enabled = TextBoxValidator();
        }

        private bool TextBoxValidator()
        {
            Regex noDigit = new Regex(@"^[-]*[0-9]*(?:[.,][0-9]+)?\r?$");
            Regex noDigit1 = new Regex(@"^[-]*[0-9]+[eE]*[-]*[0-9]+\r?$");
            double.TryParse(FreqMinTextBox.Text, out var freqMin);
            double.TryParse(FreqMaxTextBox.Text, out var freqMax);
            bool text7 = (noDigit.IsMatch(FreqMinTextBox.Text) || noDigit1.IsMatch(FreqMinTextBox.Text)) &
                         freqMin >= 0;
            bool text8 = (noDigit.IsMatch(FreqMaxTextBox.Text) || noDigit1.IsMatch(FreqMaxTextBox.Text)) &
                         freqMax > 0;
            bool text9 = int.TryParse(LengthTextBox.Text, out var l) & l > 0;
            bool text10 = int.TryParse(NfTextBox.Text, out var nf) & nf > 0;
            bool text11 = freqMax > freqMin;

            if (GeneralRadioButton.Checked)
            {
                if (Z1inTextBox.Text.Length == 0)
                {
                    return false;
                }
                if (Z2inTextBox.Text.Length == 0)
                {
                    return false;
                }
                if (Z1outTextBox.Text.Length == 0)
                {
                    return false;
                }
                if (Z2outTextBox.Text.Length == 0)
                {
                    return false;
                }
                bool text1 = noDigit.IsMatch(Z1inTextBox.Text) || noDigit1.IsMatch(Z1inTextBox.Text);
                bool text2 = noDigit.IsMatch(Z2inTextBox.Text) || noDigit1.IsMatch(Z2inTextBox.Text);
                bool text3 = noDigit.IsMatch(Z1outTextBox.Text) || noDigit1.IsMatch(Z1outTextBox.Text);
                bool text4 = noDigit.IsMatch(Z2outTextBox.Text) || noDigit1.IsMatch(Z2outTextBox.Text);
                return text1 && text2 && text3 && text4 && text7 && text8 && text9 && text10 && text11;
            }
            if (Z01TextBox.Text.Length == 0)
            {
                return false;
            }

            if (Z02TextBox.Text.Length == 0)
            {
                return false;
            }

            bool text5 = noDigit.IsMatch(Z01TextBox.Text) || noDigit1.IsMatch(Z01TextBox.Text);
            bool text6 = noDigit.IsMatch(Z02TextBox.Text) || noDigit1.IsMatch(Z02TextBox.Text);
            return text5 && text6 && text7 && text8 && text9 && text10 && text11;
        }

        private void textBox_TextChangedForDouble(object sender, EventArgs e)
        {
            Regex noDigit = new Regex(@"^[-]*[0-9]*(?:[.,][0-9]+)?\r?$");
            Regex noDigit1 = new Regex(@"^[-]*[0-9]+[eE]*[-]*[0-9]+\r?$");
            TextBox textBox = (TextBox)sender;
            string s = textBox.Text;
            DrawButton.Enabled = TextBoxValidator();
            if (noDigit.IsMatch(s) || noDigit1.IsMatch(s))
            {

                textBox.ResetForeColor();

            }
            else
            {
                DrawButton.Enabled = false;
                textBox.ForeColor = Color.Red;
            }
        }

        private void textBox_TextChangedForInt(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string s = textBox.Text;
            DrawButton.Enabled = TextBoxValidator();
            if (int.TryParse(s, out var result) & result > 0)
            {

                textBox.ResetForeColor();

            }
            else
            {
                DrawButton.Enabled = false;
                textBox.ForeColor = Color.Red;
            }
        }

        private string sssss(double freq, double magn1, double phn1, double magn2, double phn2, double magn3, double phn3, double magn4, double phn4)
        {
            var returningString = " " + freq.ToString() + "\t" + magn1 + "\t" + phn1 + "\t" + magn2 + "\t" + phn2 + "\t" + magn3 + "\t" + phn3 + "\t" + magn4 + "\t" + phn4;
            returningString = returningString.Replace(',', '.');
            return returningString;
        }

        private string sssss(double magn1, double phn1, double magn2, double phn2, double magn3, double phn3, double magn4, double phn4)
        {
            var returningString = "\t" + magn1 + "\t" + phn1 + "\t" + magn2 + "\t" + phn2 + "\t" + magn3 + "\t" + phn3 + "\t" + magn4 + "\t" + phn4;
            returningString = returningString.Replace(',', '.');
            return returningString;
        }

        private void Test1Button_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = "s4p";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var data = _sParamData.GetS4pFile();
                using (StreamWriter file = new StreamWriter(dialog.FileName, true))
                {
                    file.WriteLine("# GHz S DB R 50");
                    file.WriteLine("! ParamApp");
                    file.WriteLine("! " + DateTime.Now.ToString());
                    file.WriteLine("! Data: Calculations");
                    for (int i = 0; i < _fi.Length; i++)
                    {
                        file.WriteLine(sssss(_fi[i], data[0][0][i], data[1][0][i], data[0][1][i], data[1][1][i], data[0][2][i],
                            data[1][2][i], data[0][3][i], data[1][3][i]));
                        file.WriteLine(sssss(data[0][4][i], data[1][4][i], data[0][5][i], data[1][5][i], data[0][6][i],
                            data[1][6][i], data[0][7][i], data[1][7][i]));
                        file.WriteLine(sssss(data[0][8][i], data[1][8][i], data[0][9][i], data[1][9][i], data[0][10][i],
                            data[1][10][i], data[0][11][i], data[1][11][i]));
                        file.WriteLine(sssss(data[0][12][i], data[1][12][i], data[0][13][i], data[1][13][i], data[0][14][i],
                            data[1][14][i], data[0][15][i], data[1][15][i]));
                    }
                }
            }
        }
    }
}
