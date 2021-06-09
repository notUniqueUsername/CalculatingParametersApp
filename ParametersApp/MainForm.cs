using CalculatingParametersLib;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ParametersApp
{
    public partial class MainForm : Form
    {
        //Тест выторизации гитхаба
        private Params _currentParams = new Params();
        private CultureInfo Culture = CultureInfo.CreateSpecificCulture("ru-RU");
        private CalculateFromPogonie _calculatorFromPogonie = new CalculateFromPogonie();
        private CalculateFromZC1ZC2ZP1ZP2 _calculatorFromZc1Zc2Zp1Zp2 = new CalculateFromZC1ZC2ZP1ZP2();
        private CalculateFromModal _calculateFromModal = new CalculateFromModal();
        private readonly double mu = 1.2566370614;
        private readonly double epsilon = 8.8541878128;
        private SetOfParametersEnum _setOfParameters = SetOfParametersEnum.Modalnie;

        public MainForm(string[] args)
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

            button1.FlatStyle = FlatStyle.System;
            button2.FlatStyle = FlatStyle.System;
            graphToolStripMenuItem.Enabled = false;
            
            if (args.Length == 7)
            {
                if (Enum.TryParse(args[6], out _setOfParameters))
                {
                    switch (_setOfParameters)
                    {
                        case SetOfParametersEnum.Pogonie:
                            radioButton1.Checked = true;
                            break;
                        case SetOfParametersEnum.Pogonie_pF_nGn:
                            radioButton2.Checked = true;
                            break;
                        case SetOfParametersEnum.Modalnie:
                            radioButton3.Checked = true;
                            break;
                        case SetOfParametersEnum.Zc1_Zp1:
                            radioButton4.Checked = true;
                            break;
                        case SetOfParametersEnum.Zp1_Zc2:
                            radioButton5.Checked = true;
                            break;
                        case SetOfParametersEnum.Zp1_Zc2_RcOne_RpZero:
                            radioButton6.Checked = true;
                            break;
                        case SetOfParametersEnum.ModalnieSymm:
                            radioButton7.Checked = true;
                            break;
                    }
                }
                textBox1.Text = args[0]; //L11
                textBox2.Text = args[1]; //L22
                textBox3.Text = args[2]; //L12
                textBox4.Text = args[3]; //C11
                textBox5.Text = args[4]; //C22
                textBox6.Text = args[5]; //C12
                button1_Click(null,null);
                graphToolStripMenuItem_Click(null, null);
            }
            else
            {
                button2_Click(null,null);
            }
            


        }

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
            dataGridView1.Rows[2].SetValues("-C12, pF/m");
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
            radioButton1.Text = "(L11; L22; L12)/μ\u2080; (C11; C22; -C12)/ε\u2080";
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
                    _currentParams.C11 = double.Parse(textBox4.Text.Replace(".", ","), Culture) * epsilon;
                    _currentParams.C12 = double.Parse(textBox6.Text.Replace(".", ","), Culture) * epsilon;
                    _currentParams.C22 = double.Parse(textBox5.Text.Replace(".", ","), Culture) * epsilon;
                    _currentParams.L11 = double.Parse(textBox1.Text.Replace(".", ","), Culture) * mu;
                    _currentParams.L12 = double.Parse(textBox3.Text.Replace(".", ","), Culture) * mu;
                    _currentParams.L22 = double.Parse(textBox2.Text.Replace(".", ","), Culture) * mu;

                    _currentParams = _calculatorFromPogonie.Calculate(_currentParams.C11, _currentParams.C12,
                        _currentParams.C22, _currentParams.L11, _currentParams.L12, _currentParams.L22);

                    WriteParams(_currentParams.GetForamttedParams());
                    graphToolStripMenuItem.Enabled = true;
                    break;
                case SetOfParametersEnum.Pogonie_pF_nGn:
                    _currentParams.C11 = double.Parse(textBox4.Text.Replace(".", ","), Culture);
                    _currentParams.C12 = double.Parse(textBox6.Text.Replace(".", ","), Culture);
                    _currentParams.C22 = double.Parse(textBox5.Text.Replace(".", ","), Culture);
                    _currentParams.L11 = double.Parse(textBox1.Text.Replace(".", ","), Culture);
                    _currentParams.L12 = double.Parse(textBox3.Text.Replace(".", ","), Culture);
                    _currentParams.L22 = double.Parse(textBox2.Text.Replace(".", ","), Culture);

                    _currentParams = _calculatorFromPogonie.Calculate(_currentParams.C11, _currentParams.C12, _currentParams.C22,
                        _currentParams.L11, _currentParams.L12, _currentParams.L22);

                    WriteParams(_currentParams.GetForamttedParams());
                    graphToolStripMenuItem.Enabled = true;
                    break;
                case SetOfParametersEnum.Modalnie:
                    _currentParams.Z0 = double.Parse(textBox1.Text.Replace(".", ","), Culture);
                    _currentParams.k = double.Parse(textBox2.Text.Replace(".", ","), Culture);
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","), Culture);
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","), Culture);
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","), Culture);
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","), Culture);

                    _currentParams = _calculateFromModal.CalculateAll(_currentParams.Z0, _currentParams.k, _currentParams.Rc, _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);
                    WriteParams(_currentParams.GetForamttedParams());
                    graphToolStripMenuItem.Enabled = true;
                    break;
                case SetOfParametersEnum.Zc1_Zp1:
                    _currentParams.Zc1 = double.Parse(textBox1.Text.Replace(".", ","), Culture);
                    _currentParams.Zp1 = double.Parse(textBox2.Text.Replace(".", ","), Culture);
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","), Culture);
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","), Culture);
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","), Culture);
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","), Culture);

                    _currentParams = _calculatorFromZc1Zc2Zp1Zp2.CalculateWithZc1Zp1(_currentParams.Zc1, _currentParams.Zp1, _currentParams.Rc,
                        _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

                    WriteParams(_currentParams.GetForamttedParams());
                    graphToolStripMenuItem.Enabled = true;
                    break;
                case SetOfParametersEnum.Zp1_Zc2:
                    _currentParams.Zc2 = double.Parse(textBox2.Text.Replace(".", ","), Culture);
                    _currentParams.Zp1 = double.Parse(textBox1.Text.Replace(".", ","), Culture);
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","), Culture);
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","), Culture);
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","), Culture);
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","), Culture);

                    _currentParams = _calculatorFromZc1Zc2Zp1Zp2.CalculateZc2Zp1(_currentParams.Zc2, _currentParams.Zp1,
                        _currentParams.Rc, _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

                    WriteParams(_currentParams.GetForamttedParams());
                    graphToolStripMenuItem.Enabled = true;
                    break;
                case SetOfParametersEnum.Zp1_Zc2_RcOne_RpZero:
                    _currentParams.Zc2 = double.Parse(textBox2.Text.Replace(".", ","), Culture);
                    _currentParams.Zp1 = double.Parse(textBox1.Text.Replace(".", ","), Culture);
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","), Culture);
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","), Culture);
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","), Culture);
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","), Culture);

                    _currentParams = _calculatorFromZc1Zc2Zp1Zp2.CalculateZc2Zp1(_currentParams.Zc2, _currentParams.Zp1,
                        _currentParams.Rc, _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

                    WriteParams(_currentParams.GetForamttedParams());
                    graphToolStripMenuItem.Enabled = true;
                    break;
                case SetOfParametersEnum.ModalnieSymm:
                    _currentParams.Z0 = double.Parse(textBox1.Text.Replace(".", ","), Culture);
                    _currentParams.k = double.Parse(textBox2.Text.Replace(".", ","), Culture);
                    _currentParams.Rc = double.Parse(textBox3.Text.Replace(".", ","), Culture);
                    _currentParams.Rp = double.Parse(textBox4.Text.Replace(".", ","), Culture);
                    _currentParams.Erc = double.Parse(textBox5.Text.Replace(".", ","), Culture);
                    _currentParams.Erp = double.Parse(textBox6.Text.Replace(".", ","), Culture);

                    _currentParams = _calculateFromModal.CalculateAll(_currentParams.Z0, _currentParams.k, _currentParams.Rc,
                        _currentParams.Rp, _currentParams.Erc, _currentParams.Erp);

                    WriteParams(_currentParams.GetForamttedParams());
                    graphToolStripMenuItem.Enabled = true;
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
            ModaleNameTextBox("L11/μ\u2080", "L22/μ\u2080", "L12/μ\u2080", "C11/ε\u2080", "C22/ε\u2080", "-C12/ε\u2080");
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
            ClearTextBoxs();
            _setOfParameters = SetOfParametersEnum.Pogonie_pF_nGn;
            label1.Location = new Point(label1.Location.X - 9, label1.Location.Y);
            label2.Location = new Point(label2.Location.X - 9, label2.Location.Y);
            label3.Location = new Point(label3.Location.X - 9, label3.Location.Y);
            label4.Location = new Point(label4.Location.X - 9, label4.Location.Y);
            label5.Location = new Point(label5.Location.X - 9, label5.Location.Y);
            label6.Location = new Point(label6.Location.X - 12, label6.Location.Y);
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
                    MessageBox.Show("you must first calculate the parameters","error",MessageBoxButtons.OKCancel);
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

        private bool TextBoxValidator()
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
            dialog.Filter ="txt files (*.txt)|*.txt";
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

                var dataToLoad =  ParamFileSaveLoader.Load(dialog.FileName);

                textBox4.Text = dataToLoad[label4.Text];
                textBox5.Text = dataToLoad[label5.Text];
                textBox6.Text = dataToLoad[label6.Text.Remove(label6.Text.IndexOf('-'),1)];
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
            button1.Enabled = TextBoxValidator();
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
            var graphForm = new MainFormOneWindow();
            graphForm.Show();
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var graphForm = new FormForGraph(_currentParams);
            graphForm.Show();
        }
    }
}
