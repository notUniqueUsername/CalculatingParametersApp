﻿using CalculatingParametersLib;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ZedGraph;
using Label = System.Windows.Forms.Label;

namespace ParametersApp
{
    public partial class MainFormOneWindow : Form
    {
        private Params _currentParams = new Params();
        private CalculateFromPogonie _calculatorFromPogonie = new CalculateFromPogonie();
        private CalculateFromZC1ZC2ZP1ZP2 _calculatorFromZc1Zc2Zp1Zp2 = new CalculateFromZC1ZC2ZP1ZP2();
        private CalculateFromModal _calculateFromModal = new CalculateFromModal();
        private readonly double mu = 1.2566370614;
        private readonly double epsilon = 8.8541878128;
        private SetOfParametersEnum _setOfParameters = SetOfParametersEnum.Modalnie;

        private bool _grid = true;
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
        private GraphPane _graphPane;
        private CouplLinesInFreqRange _sParamData;
        private double[] _fi;

        public MainFormOneWindow()
        {
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            InitializeComponent();

            this.MaximizeBox = false;
#if !DEBUG
            ChangeVersion();
            button2.Visible = false;
            test2ToolStripMenuItem.Visible = false;
#endif
            ModaleNameTextBox("Z0", "k", "Rc", "Rп", "Erc", "Erп");
            FormatRadioButton1();
            FormatGridView1();

            FormatGridView2();
            button2_Click(null, null);
            button1.FlatStyle = FlatStyle.System;
            button2.FlatStyle = FlatStyle.System;
            graphToolStripMenuItem.Enabled = false;
            tabPage2.Enabled = false;
        }

        #region Main

        private void ChangeVersion()
        {
            var version = "";
            using (StreamReader file = new StreamReader("Version.txt", Encoding.UTF8))
            {
                version = file.ReadLine();
            }

            verToolStripMenuItem.Text = "version from " + version;
        }

        private void FormatGridView1()
        {
            dataGridView1.Width = 203;
            dataGridView1.Height = 470;
            dataGridView1.RowCount = 25;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].HeaderText = "Parameter";
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[1].HeaderText = "Value";
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Rows[0].SetValues("C11, pF/m");
            dataGridView1.Rows[1].SetValues("C22, pF/m");
            dataGridView1.Rows[2].SetValues("C12, pF/m");
            dataGridView1.Rows[3].Height = 5;
            dataGridView1.Rows[3].DividerHeight = 5;
            dataGridView1.Rows[4].SetValues("Z0, Ω");
            dataGridView1.Rows[5].SetValues("k");
            dataGridView1.Rows[6].SetValues("Rc");
            dataGridView1.Rows[7].SetValues("Rп");
            dataGridView1.Rows[8].SetValues("Erc");
            dataGridView1.Rows[9].SetValues("Erп");
            dataGridView1.Rows[10].Height = 5;
            dataGridView1.Rows[10].DividerHeight = 5;
            dataGridView1.Rows[11].SetValues("Zc, Ω");
            dataGridView1.Rows[12].SetValues("Zп, Ω");
            dataGridView1.Rows[13].Height = 5;
            dataGridView1.Rows[13].DividerHeight = 5;
            dataGridView1.Rows[14].SetValues("Z1, Ω");
            dataGridView1.Rows[15].SetValues("Z2, Ω");
            dataGridView1.Rows[16].Height = 5;
            dataGridView1.Rows[16].DividerHeight = 5;
            dataGridView1.Rows[17].SetValues("n");
            dataGridView1.Rows[18].SetValues("Rz");
            dataGridView1.Rows[19].Height = 5;
            dataGridView1.Rows[19].DividerHeight = 5;
            dataGridView1.Rows[20].SetValues("Z1c, Ω");
            dataGridView1.Rows[21].SetValues("Z2c, Ω");
            dataGridView1.Rows[22].SetValues("Zm, Ω");
            dataGridView1.Rows[23].Height = 5;
            dataGridView1.Rows[23].DividerHeight = 5;
            dataGridView1.Rows[24].SetValues("S21, dB");
        }

