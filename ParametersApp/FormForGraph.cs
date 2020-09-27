using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private double[][] _sParamMagnitudes;
        private double[][] _sParamPhases;
        private Params _currentParams;
        private GraphPane _graphPane;

        private void SetLineWidth(LineItem curve)
        {
            curve.Line.Width = 2.0f;
        }

        private void SetTextToTextboxes()
        {
            ErcLabel.Text = _currentParams.Erc.ToString();
        }
        public FormForGraph(CouplLinesInFreqRange sParamData, Params currentParams)
        {
            InitializeComponent();
            _currentParams = currentParams;
            _sParamMagnitudes = sParamData.GetSParamMagnitude();
            _sParamPhases = sParamData.GetSParamPhase();

            _graphPane = GraphControl.GraphPane;
            var s11curve = _graphPane.AddCurve("S11", sParamData.GetFi(), _sParamMagnitudes[0], Color.Red, SymbolType.None);
            s11curve.Line.Style = DashStyle.Dot;
            s11curve.Line.IsSmooth = true;
            SetLineWidth(s11curve);
            var s22curve = _graphPane.AddCurve("S22", sParamData.GetFi(), _sParamMagnitudes[4], Color.Black, SymbolType.None);
            s22curve.Line.Style = DashStyle.Dot;
            s22curve.Line.IsSmooth = true;
            SetLineWidth(s22curve);
            var s12curve = _graphPane.AddCurve("S12", sParamData.GetFi(), _sParamMagnitudes[1], Color.Blue, SymbolType.None);
            s12curve.Line.Style = DashStyle.Dash;
            s12curve.Line.IsSmooth = true;
            SetLineWidth(s12curve);
            var s13curve = _graphPane.AddCurve("S13", sParamData.GetFi(), _sParamMagnitudes[2], Color.Red, SymbolType.None);
            //s13curve.Line.Style = DashStyle.Dot;
            //s13curve.Line.IsSmooth = true;
            SetLineWidth(s13curve);
            var s24curve = _graphPane.AddCurve("S24", sParamData.GetFi(), _sParamMagnitudes[5], Color.Black, SymbolType.None);
            //s24curve.Line.Style = DashStyle.Dot;
            //s24curve.Line.IsSmooth = true;
            SetLineWidth(s24curve);
            var s14curve = _graphPane.AddCurve("S14", sParamData.GetFi(), _sParamMagnitudes[3], Color.Blue, SymbolType.None);
            s14curve.Line.Style = DashStyle.DashDot;
            s14curve.Line.IsSmooth = true;
            SetLineWidth(s14curve);
            _graphPane.XAxis.Scale.Max = Math.Round(sParamData.GetFi().Max());
            _graphPane.XAxis.Scale.Min = Math.Round(sParamData.GetFi().Min());
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
            double yMax = _sParamMagnitudes[0].Max();
            double yMin = _sParamMagnitudes[0].Min();
            for (int i = 1; i < _sParamMagnitudes.GetLength(0); i++)
            {
                if (_sParamMagnitudes[i].Max() > yMax)
                {
                    yMax = _sParamMagnitudes[i].Max();
                }
                if (_sParamMagnitudes[i].Min() < yMin)
                {
                    yMin = _sParamMagnitudes[i].Min();
                }
            }
            _graphPane.YAxis.Scale.Max = Math.Round(yMax);
            _graphPane.YAxis.Scale.Min = Math.Round(yMin);

            _graphPane.XAxis.Scale.IsSkipLastLabel = false;
            _graphPane.XAxis.Scale.MajorStep = 5;

            GraphControl.AxisChange();
            
            GraphControl.Invalidate();
        }
    }
}
