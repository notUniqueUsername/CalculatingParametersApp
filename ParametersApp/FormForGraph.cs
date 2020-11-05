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
        private bool _grid = false;
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
        private LineItem _22CurveMarker;
        private LineItem _23CurveMarker;
        private LineItem _24CurveMarker;
        private LineItem _33CurveMarker;
        private LineItem _34CurveMarker;
        private LineItem _44CurveMarker;
        private LineItem _22CurveLabel;
        private LineItem _23CurveLabel;
        private LineItem _24CurveLabel;
        private LineItem _33CurveLabel;
        private LineItem _34CurveLabel;
        private LineItem _44CurveLabel;
        private double _z2out;
        private double _z1out;
        private double _z2in;
        private double _z1in;
        private double _xMin;
        private double _xMax;
        private double _yMin;
        private double _yMax;
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
            GeneralRadioButton.Checked = true;
            AllCurvesCheckState(CheckState.Checked);
        }

        void zedGraph_ContextMenuBuilder(ZedGraphControl sender,
            ContextMenuStrip menuStrip,
            Point mousePt,
            ZedGraphControl.ContextMenuObjectState objState)
        {
            menuStrip.Items[6].Enabled = false;
        }

        void zedGraph_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            GraphPane pane = sender.GraphPane;

            // Для простоты примера будем ограничивать масштабирование
            // только в сторону уменьшения размера графика

            // Проверим интервал для каждой оси и
            // при необходимости скорректируем его

            if (pane.XAxis.Scale.Min <= Math.Round(_xMin))
            {
                pane.XAxis.Scale.Min = Math.Round(_xMin);
            }

            if (pane.XAxis.Scale.Max >= Math.Round(_xMax))
            {
                pane.XAxis.Scale.Max = Math.Round(_xMax);
            }

            if (pane.YAxis.Scale.Min <= Math.Round(_yMin))
            {
                pane.YAxis.Scale.Min = Math.Round(_yMin);
            }

            if (pane.YAxis.Scale.Max >= Math.Round(_yMax))
            {
                pane.YAxis.Scale.Max = Math.Round(_yMax);
            }
        }

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
            SParamListBox.Items[5] = sOrF + "23";
            SParamListBox.Items[6] = sOrF + "24";
            SParamListBox.Items[7] = sOrF + "33";
            SParamListBox.Items[8] = sOrF + "34";
            SParamListBox.Items[9] = sOrF + "44";
        }
        /// <summary>
        /// Форматирует график
        /// </summary>
        /// <param name="phase">
        /// true = формат для фазы, false = формат для амплитуды
        /// </param>
        private void FormatAxis(bool forPhase)
        {
            _graphPane.XAxis.MajorGrid.IsVisible = true;
            _graphPane.XAxis.MajorGrid.DashOff = 0;
            _graphPane.XAxis.MajorGrid.Color = Color.Green;
            _graphPane.YAxis.MajorGrid.IsVisible = true;
            _graphPane.YAxis.MajorGrid.DashOff = 0;
            _graphPane.YAxis.MajorGrid.Color = Color.Green;
            _graphPane.Title.IsVisible = false;
            
            var yTitle = _graphPane.YAxis.Title;
            var xTitle = _graphPane.XAxis.Title;
            xTitle.Text = "Frequency (GHz)";
            xTitle.FontSpec.IsBold = false;
            xTitle.FontSpec.Family = "Arial";
            xTitle.FontSpec.Size = 16;
            _graphPane.XAxis.Scale.IsSkipLastLabel = false;
            _graphPane.YAxis.Scale.IsSkipLastLabel = false;
            
            if (forPhase)
            {
                yTitle.Text = "Phase shift (deg)";
                _graphPane.XAxis.MinorGrid.PenWidth = 0.5f;
                _graphPane.XAxis.MinorGrid.IsVisible = false;
                _graphPane.YAxis.MinorGrid.PenWidth = 0.5f;
                _graphPane.YAxis.MinorGrid.IsVisible = false;
            }
            else
            {
                yTitle.Text = "S-Parameters (dB)";
                
                _graphPane.XAxis.MinorGrid.PenWidth = 0.5f;
                _graphPane.XAxis.MinorGrid.IsVisible = true;
                _graphPane.YAxis.MinorGrid.PenWidth = 0.5f;
                _graphPane.YAxis.MinorGrid.IsVisible = true;
            }
            yTitle.FontSpec.IsBold = false;
            yTitle.FontSpec.Family = "Arial";
            yTitle.FontSpec.Size = 16;
            _graphPane.ZoomStack.Push(_graphPane, ZoomState.StateType.Zoom);
            _graphPane.XAxis.ResetAutoScale(_graphPane, CreateGraphics());
        }

        private void SetMaxMinAxes(double xMin, double xMax, double[][] sParamMagnitudeOrPhase)
        {
            _graphPane.XAxis.Scale.Max = Math.Round(xMax);
            _graphPane.XAxis.Scale.Min = Math.Round(xMin);
            _yMax = sParamMagnitudeOrPhase[0].Max();
            _yMin = sParamMagnitudeOrPhase[0].Min();
            for (int i = 1; i < sParamMagnitudeOrPhase.GetLength(0); i++)
            {
                if (sParamMagnitudeOrPhase[i].Max() > _yMax)
                {
                    _yMax = sParamMagnitudeOrPhase[i].Max();
                }
                if (sParamMagnitudeOrPhase[i].Min() < _yMin)
                {
                    _yMin = sParamMagnitudeOrPhase[i].Min();
                }
            }
            _graphPane.YAxis.Scale.Max = Math.Round(_yMax);
            _graphPane.YAxis.Scale.Min = Math.Round(_yMin);
            _graphPane.ZoomStack.Clear();
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
            var fakeX = new double[] { 1 };
            var fakeY = new double[] { 1 };
            var count = _fi.Count() - _fi.Count() % 10;
            double fiMarkerCount = count / 10;
            int fiM =
                int.Parse(Math.Floor(count / fiMarkerCount).ToString());
            var marker22data = new double[fiM];
            var marker23data = new double[fiM];
            var marker24data = new double[fiM];
            var marker33data = new double[fiM];
            var marker34data = new double[fiM];
            var marker44data = new double[fiM];
            var markerfidata = new double[fiM];
            var k = 0;
            for (int i = 0; i < count; i++)
            {
                if (i % fiMarkerCount == 0)
                {
                    markerfidata[k] = _fi[i];
                    marker22data[k] = sParamMagnitudeOrPhase[4][i];
                    marker23data[k] = sParamMagnitudeOrPhase[5][i];
                    marker24data[k] = sParamMagnitudeOrPhase[6][i];
                    marker33data[k] = sParamMagnitudeOrPhase[7][i];
                    marker34data[k] = sParamMagnitudeOrPhase[8][i];
                    marker44data[k] = sParamMagnitudeOrPhase[9][i];
                    k++;
                }
            }

            _11Curve = _graphPane.AddCurve(sOrF + "11", _fi, sParamMagnitudeOrPhase[0], Color.Red, SymbolType.None);
            _11Curve.Line.Style = DashStyle.Dot;
            _11Curve.Line.IsSmooth = true;
            SetLineWidth(_11Curve);

            _12Curve = _graphPane.AddCurve(sOrF + "12", _fi, sParamMagnitudeOrPhase[1], Color.Blue, SymbolType.None);
            _12Curve.Line.Style = DashStyle.Dash;
            _12Curve.Line.IsSmooth = true;
            SetLineWidth(_12Curve);

            _13Curve = _graphPane.AddCurve(sOrF + "13", _fi, sParamMagnitudeOrPhase[2], Color.Red, SymbolType.None);
            SetLineWidth(_13Curve);

            _14Curve = _graphPane.AddCurve(sOrF + "14", _fi, sParamMagnitudeOrPhase[3], Color.Black, SymbolType.None);
            _14Curve.Line.Style = DashStyle.DashDot;
            _14Curve.Line.IsSmooth = true;
            SetLineWidth(_14Curve);

            _22Curve = _graphPane.AddCurve(sOrF + "22", _fi, sParamMagnitudeOrPhase[4], Color.Black, SymbolType.None);
            _22Curve.Line.Style = DashStyle.Dot;
            _22Curve.Line.IsSmooth = true;
            //_22Curve.Symbol.Type = SymbolType.XCross;
            SetLineWidth(_22Curve);
            _22CurveLabel = _graphPane.AddCurve(sOrF + "22", fakeX, fakeY, Color.Black, SymbolType.XCross);
            _22CurveLabel.IsVisible = false;

            _23Curve = _graphPane.AddCurve(sOrF + "23", _fi, sParamMagnitudeOrPhase[5], Color.Yellow, SymbolType.None);
            _23Curve.Line.Style = DashStyle.DashDot;
            _23Curve.Line.IsSmooth = true;
            //_23Curve.Symbol.Type = SymbolType.Triangle;
            SetLineWidth(_23Curve);
            _23CurveLabel = _graphPane.AddCurve(sOrF + "23", fakeX, fakeY, Color.Yellow, SymbolType.Triangle);
            _23CurveLabel.IsVisible = false;

            _24Curve = _graphPane.AddCurve(sOrF + "24", _fi, sParamMagnitudeOrPhase[6], Color.Black, SymbolType.None);
            //_24Curve.Symbol.Type = SymbolType.Circle;
            SetLineWidth(_24Curve);
            _24CurveLabel = _graphPane.AddCurve(sOrF + "24", fakeX, fakeY, Color.Black, SymbolType.Circle);
            _24CurveLabel.IsVisible = false;

            _33Curve = _graphPane.AddCurve(sOrF + "33", _fi, sParamMagnitudeOrPhase[7], Color.Blue, SymbolType.None);
            _33Curve.Line.Style = DashStyle.Dot;
            _33Curve.Line.IsSmooth = true;
            //_33Curve.Symbol.Type = SymbolType.Plus;
            SetLineWidth(_33Curve);
            _33CurveLabel = _graphPane.AddCurve(sOrF + "33", fakeX, fakeY, Color.Blue, SymbolType.Plus);
            _33CurveLabel.IsVisible = false;

            _34Curve = _graphPane.AddCurve(sOrF + "34", _fi, sParamMagnitudeOrPhase[8], Color.Green, SymbolType.None);
            _34Curve.Line.Style = DashStyle.Dash;
            _34Curve.Line.IsSmooth = true;
            //_34Curve.Symbol.Type = SymbolType.Square;
            SetLineWidth(_34Curve);
            _34CurveLabel = _graphPane.AddCurve(sOrF + "34", fakeX, fakeY, Color.Green, SymbolType.Square);
            _34CurveLabel.IsVisible = false;

            _44Curve = _graphPane.AddCurve(sOrF + "44", _fi, sParamMagnitudeOrPhase[9], Color.Green, SymbolType.None);
            _44Curve.Line.Style = DashStyle.Dot;
            _44Curve.Line.IsSmooth = true;
            //_44Curve.Symbol.Type = SymbolType.Star;
            SetLineWidth(_44Curve);
            _44CurveLabel = _graphPane.AddCurve(sOrF + "44", fakeX, fakeY, Color.Green, SymbolType.Star);
            _44CurveLabel.IsVisible = false;

            _22CurveMarker = _graphPane.AddCurve(sOrF + "m22", markerfidata, marker22data, Color.Black, SymbolType.XCross);
            _22CurveMarker.Line.IsVisible = false;
            _22CurveMarker.Label.IsVisible = false;
            _23CurveMarker = _graphPane.AddCurve(sOrF + "m23", markerfidata, marker23data, Color.Yellow, SymbolType.Triangle);
            _23CurveMarker.Line.IsVisible = false;
            _23CurveMarker.Label.IsVisible = false;
            _24CurveMarker = _graphPane.AddCurve(sOrF + "m24", markerfidata, marker24data, Color.Black, SymbolType.Circle);
            _24CurveMarker.Line.IsVisible = false;
            _24CurveMarker.Label.IsVisible = false;
            _33CurveMarker = _graphPane.AddCurve(sOrF + "m33", markerfidata, marker33data, Color.Blue, SymbolType.Plus);
            _33CurveMarker.Line.IsVisible = false;
            _33CurveMarker.Label.IsVisible = false;
            _34CurveMarker = _graphPane.AddCurve(sOrF + "m34", markerfidata, marker34data, Color.Green, SymbolType.Square);
            _34CurveMarker.Line.IsVisible = false;
            _34CurveMarker.Label.IsVisible = false;
            _44CurveMarker = _graphPane.AddCurve(sOrF + "m44", markerfidata, marker44data, Color.Green, SymbolType.Star);
            _44CurveMarker.Line.IsVisible = false;
            _44CurveMarker.Label.IsVisible = false;

            SParamListBox_SelectedIndexChanged(new object(), new EventArgs());

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
            MLabel.Text = "Emax = " + Math.Round(_currentParams.Emax, 3).ToString();

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
                FormatAxis(false);
                SetMaxMinAxes(_xMin, _xMax, _sParamMagnitudes); 
                DrawCurves("S", _sParamMagnitudes);
            }
            else if (PhaseRadioButton.Checked)
            {
                _graphPane.CurveList.Clear();
                FormatAxis(true);
                SetMaxMinAxes(_xMin, _xMax, _sParamPhases); 
                DrawCurves("Φ", _sParamPhases);
            }
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            double.TryParse(LengthTextBox.Text.Replace(".", ","), out _l);
            double.TryParse(FreqMinTextBox.Text.Replace(".", ","), out _fmin);
            double.TryParse(FreqMaxTextBox.Text.Replace(".", ","), out _fmax);
            int.TryParse(NfTextBox.Text, out _nf);
            if (GeneralRadioButton.Checked)
            {
                double.TryParse(Z1inTextBox.Text.Replace(".", ","), out _z1in);
                double.TryParse(Z2inTextBox.Text.Replace(".", ","), out _z2in);
                double.TryParse(Z1outTextBox.Text.Replace(".", ","), out _z1out);
                double.TryParse(Z2outTextBox.Text.Replace(".", ","), out _z2out);
            }
            else if (LineToLineRadioButton.Checked)
            {
                double.TryParse(Z01TextBox.Text.Replace(".", ","), out _z1in);
                double.TryParse(Z02TextBox.Text.Replace(".", ","), out _z2in);
                double.TryParse(Z01TextBox.Text.Replace(".", ","), out _z1out);
                double.TryParse(Z02TextBox.Text.Replace(".", ","), out _z2out);
            }

            CalculateSParamData();
            double.TryParse(FreqMinTextBox.Text.Replace(".", ","), out _xMin);
            double.TryParse(FreqMaxTextBox.Text.Replace(".", ","), out _xMax);
            ChangeGraph();
        }

        private void AllCurvesCheckState(CheckState checkState)
        {
            SParamListBox.SetItemCheckState(0, checkState);
            SParamListBox.SetItemCheckState(1, checkState);
            SParamListBox.SetItemCheckState(2, checkState);
            SParamListBox.SetItemCheckState(3, checkState);
            SParamListBox.SetItemCheckState(4, checkState);
            SParamListBox.SetItemCheckState(5, checkState);
            SParamListBox.SetItemCheckState(6, checkState);
            SParamListBox.SetItemCheckState(7, checkState);
            SParamListBox.SetItemCheckState(8, checkState);
            SParamListBox.SetItemCheckState(9, checkState);
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
            _22CurveMarker.IsVisible = isVisible;
            _23CurveMarker.IsVisible = isVisible;
            _24CurveMarker.IsVisible = isVisible;
            _33CurveMarker.IsVisible = isVisible;
            _34CurveMarker.IsVisible = isVisible;
            _44CurveMarker.IsVisible = isVisible;
            _22CurveLabel.IsVisible = isVisible;
            _22CurveLabel.Label.IsVisible = isVisible;
            _23CurveLabel.IsVisible = isVisible;
            _23CurveLabel.Label.IsVisible = isVisible;
            _24CurveLabel.IsVisible = isVisible;
            _24CurveLabel.Label.IsVisible = isVisible;
            _33CurveLabel.IsVisible = isVisible;
            _33CurveLabel.Label.IsVisible = isVisible;
            _34CurveLabel.IsVisible = isVisible;
            _34CurveLabel.Label.IsVisible = isVisible;
            _34CurveLabel.IsVisible = isVisible;
            _44CurveLabel.Label.IsVisible = isVisible;
        }

        private void SParamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AllCurvesToggleVisible(false);
            }
            catch (NullReferenceException)
            {
                if (DrawButton.Enabled)
                {
                    DrawButton.PerformClick();
                }
                else
                {
                    MessageBox.Show(
                        "Необходимо ввести все значения и затем нажать кнопку draw",
                        "Предупреждение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    this.Activate();
                }
            }

            for (int i = 0; i < SParamListBox.Items.Count; i++)
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
                            _22CurveMarker.IsVisible = true;
                            _22CurveLabel.Label.IsVisible = true;
                            break;
                        case 5:
                            _23Curve.IsVisible = true;
                            _23CurveMarker.IsVisible = true;
                            _23CurveLabel.Label.IsVisible = true;
                            break;
                        case 6:
                            _24Curve.IsVisible = true;
                            _24CurveMarker.IsVisible = true;
                            _24CurveLabel.Label.IsVisible = true;
                            break;
                        case 7:
                            _33Curve.IsVisible = true;
                            _33CurveMarker.IsVisible = true;
                            _33CurveLabel.Label.IsVisible = true;
                            break;
                        case 8:
                            _34Curve.IsVisible = true;
                            _34CurveMarker.IsVisible = true;
                            _34CurveLabel.Label.IsVisible = true;
                            break;
                        case 9:
                            _44Curve.IsVisible = true;
                            _44CurveMarker.IsVisible = true;
                            _44CurveLabel.Label.IsVisible = true;
                            break;
                    }
                }
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
            if (ss.Checked)
            {
                ShematicPictureBox.Image = Properties.Resources.String_low_MidlZInOut;
            }
            else
            {
                ShematicPictureBox.Image = Properties.Resources.String_low_MidlZ02Z01;
            }
        }

        private bool TextBoxValidator()
        {
            Regex noDigit = new Regex(@"^[-]*[0-9]*(?:[.,][0-9]+)?\r?$");
            Regex noDigit1 = new Regex(@"^[-]*[0-9]+[eE]*[-]*[0-9]+\r?$");
            double.TryParse(FreqMinTextBox.Text.Replace(".", ","), out var freqMin);
            double.TryParse(FreqMaxTextBox.Text.Replace(".", ","), out var freqMax);
            double.TryParse(LengthTextBox.Text.Replace(".", ","), out var l);
            bool text7 = (noDigit.IsMatch(FreqMinTextBox.Text) || noDigit1.IsMatch(FreqMinTextBox.Text)) &
                         freqMin >= 0;
            bool text8 = (noDigit.IsMatch(FreqMaxTextBox.Text) || noDigit1.IsMatch(FreqMaxTextBox.Text)) &
                         freqMax > 0;
            bool text9 = (noDigit.IsMatch(LengthTextBox.Text) || noDigit1.IsMatch(LengthTextBox.Text)) & l > 0;
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


        private void Test1Button_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = "s4p";
            var relatedData = _sParamData.GetRelatedData();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ParamFileSaveLoader.SaveToS4p(dialog.FileName, _currentParams, _sParamData.GetS4pFile(), _fi, relatedData);
            }
        }

        private void SelectDeSelectButton_Click(object sender, EventArgs e)
        {
            if (SParamListBox.CheckedItems.Count == 0)
            {
                AllCurvesCheckState(CheckState.Checked);
            }
            else
            {
                AllCurvesCheckState(CheckState.Unchecked);
            }
            SParamListBox_SelectedIndexChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "s4p files (*.s4p)|*.s4p";
            dialog.FilterIndex = 1;
            LoadGraph data = new LoadGraph();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                data = ParamFileSaveLoader.LoadS4p(dialog.FileName);
            }

            if (data.inParams)
            {
                var graphForm = new FormForGraph(data.CurrentParams, data.RelatedData);
                graphForm.Show();
            }
            else
            {
                var ss = new double[][]
                {
                    data.data[1], data.data[3], data.data[5], data.data[7], data.data[11], data.data[13],
                    data.data[15], data.data[21], data.data[23], data.data[31]
                };
                var ff = new double[][]
                {
                    data.data[2], data.data[4], data.data[6], data.data[8], data.data[12], data.data[14],
                    data.data[16], data.data[22], data.data[24], data.data[32]
                };
                var graphForm = new FormForGraph(ss,ff, data);
                graphForm.Show();
            }
        }
        public FormForGraph(double[][] ss, double[][] ff, LoadGraph data)
        {
            InitializeComponent();
            this.Load -= DrawButton_Click;
            this.Load += SelectDeSelectButton_Click;
            this.MaximizeBox = false;
            _graphPane = GraphControl.GraphPane;
            //SetTextToLabels();
            _fi = data.data[0];
            _xMax = _fi.Max();
            _xMin = _fi.Min();
            _sParamMagnitudes = ss;
            _sParamPhases = ff;
            ChangeGraph();
            DrawCurves("S", ss);
            //Z1inTextBox.Text = "50";
            //Z2inTextBox.Text = "50";
            //Z1outTextBox.Text = "50";
            //Z2outTextBox.Text = "50";
            Z1inTextBox.Text = data.RelatedData[Z1inTextBox.Name].ToString();
            Z2inTextBox.Text = data.RelatedData[Z2inTextBox.Name].ToString();
            Z1outTextBox.Text = data.RelatedData[Z1outTextBox.Name].ToString();
            Z2outTextBox.Text = data.RelatedData[Z2outTextBox.Name].ToString();
            LengthTextBox.Text = "?";
            NfTextBox.Text = _fi.Length.ToString();
            FreqMinTextBox.Text = _fi.Min().ToString();
            FreqMaxTextBox.Text = _fi.Max().ToString();
            //GeneralRadioButton.Checked = true;
            //this.KeyPreview = true;
            //DrawButton.PerformClick();
            //this.KeyPreview = true;
            //PhaseRadioButton.Checked = true;
            //AllCurvesCheckState(CheckState.Checked);
            
            GeneralRadioButton.Enabled = false;
            LineToLineRadioButton.Enabled = false;
            DrawButton.Enabled = false;
            SaveS4pButton.Enabled = false;
            Z01Z02FlowLayoutPanel.Enabled = false;
            InputFlowLayoutPanel.Enabled = false;
            ZInOutFlowLayoutPanel.Enabled = false;
        }
        public FormForGraph(Params currentParams, SortedList<string, double> relatedData)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            _currentParams = currentParams;
            _graphPane = GraphControl.GraphPane;
            SetTextToLabels();
            Z1inTextBox.Text = relatedData[Z1inTextBox.Name].ToString();
            Z2inTextBox.Text = relatedData[Z2inTextBox.Name].ToString();
            Z1outTextBox.Text = relatedData[Z1outTextBox.Name].ToString();
            Z2outTextBox.Text = relatedData[Z2outTextBox.Name].ToString();
            LengthTextBox.Text = relatedData[LengthTextBox.Name].ToString();
            NfTextBox.Text = relatedData[NfTextBox.Name].ToString();
            FreqMinTextBox.Text = relatedData[FreqMinTextBox.Name].ToString();
            FreqMaxTextBox.Text = relatedData[FreqMaxTextBox.Name].ToString();
            GeneralRadioButton.Checked = true;
            //this.KeyPreview = true;
            //DrawButton.PerformClick();
            AllCurvesCheckState(CheckState.Checked);
            GeneralRadioButton.Enabled = false;
            LineToLineRadioButton.Enabled = false;
            DrawButton.Enabled = false;
            SaveS4pButton.Enabled = false;
            Z01Z02FlowLayoutPanel.Enabled = false;
            InputFlowLayoutPanel.Enabled = false;
            ZInOutFlowLayoutPanel.Enabled = false;
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            _graphPane.XAxis.MajorGrid.IsVisible = _grid;
            _graphPane.XAxis.MinorGrid.IsVisible = _grid;
            _graphPane.YAxis.MajorGrid.IsVisible = _grid;
            _graphPane.YAxis.MinorGrid.IsVisible = _grid;
            _grid = !_grid;
            GraphControl.Invalidate();
        }

        private void RpLabel_TextChanged(object sender, EventArgs e)
        {
            if (RpLabel.Text.Length > 10)
            {
                RpLabel.Font = new Font("Arial Narrow", RpLabel.Font.Size);
            }
        }
    }
}