        private void FormatGridView2()
        {
            dataGridView2.Width = 203;
            dataGridView2.Height = 470;
            dataGridView2.RowCount = 24;
            dataGridView2.ColumnCount = 2;
            dataGridView2.Columns[0].Width = 100;
            dataGridView2.Columns[0].HeaderText = "Parameter";
            dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[1].HeaderText = "Value";
            dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Rows[0].SetValues("L11, μH/m");
            dataGridView2.Rows[1].SetValues("L22, μH/m");
            dataGridView2.Rows[2].SetValues("L12, μH/m");
            dataGridView2.Rows[3].Height = 5;
            dataGridView2.Rows[3].DividerHeight = 5;
            dataGridView2.Rows[4].SetValues("kl");
            dataGridView2.Rows[5].SetValues("kc");
            dataGridView2.Rows[6].SetValues("klc");
            dataGridView2.Rows[7].SetValues("kε");
            dataGridView2.Rows[8].SetValues("m");
            dataGridView2.Rows[9].SetValues("Erп/Erc");
            //dataGridView2.Rows[8].SetValues("kv");
            //dataGridView2.Rows[9].SetValues("m");
            dataGridView2.Rows[10].Height = 7;
            dataGridView2.Rows[10].DividerHeight = 7;
            dataGridView2.Rows[11].SetValues("Zc1, Ω");
            dataGridView2.Rows[13].SetValues("Zc2, Ω");
            //dataGridView2.Rows[13].Height = 0;
            //dataGridView2.Rows[13].DividerHeight = 0;
            dataGridView2.Rows[12].SetValues("Zп1, Ω");
            dataGridView2.Rows[14].SetValues("Zп2, Ω");
            dataGridView2.Rows[15].Height = 8;
            dataGridView2.Rows[15].DividerHeight = 8;
            dataGridView2.Rows[16].SetValues("Z11, Ω");
            dataGridView2.Rows[17].SetValues("Z22, Ω");
            dataGridView2.Rows[18].Height = 5;
            dataGridView2.Rows[18].DividerHeight = 5;
            dataGridView2.Rows[19].SetValues("Z1п, Ω");
            dataGridView2.Rows[20].SetValues("Z2п, Ω");
            dataGridView2.Rows[21].SetValues("Z12, Ω");
            dataGridView2.Rows[22].Height = 5;
            dataGridView2.Rows[22].DividerHeight = 5;
            dataGridView2.Rows[23].SetValues("Result");
        }

        private void ClearTextBoxs()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void ModaleNameTextBox(string l1, string l2, string l3, string l4, string l5, string l6)
        {
            label1.Text = l1;
            label2.Text = l2;
            label3.Text = l3;
            label4.Text = l4;
            label5.Text = l5;
            label6.Text = l6;
        }

        private void FormatRadioButton1()
        {
            radioButton1.Text = "(L11; L22; L12)/μ\u2080; (C11; C22; C12)/ε\u2080";
        }

