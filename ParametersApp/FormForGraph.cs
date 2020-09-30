using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
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
        private LineItem _24Curve;
        private double[][] _sParamMagnitudes;
        private double[][] _sParamPhases;
        private Params _currentParams;
        private GraphPane _graphPane;
        private CouplLinesInFreqRange _sParamData;
        private double[] _fi;



        private void SetLineWidth(LineItem curve)
        {
            curve.Line.Width = 2.0f;
        }

        private void SetTextToListBox(string sOrF)
        {
            SParamListBox.Items[0] = sOrF + "11";
            SParamListBox.Items[1] = sOrF + "12";
            SParamListBox.Items[2] = sOrF + "13";
            SParamListBox.Items[3] = sOrF + "14";
            SParamListBox.Items[4] = sOrF + "22";
            SParamListBox.Items[5] = sOrF + "24";
            SParamListBox.Items[6] = "All";
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
            NTextBox.Text = "10";
            Z1inTextBox.Text = "25";
            Z2inTextBox.Text = "50";
            Z1outTextBox.Text = "25";
            Z2outTextBox.Text = "50";
        }

        private void DrawCurves(string sOrF, double[][] sParamMagnitudeOrPhase)
        {
            _11Curve = _graphPane.AddCurve(sOrF + "11", _fi, sParamMagnitudeOrPhase[0], Color.Red, SymbolType.None);
            _11Curve.Line.Style = DashStyle.Dot;
            _11Curve.Line.IsSmooth = true;
            SetLineWidth(_11Curve);
            _22Curve = _graphPane.AddCurve(sOrF + "22", _fi, sParamMagnitudeOrPhase[4], Color.Black, SymbolType.None);
            _22Curve.Line.Style = DashStyle.Dot;
            _22Curve.Line.IsSmooth = true;
            SetLineWidth(_22Curve);
            _12Curve = _graphPane.AddCurve(sOrF + "12", _fi, sParamMagnitudeOrPhase[1], Color.Blue, SymbolType.None);
            _12Curve.Line.Style = DashStyle.Dash;
            _12Curve.Line.IsSmooth = true;
            SetLineWidth(_12Curve);
            _13Curve = _graphPane.AddCurve(sOrF + "13", _fi, sParamMagnitudeOrPhase[2], Color.Red, SymbolType.None);
            //s13curve.Line.Style = DashStyle.Dot;
            //s13curve.Line.IsSmooth = true;
            SetLineWidth(_13Curve);
            _24Curve = _graphPane.AddCurve(sOrF + "24", _fi, sParamMagnitudeOrPhase[5], Color.Black, SymbolType.None);
            //s24curve.Line.Style = DashStyle.Dot;
            //s24curve.Line.IsSmooth = true;
            SetLineWidth(_24Curve);
            _14Curve = _graphPane.AddCurve(sOrF + "14", _fi, sParamMagnitudeOrPhase[3], Color.Blue, SymbolType.None);
            _14Curve.Line.Style = DashStyle.DashDot;
            _14Curve.Line.IsSmooth = true;
            SetLineWidth(_14Curve);

            GraphControl.AxisChange();
            GraphControl.Invalidate();
        }

        private void SetTextToLabels()
        {
            ErcLabel.Text ="Erc = " + Math.Round(_currentParams.Erc, 3).ToString();
            ErpLabel.Text = "Erп = " + Math.Round(_currentParams.Erp, 3).ToString();
            RcLabel.Text = "Rc = " + Math.Round(_currentParams.Rc, 3).ToString();
            RpLabel.Text = "Rп = " + Math.Round(_currentParams.Rp, 3).ToString();
            Z1Label.Text = "Zc1, Ω = " + Math.Round(_currentParams.Zc1, 3).ToString();
            Zp1Label.Text = "Zп1, Ω = " + Math.Round(_currentParams.Zp1, 3).ToString();
            Zc2Label.Text = "Zc2, Ω = " + Math.Round(_currentParams.Zc2, 3).ToString();
            Z2Label.Text = "Zп2, Ω = " + Math.Round(_currentParams.Zp2, 3).ToString();
            RzLabel.Text = "Rz = " + Math.Round(_currentParams.Rz, 3).ToString();
            Z0Label.Text = "Z0, Ω = " + Math.Round(_currentParams.Z0, 3).ToString();
            KLabel.Text = "k = " + Math.Round(_currentParams.k, 3).ToString();
            Z0Label.Text = "Zo, Ω = ";
        }

        private void CalculateSParamData()
        {
            double.TryParse(NTextBox.Text, out var l);
            double.TryParse(FreqMinTextBox.Text, out var fmin);
            double.TryParse(FreqMaxTextBox.Text, out var fmax);
            double.TryParse(Z1inTextBox.Text, out var z1in);
            double.TryParse(Z2inTextBox.Text, out var z2in);
            double.TryParse(Z1outTextBox.Text, out var z1out);
            double.TryParse(Z2outTextBox.Text, out var z2out);
            var sParamData = new CouplLinesInFreqRange(_currentParams, l, fmin, fmax, z1in, z2in, z1out, z2out);
            _sParamData = sParamData;
            _sParamMagnitudes = _sParamData.GetSParamMagnitude();
            _sParamPhases = _sParamData.GetSParamPhase();
            _fi = _sParamData.GetFi();
            Z0Label.Text = "Zo, Ω = " + Math.Round(_sParamData.GetZo(), 3).ToString();

        }

        public FormForGraph(Params currentParams)
        {
            InitializeComponent();
            _currentParams = currentParams;
            _graphPane = GraphControl.GraphPane;
            SetTextToTextBoxes();
            SetTextToLabels();
            FormatAxis();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            CalculateSParamData();
            AllCurvesCheckState(CheckState.Checked);
            SParamListBox.SetItemCheckState(6, CheckState.Checked);
            double xMin;
            double.TryParse(FreqMinTextBox.Text, out xMin);
            double xMax;
            double.TryParse(FreqMaxTextBox.Text, out xMax);
            if (MagnitudeRadioButton.Checked)
            {
                _graphPane.CurveList.Clear();
                SetMaxMinAxes(xMin, xMax, _sParamMagnitudes);
                DrawCurves("S", _sParamMagnitudes);
            }
            else if (PhaseRadioButton.Checked)
            {
                _graphPane.CurveList.Clear();
                SetMaxMinAxes(xMin, xMax, _sParamPhases);
                DrawCurves("F", _sParamPhases);
            }
        }

        private void AllCurvesCheckState(CheckState checkState)
        {
            SParamListBox.SetItemCheckState(0, checkState);
            SParamListBox.SetItemCheckState(1, checkState);
            SParamListBox.SetItemCheckState(2, checkState);
            SParamListBox.SetItemCheckState(3, checkState);
            SParamListBox.SetItemCheckState(4, checkState);
            SParamListBox.SetItemCheckState(5, checkState);
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
            _24Curve.IsVisible = isVisible;
            _24Curve.Label.IsVisible = isVisible;
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
            
            if (SParamListBox.SelectedIndex == 6)
            {
                if (SParamListBox.GetItemCheckState(6) == CheckState.Checked)
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
                for (int i = 0; i <= 6; i++)
                {
                    if (SParamListBox.CheckedIndices.Contains(i))
                    {
                        switch (i)
                        {
                            case 0:
                                _11Curve.IsVisible = true;
                                _11Curve.Label.IsVisible = true;
                                break;
                            case 1:
                                _12Curve.IsVisible = true;
                                _12Curve.Label.IsVisible = true;
                                break;
                            case 2:
                                _13Curve.IsVisible = true;
                                _13Curve.Label.IsVisible = true;
                                break;
                            case 3:
                                _14Curve.IsVisible = true;
                                _14Curve.Label.IsVisible = true;
                                break;
                            case 4:
                                _22Curve.IsVisible = true;
                                _22Curve.Label.IsVisible = true;
                                break;
                            case 5:
                                _24Curve.IsVisible = true;
                                _24Curve.Label.IsVisible = true;
                                break;
                            case 6:
                                break;
                        }
                    }
                }
            }

            if (!(_11Curve.IsVisible && _12Curve.IsVisible && _13Curve.IsVisible && _14Curve.IsVisible && _22Curve.IsVisible && _24Curve.IsVisible))
            {
                SParamListBox.SetItemCheckState(6, CheckState.Unchecked);
            }
            if (_11Curve.IsVisible && _12Curve.IsVisible && _13Curve.IsVisible && _14Curve.IsVisible && _22Curve.IsVisible && _24Curve.IsVisible)
            {
                SParamListBox.SetItemCheckState(6, CheckState.Checked);
            }
            GraphControl.AxisChange();
            GraphControl.Invalidate();
        }

        private void MagnitudeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetTextToListBox("S");
            DrawButton.PerformClick();
        }

        private void PhaseRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            SetTextToListBox("F");
            DrawButton.PerformClick();
        }
    }
}