        private void WriteParams(Params CurrentParams)
        {
            dataGridView2[1, 23].Value = CurrentParams.Result;
            #region Modal

            dataGridView1[1, 4].Value = CurrentParams.Z0;
            dataGridView1[1, 5].Value = CurrentParams.k;
            dataGridView1[1, 6].Value = CurrentParams.Rc;
            dataGridView1[1, 7].Value = CurrentParams.Rp;
            dataGridView1[1, 8].Value = CurrentParams.Erc;
            dataGridView1[1, 9].Value = CurrentParams.Erp;

            #endregion

            #region Pogonie

            dataGridView1[1, 0].Value = CurrentParams.C11;
            dataGridView1[1, 1].Value = CurrentParams.C22;
            dataGridView1[1, 2].Value = CurrentParams.C12;
            dataGridView2[1, 0].Value = CurrentParams.L11;
            dataGridView2[1, 1].Value = CurrentParams.L22;
            dataGridView2[1, 2].Value = CurrentParams.L12;

            #endregion
            #region ImpedanceProvodimosti

            dataGridView2[1, 16].Value = CurrentParams.Z11;
            dataGridView2[1, 17].Value = CurrentParams.Z22;
            dataGridView2[1, 21].Value = CurrentParams.Z12;
            dataGridView1[1, 22].Value = CurrentParams.Zm;

            #endregion
            #region Impedance

            dataGridView1[1, 14].Value = CurrentParams.Z1;
            dataGridView1[1, 15].Value = CurrentParams.Z2;
            dataGridView1[1, 11].Value = CurrentParams.Zc;
            dataGridView1[1, 12].Value = CurrentParams.Zp;
            dataGridView2[1, 11].Value = CurrentParams.Zc1;
            dataGridView2[1, 13].Value = CurrentParams.Zc2;
            dataGridView2[1, 12].Value = CurrentParams.Zp1;
            dataGridView2[1, 14].Value = CurrentParams.Zp2;

            #endregion

            #region Koeff

            dataGridView2[1, 4].Value = CurrentParams.kl;
            dataGridView2[1, 5].Value = CurrentParams.kc;
            dataGridView2[1, 6].Value = CurrentParams.klc;
            dataGridView2[1, 7].Value = CurrentParams.ke;
            dataGridView2[1, 8].Value = CurrentParams.m;
            dataGridView2[1, 9].Value = CurrentParams.EEE;

            #endregion
            #region Resistors

            dataGridView1[1, 17].Value = CurrentParams.N;
            dataGridView1[1, 18].Value = CurrentParams.Rz;
            dataGridView2[1, 19].Value = CurrentParams.Z1p;
            dataGridView2[1, 20].Value = CurrentParams.Z2p;
            dataGridView1[1, 20].Value = CurrentParams.Z1c;
            dataGridView1[1, 21].Value = CurrentParams.Z2c;
            dataGridView1[1, 24].Value = CurrentParams.S21;

            #endregion

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (_setOfParameters)
            {
                case SetOfParametersEnum.Pogonie:
                    _currentParams.C11 = double.Parse(textBox4.Text.Replace(".", ",")) * epsilon;
                    _currentParams.C12 = double.Parse(textBox6.Text.Replace(".", ",")) * epsilon;
                    _currentParams.C22 = double.Parse(textBox5.Text.Replace(".", ",")) * epsilon;
                    _currentParams.L11 = double.Parse(textBox1.Text.Replace(".", ",")) * mu;
                    _currentParams.L12 = double.Parse(textBox3.Text.Replace(".", ",")) * mu;
                    _currentParams.L22 = double.Parse(textBox2.Text.Replace(".", ",")) * mu;

                    _currentParams = _calculatorFromPogonie.Calculate(_currentParams.C11, _currentParams.C12,
                        _currentParams.C22, _currentParams.L11, _currentParams.L12, _currentParams.L22);

                    WriteParams(_currentParams.GetForamttedParams());
                    tabPage2.Enabled = true;
                    break;
                case SetOfParametersEnum.Pogonie_pF_nGn:
                    _currentParams.C11 = double.Parse(textBox4.Text.Replace(".", ","));
                    _currentParams.C12 = double.Parse(textBox6.Text.Replace(".", ","));
                    _currentParams.C22 = double.Parse(textBox5.Text.Replace(".", ","));
                    _currentParams.L11 = double.Parse(textBox1.Text.Replace(".", ","));
                    _currentParams.L12 = double.Parse(textBox3.Text.Replace(".", ","));
                    _currentParams.L22 = double.Parse(textBox2.Text.Replace(".", ","));

                    _currentParams = _calculatorFromPogonie.Calculate(_currentParams.C11, _currentParams.C12, _currentParams.C22,
                        _currentParams.L11, _currentParams.L12, _currentParams.L22);

                    WriteParams(_currentParams.GetForamttedParams());
                    tabPage2.Enabled = true;
                    break;
                case SetOfParametersEnum.Modalnie:
                    _currentParams.Z0 = double.Parse(textBox1.Text.Replace(".", ","));
                    _currentParams.k = double.Parse(textBox2.Text.Replace(".", ","));
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","));
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","));
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","));
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","));

                    _currentParams = _calculateFromModal.CalculateAll(_currentParams.Z0, _currentParams.k, _currentParams.Rc, _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);
                    WriteParams(_currentParams.GetForamttedParams());
                    tabPage2.Enabled = true;
                    break;
                case SetOfParametersEnum.Zc1_Zp1:
                    _currentParams.Zc1 = double.Parse(textBox1.Text.Replace(".", ","));
                    _currentParams.Zp1 = double.Parse(textBox2.Text.Replace(".", ","));
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","));
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","));
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","));
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","));

                    _currentParams = _calculatorFromZc1Zc2Zp1Zp2.CalculateWithZc1Zp1(_currentParams.Zc1, _currentParams.Zp1, _currentParams.Rc,
                        _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

                    WriteParams(_currentParams.GetForamttedParams());
                    tabPage2.Enabled = true;
                    break;
                case SetOfParametersEnum.Zp1_Zc2:
                    _currentParams.Zc2 = double.Parse(textBox2.Text.Replace(".", ","));
                    _currentParams.Zp1 = double.Parse(textBox1.Text.Replace(".", ","));
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","));
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","));
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","));
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","));

                    _currentParams = _calculatorFromZc1Zc2Zp1Zp2.CalculateZc2Zp1(_currentParams.Zc2, _currentParams.Zp1,
                        _currentParams.Rc, _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

                    WriteParams(_currentParams.GetForamttedParams());
                    tabPage2.Enabled = true;
                    break;
                case SetOfParametersEnum.Zp1_Zc2_RcOne_RpZero:
                    _currentParams.Zc2 = double.Parse(textBox2.Text.Replace(".", ","));
                    _currentParams.Zp1 = double.Parse(textBox1.Text.Replace(".", ","));
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","));
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","));
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","));
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","));

                    _currentParams = _calculatorFromZc1Zc2Zp1Zp2.CalculateZc2Zp1(_currentParams.Zc2, _currentParams.Zp1,
                        _currentParams.Rc, _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

                    WriteParams(_currentParams.GetForamttedParams());
                    tabPage2.Enabled = true;
                    break;
                case SetOfParametersEnum.ModalnieSymm:
                    _currentParams.Z0 = double.Parse(textBox1.Text.Replace(".", ","));
                    _currentParams.k = double.Parse(textBox2.Text.Replace(".", ","));
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","));
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","));
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","));
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","));

                    _currentParams = _calculateFromModal.CalculateAll(_currentParams.Z0, _currentParams.k, _currentParams.Rc,
                        _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

                    WriteParams(_currentParams.GetForamttedParams());
                    tabPage2.Enabled = true;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (_setOfParameters)
            {
                case SetOfParametersEnum.Pogonie:
                    textBox1.Text = "4704e-4";
                    textBox2.Text = "6453e-4";
                    textBox3.Text = "3024e-4";
                    textBox4.Text = "1788e-2";
                    textBox5.Text = "1266e-2";
                    textBox6.Text = "755e-2";
                    break;
                case SetOfParametersEnum.Pogonie_pF_nGn:
                    textBox1.Text = "0,588";
                    textBox3.Text = "0,379";
                    textBox2.Text = "0,801";
                    textBox4.Text = "158,298";
                    textBox6.Text = "66,793";
                    textBox5.Text = "112,058";
                    break;
                case SetOfParametersEnum.Modalnie:
                    textBox1.Text = "70,5";
                    textBox2.Text = "0,527";
                    textBox3.Text = "0,994";
                    textBox4.Text = "-2,061";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case SetOfParametersEnum.Zc1_Zp1:
                    textBox1.Text = "91,661";
                    textBox2.Text = "26,469";
                    textBox3.Text = "0,994";
                    textBox4.Text = "-2,061";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case SetOfParametersEnum.Zp1_Zc2:
                    textBox1.Text = "187,78";
                    textBox2.Text = "26,469";
                    textBox3.Text = "0,994";
                    textBox4.Text = "-2,061";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case SetOfParametersEnum.Zp1_Zc2_RcOne_RpZero:
                    textBox1.Text = "187,78";
                    textBox2.Text = "26,469";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case SetOfParametersEnum.ModalnieSymm:
                    textBox1.Text = "70,5";
                    textBox2.Text = "0,527";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
            }

        }

        private void LabelTransport()
        {
            label1.Location = new Point(347, label1.Location.Y);
            label2.Location = new Point(347, label2.Location.Y);
            label3.Location = new Point(347, label3.Location.Y);
            label4.Location = new Point(347, label4.Location.Y);
            label5.Location = new Point(347, label5.Location.Y);
            label6.Location = new Point(347, label6.Location.Y);
        }

        /// <summary>
        /// Погонные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("L11/μ\u2080", "L22/μ\u2080", "L12/μ\u2080", "C11/ε\u2080", "C22/ε\u2080", "C12/ε\u2080");
            dataGridView1.Rows[2].SetValues("C12, pF/m");
            ClearTextBoxs();
            _setOfParameters = SetOfParametersEnum.Pogonie;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            LabelTransport();
        }
        /// <summary>
        /// Погонные пФ нГн
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("L11, μH/m", "L22, μH/m", "L12, μH/m", "C11, pF/m", "C22, pF/m", "-C12, pF/m");
            dataGridView1.Rows[2].SetValues("-C12, pF/m");
            ClearTextBoxs();
            _setOfParameters = SetOfParametersEnum.Pogonie_pF_nGn;
            label1.Location = new Point(label1.Location.X - 9, label1.Location.Y);
            label2.Location = new Point(label2.Location.X - 9, label2.Location.Y);
            label3.Location = new Point(label3.Location.X - 9, label3.Location.Y);
            label4.Location = new Point(label4.Location.X - 9, label4.Location.Y);
            label5.Location = new Point(label5.Location.X - 9, label5.Location.Y);
            label6.Location = new Point(label6.Location.X - 9, label6.Location.Y);
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }
        /// <summary>
        /// Модальные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Z0, Ω", "k", "Rc", "Rп", "Erc", "Erп");
            dataGridView1.Rows[2].SetValues("C12, pF/m");
            ClearTextBoxs();
            _setOfParameters = SetOfParametersEnum.Modalnie;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            LabelTransport();
        }
        /// <summary>
        /// Zc1 Zp1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zc1, Ω", "Zп1, Ω", "Rc", "Rп", "Erc", "Erп");
            dataGridView1.Rows[2].SetValues("C12, pF/m");
            ClearTextBoxs();
            _setOfParameters = SetOfParametersEnum.Zc1_Zp1;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            LabelTransport();
        }
        /// <summary>
        /// Zp1 Zc2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zп1, Ω", "Zc2, Ω", "Rc", "Rп", "Erc", "Erп");
            dataGridView1.Rows[2].SetValues("C12, pF/m");
            ClearTextBoxs();
            _setOfParameters = SetOfParametersEnum.Zp1_Zc2;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            LabelTransport();
        }
        /// <summary>
        /// Zp1 Zc2 Rc=1 Rp=0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zп1, Ω", "Zc2, Ω", "Rc", "Rп", "Erc", "Erп");
            dataGridView1.Rows[2].SetValues("C12, pF/m");
            ClearTextBoxs();
            textBox3.Text = "1";
            textBox3.ReadOnly = true;
            textBox4.Text = "-1e-3";
            textBox4.ReadOnly = true;
            _setOfParameters = SetOfParametersEnum.Zp1_Zc2_RcOne_RpZero;
            LabelTransport();
        }
        /// <summary>
        /// Модальные симметрич rc=1 rp=-1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Z0, Ω", "k", "Rc", "Rп", "Erc", "Erп");
            dataGridView1.Rows[2].SetValues("C12, pF/m");
            ClearTextBoxs();
            textBox3.Text = "1";
            textBox4.Text = "-1";
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            _setOfParameters = SetOfParametersEnum.ModalnieSymm;
            LabelTransport();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = "txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ParamFileSaveLoader.Save(dialog.FileName, _currentParams);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("you must first calculate the parameters", "error", MessageBoxButtons.OKCancel);
                    if (File.Exists(dialog.FileName))
                    {
                        File.Delete(dialog.FileName);
                    }
                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
        }

        private bool TextBoxValidatorTab1()
        {
            Regex noDigit = new Regex(@"^[-]*[0-9]*(?:[.,][0-9]+)?\r?$");
            Regex noDigit1 = new Regex(@"^[-]*[0-9]+[eE]*[-]*[0-9]+\r?$");

            if (textBox1.Text.Length == 0)
            {
                return false;
            }
            if (textBox2.Text.Length == 0)
            {
                return false;
            }
            if (textBox3.Text.Length == 0)
            {
                return false;
            }
            if (textBox4.Text.Length == 0)
            {
                return false;
            }
            if (textBox5.Text.Length == 0)
            {
                return false;
            }
            if (textBox6.Text.Length == 0)
            {
                return false;
            }

            bool text1 = noDigit.IsMatch(textBox1.Text) || noDigit1.IsMatch(textBox1.Text);
            bool text2 = noDigit.IsMatch(textBox2.Text) || noDigit1.IsMatch(textBox2.Text);
            bool text3 = noDigit.IsMatch(textBox3.Text) || noDigit1.IsMatch(textBox3.Text);
            bool text4 = noDigit.IsMatch(textBox4.Text) || noDigit1.IsMatch(textBox4.Text);
            bool text5 = noDigit.IsMatch(textBox5.Text) || noDigit1.IsMatch(textBox5.Text);
            bool text6 = noDigit.IsMatch(textBox6.Text) || noDigit1.IsMatch(textBox6.Text);

            return text1 && text2 && text3 && text4 && text5 && text6;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            dialog.FilterIndex = 1;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();

                radioButton2.Checked = true;

                var dataToLoad = ParamFileSaveLoader.Load(dialog.FileName);

                textBox4.Text = dataToLoad[label4.Text];
                textBox5.Text = dataToLoad[label5.Text];
                textBox6.Text = dataToLoad[label6.Text];
                textBox1.Text = dataToLoad[label1.Text];
                textBox2.Text = dataToLoad[label2.Text];
                textBox3.Text = dataToLoad[label3.Text];

                try
                {
                    button1_Click(sender, e);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        "Файл поврежден, нажмите ОК",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                    this.Activate();
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Regex noDigit = new Regex(@"^[-]*[0-9]*(?:[.,][0-9]+)?\r?$");
            Regex noDigit1 = new Regex(@"^[-]*[0-9]+[eE]*[-]*[0-9]+\r?$");
            TextBox textBox = (TextBox)sender;
            string s = textBox.Text;
            button1.Enabled = TextBoxValidatorTab1();
            if (noDigit.IsMatch(s) || noDigit1.IsMatch(s))
            {

                textBox.ResetForeColor();

            }
            else
            {
                button1.Enabled = false;
                textBox.ForeColor = Color.Red;
            }
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Params testParams = _calculatorFromZc1Zc2Zp1Zp2.CalculateZc2Zp1(64.142136, 24.142136, 1, -0.2, 1.1, 9.9);

            var graphForm = new FormForGraph(testParams);
            graphForm.Show();
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var graphForm = new FormForGraph(_currentParams);
            graphForm.Show();
        }

        #endregion
        #region Graph

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            this.MaximizeBox = false;
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
            _grid = !_grid;
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
                _graphPane.XAxis.MinorGrid.IsVisible = false;
                _graphPane.YAxis.MinorGrid.IsVisible = false;
            }
            else
            {
                yTitle.Text = "S-Parameters (dB)";

                _graphPane.XAxis.MinorGrid.IsVisible = false;
                _graphPane.YAxis.MinorGrid.IsVisible = false;
            }
            yTitle.FontSpec.IsBold = false;
            yTitle.FontSpec.Family = "Arial";
            yTitle.FontSpec.Size = 16;
            _graphPane.ZoomStack.Push(_graphPane, ZoomState.StateType.Zoom);
            _graphPane.XAxis.ResetAutoScale(_graphPane, CreateGraphics());
        }

        private void SetMaxMinAxes(double xMin, double xMax, double[][] sParamMagnitudeOrPhase)
        {
            _graphPane.XAxis.Scale.Max = xMax;
            _graphPane.XAxis.Scale.Min = xMin;
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
            _graphPane.YAxis.Scale.Max = _yMax;
            _graphPane.YAxis.Scale.Min = _yMin;
            //_graphPane.XAxis.Scale.MajorStep = 0.05;
            _graphPane.XAxis.Scale.MajorStepAuto = true;
            _graphPane.XAxis.Scale.FormatAuto = true;
            _graphPane.XAxis.Scale.IsSkipLastLabel = false;
            _graphPane.XAxis.Scale.IsSkipFirstLabel = false;
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
            var count = _fi.Count();
            double fiMarkerCount = 1;

            if (_fi.Count() >= 20)
            {
                count = _fi.Count() - _fi.Count() % 20;
                fiMarkerCount = count / 20;
            }

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
            SetLineWidth(_22Curve);
            _22CurveLabel = _graphPane.AddCurve(sOrF + "22", fakeX, fakeY, Color.Black, SymbolType.XCross);
            _22CurveLabel.Line.Style = DashStyle.Dot;
            _22CurveLabel.Line.IsSmooth = true;
            SetLineWidth(_22CurveLabel);
            _22CurveLabel.IsVisible = false;

            _23Curve = _graphPane.AddCurve(sOrF + "23", _fi, sParamMagnitudeOrPhase[5], Color.Green, SymbolType.None);
            _23Curve.Line.Style = DashStyle.DashDot;
            _23Curve.Line.IsSmooth = true;
            //_23Curve.Symbol.Type = SymbolType.Triangle;
            SetLineWidth(_23Curve);
            _23CurveLabel = _graphPane.AddCurve(sOrF + "23", fakeX, fakeY, Color.Green, SymbolType.Triangle);
            SetLineWidth(_23CurveLabel);
            _23CurveLabel.IsVisible = false;

            _24Curve = _graphPane.AddCurve(sOrF + "24", _fi, sParamMagnitudeOrPhase[6], Color.Black, SymbolType.None);
            SetLineWidth(_24Curve);
            _24CurveLabel = _graphPane.AddCurve(sOrF + "24", fakeX, fakeY, Color.Black, SymbolType.Circle);
            SetLineWidth(_24CurveLabel);
            _24CurveLabel.IsVisible = false;

            _33Curve = _graphPane.AddCurve(sOrF + "33", _fi, sParamMagnitudeOrPhase[7], Color.Blue, SymbolType.None);
            _33Curve.Line.Style = DashStyle.Dot;
            _33Curve.Line.IsSmooth = true;
            SetLineWidth(_33Curve);
            _33CurveLabel = _graphPane.AddCurve(sOrF + "33", fakeX, fakeY, Color.Blue, SymbolType.Star);
            _33CurveLabel.Line.Style = DashStyle.Dot;
            _33CurveLabel.Line.IsSmooth = true;
            SetLineWidth(_33CurveLabel);
            _33CurveLabel.IsVisible = false;

            _34Curve = _graphPane.AddCurve(sOrF + "34", _fi, sParamMagnitudeOrPhase[8], Color.Green, SymbolType.None);
            _34Curve.Line.Style = DashStyle.Dash;
            _34Curve.Line.IsSmooth = true;
            SetLineWidth(_34Curve);
            _34CurveLabel = _graphPane.AddCurve(sOrF + "34", fakeX, fakeY, Color.Green, SymbolType.Square);
            _34CurveLabel.Line.Style = DashStyle.Dash;
            _34CurveLabel.Line.IsSmooth = true;
            SetLineWidth(_34CurveLabel);
            _34CurveLabel.IsVisible = false;


            _44Curve = _graphPane.AddCurve(sOrF + "44", _fi, sParamMagnitudeOrPhase[9], Color.Green, SymbolType.None);
            _44Curve.Line.Style = DashStyle.Dot;
            _44Curve.Line.IsSmooth = true;
            //_44Curve.Symbol.Type = SymbolType.Star;
            SetLineWidth(_44Curve);
            _44CurveLabel = _graphPane.AddCurve(sOrF + "44", fakeX, fakeY, Color.Green, SymbolType.Plus);
            _44CurveLabel.Line.Style = DashStyle.Dot;
            _44CurveLabel.Line.IsSmooth = true;
            SetLineWidth(_44CurveLabel);
            _44CurveLabel.IsVisible = false;

            _22CurveMarker = _graphPane.AddCurve(sOrF + "m22", markerfidata, marker22data, Color.Black, SymbolType.XCross);
            _22CurveMarker.Line.IsVisible = false;
            _22CurveMarker.Label.IsVisible = false;
            _23CurveMarker = _graphPane.AddCurve(sOrF + "m23", markerfidata, marker23data, Color.Green, SymbolType.Triangle);
            _23Curve.Symbol.Size = 2.0f;
            _23CurveMarker.Line.IsVisible = false;
            _23CurveMarker.Label.IsVisible = false;
            _24CurveMarker = _graphPane.AddCurve(sOrF + "m24", markerfidata, marker24data, Color.Black, SymbolType.Circle);
            _24CurveMarker.Line.IsVisible = false;
            _24CurveMarker.Label.IsVisible = false;
            _33CurveMarker = _graphPane.AddCurve(sOrF + "m33", markerfidata, marker33data, Color.Blue, SymbolType.Star);
            _33CurveMarker.Line.IsVisible = false;
            _33CurveMarker.Label.IsVisible = false;
            _34CurveMarker = _graphPane.AddCurve(sOrF + "m34", markerfidata, marker34data, Color.Green, SymbolType.Square);
            _34CurveMarker.Line.IsVisible = false;
            _34CurveMarker.Label.IsVisible = false;
            _44CurveMarker = _graphPane.AddCurve(sOrF + "m44", markerfidata, marker44data, Color.Green, SymbolType.Plus);
            _44CurveMarker.Line.IsVisible = false;
            _44CurveMarker.Label.IsVisible = false;

            SParamListBox_SelectedIndexChanged(new object(), new EventArgs());

            GraphControl.AxisChange();
            GraphControl.Invalidate();
        }

        private void SetTextToLabels()
        {
            var visibleParams = _currentParams.GetForamttedParams();
            ErcLabel.Text = "Erc = " + visibleParams.Erc.ToString("G12");
            ErpLabel.Text = "Erп = " + visibleParams.Erp.ToString("G12");
            EEELabel.Text = "Erп/Erc = " + visibleParams.EEE.ToString("G12");
            S21Label.Text = "S21, dB = " + visibleParams.S21.ToString("G12");
            RcLabel.Text = "Rc = " + visibleParams.Rc.ToString("g12");
            RpLabel.Text = "Rп = " + visibleParams.Rp.ToString("G12");

            KLabel.Text = "k = " + visibleParams.k.ToString("G12");
            NLabel.Text = "n = " + visibleParams.N.ToString("G12");
            RzLabel.Text = "Rz = " + visibleParams.Rz.ToString("G12");

            Z1pLabel.Text = "Z1п, Ω = " + visibleParams.Z1p.ToString("G12");
            Z2cLabel.Text = "Z2c, Ω = " + visibleParams.Z2c.ToString("G12");
            MLabel.Text = "Emax = " + visibleParams.Emax.ToString("G12");

            Z0Label.Text = "Z0, Ω = " + visibleParams.Z0.ToString("G12");
            Z1Label.Text = "Z1, Ω = " + visibleParams.Z1.ToString("G12");
            Z2Label.Text = "Z2, Ω = " + visibleParams.Z2.ToString("G12");

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
            SaveS4pButton.Enabled = true;
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
            var ss = (RadioButton)sender;
            ZInOutFlowLayoutPanel.Enabled = ss.Checked;
            Z01Z02FlowLayoutPanel.Enabled = !ss.Checked;
            DrawButton.Enabled = TextBoxValidatorTab2();
            if (ss.Checked)
            {
                ShematicPictureBox.Image = Properties.Resources.String_low_MidlZInOut;
            }
            else
            {
                ShematicPictureBox.Image = Properties.Resources.String_low_MidlZ02Z01;
            }
        }

        private bool TextBoxValidatorTab2()
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
            DrawButton.Enabled = TextBoxValidatorTab2();
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
            DrawButton.Enabled = TextBoxValidatorTab2();
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


        private void SaveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = "ts";
            dialog.Filter = "ts and s4p files (*.ts;*.s4p)|*.ts;*.s4p";
            dialog.FilterIndex = 1;
            var relatedData = _sParamData.GetRelatedData();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ParamFileSaveLoader.SaveToTs(dialog.FileName, _currentParams, _sParamData.GetS4pFile(), _fi, relatedData);
                var sParamData = new CouplLinesInFreqRange(_currentParams, _l, _fmin, _fmax, _nf, 50, 50, 50, 50);
                relatedData = sParamData.GetRelatedData();
                ParamFileSaveLoader.SaveToS4p(dialog.FileName.Replace(".ts", ".s4p"), _currentParams, sParamData.GetS4pFile(), _fi, relatedData);
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

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "ts files (*.ts)|*.ts|s4p files (*.s4p)|*.s4p";
            dialog.FilterIndex = 1;
            LoadGraph data = new LoadGraph();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName.Contains(".s4p"))
                {
                    data = ParamFileSaveLoader.LoadS4p(dialog.FileName);
                }
                if (dialog.FileName.Contains(".ts"))
                {
                    data = ParamFileSaveLoader.LoadTs(dialog.FileName);
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
                    var graphForm = new FormForGraph(ss, ff, data);
                    graphForm.Show();
                }
            }
        }


        private void ClearLabel(Label label, int start, int length)
        {
            label.Text = label.Text.Substring(start, length);
        }

        private void ClearAllLabels()
        {
            ClearLabel(RcLabel, 0, 4);
            ClearLabel(RpLabel, 0, 4);
            ClearLabel(Z1Label, 0, 6);
            ClearLabel(Z2Label, 0, 6);
            ClearLabel(Z0Label, 0, 6);
            ClearLabel(KLabel, 0, 3);
            ClearLabel(NLabel, 0, 3);
            ClearLabel(RzLabel, 0, 4);
            ClearLabel(S21Label, 0, 9);
            ClearLabel(Z1pLabel, 0, 8);
            ClearLabel(Z2cLabel, 0, 8);
            ClearLabel(MLabel, 0, 6);
            ClearLabel(ErcLabel, 0, 5);
            ClearLabel(ErpLabel, 0, 5);
            ClearLabel(EEELabel, 0, 9);
        }

        private void GridButton_Click(object sender, EventArgs e)
        {
            _graphPane.XAxis.MajorGrid.IsVisible = _grid;
            _graphPane.YAxis.MajorGrid.IsVisible = _grid;
            _grid = !_grid;
            GraphControl.Invalidate();
        }


        private void RzLabel_TextChanged(object sender, EventArgs e)
        {
            var label = (Label)sender;
            if (label.Text.Length > 6)
            {
                label.Font = new Font("Arial Narrow", label.Font.Size);
            }
        }
        #endregion
    }
}
