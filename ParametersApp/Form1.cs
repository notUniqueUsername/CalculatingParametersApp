using CalculatingParametersLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParametersApp
{
    public partial class MainForm : Form
    {
        private CalculateFromPogonie _calculatorFromPogonie = new CalculateFromPogonie();
        private CalculateFrom _calculatorfrom = new CalculateFrom();
        private readonly double mu = 1.2566370614 * Math.Pow(10, -6);
        private readonly double epsilon = 8.8541878128 * Math.Pow(10, -12);
        private int SetOfParameters;

        public MainForm()
        {
            InitializeComponent();
            ModaleNameTextBox("Z0", "k", "Rc", "Rп", "Erc", "Erп");
            FormatShit();
            FormatGridView1();
            FormatGridView2();
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
            dataGridView1.Rows[1].SetValues("C12, pF/m");
            dataGridView1.Rows[2].SetValues("C22, pF/m");
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
            dataGridView1.Rows[17].SetValues("Z01, Ω");
            dataGridView1.Rows[18].SetValues("Z02, Ω");
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
            dataGridView2.RowCount = 25;
            dataGridView2.ColumnCount = 2;
            dataGridView2.Columns[0].Width = 100;
            dataGridView2.Columns[0].HeaderText = "Parameter";
            dataGridView2.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[1].HeaderText = "Value";
            dataGridView2.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Rows[0].SetValues("L11, μH/m");
            dataGridView2.Rows[1].SetValues("L12, μH/m");
            dataGridView2.Rows[2].SetValues("L22, μH/m");
            dataGridView2.Rows[3].Height = 5;
            dataGridView2.Rows[3].DividerHeight = 5;
            dataGridView2.Rows[4].SetValues("kl");
            dataGridView2.Rows[5].SetValues("kc");
            dataGridView2.Rows[6].SetValues("klc");
            dataGridView2.Rows[7].SetValues("kε");
            dataGridView2.Rows[8].SetValues("kv");
            dataGridView2.Rows[9].SetValues("m");
            dataGridView2.Rows[10].Height = 5;
            dataGridView2.Rows[10].DividerHeight = 5;
            dataGridView2.Rows[11].SetValues("Zc1, Ω");
            dataGridView2.Rows[12].SetValues("Zc2, Ω");
            dataGridView2.Rows[13].Height = 5;
            dataGridView2.Rows[13].DividerHeight = 5;
            dataGridView2.Rows[14].SetValues("Zп1, Ω");
            dataGridView2.Rows[15].SetValues("Zп2, Ω");
            dataGridView2.Rows[16].Height = 5;
            dataGridView2.Rows[16].DividerHeight = 5;
            dataGridView2.Rows[17].SetValues("Z11, Ω");
            dataGridView2.Rows[18].SetValues("Z22, Ω");
            dataGridView2.Rows[19].Height = 5;
            dataGridView2.Rows[19].DividerHeight = 5;
            dataGridView2.Rows[20].SetValues("Z1п, Ω");
            dataGridView2.Rows[21].SetValues("Z2п, Ω");
            dataGridView2.Rows[22].SetValues("Z12, Ω");
            dataGridView2.Rows[23].Height = 5;
            dataGridView2.Rows[23].DividerHeight = 5;
            dataGridView2.Rows[24].SetValues("Result");
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

        private void FormatShit()
        {
            radioButton1.Text = "(L11; L12; L22)/μ\u2080; (C11; C12; C22)/ε\u2080";
        }

        private void WriteParams()
        {

            #region Modal

            dataGridView1[1, 4].Value = Params.Z0;
            dataGridView1[1, 5].Value = Params.k;
            dataGridView1[1, 6].Value = Params.Rc;
            dataGridView1[1, 7].Value = Params.Rp;
            dataGridView1[1, 8].Value = Params.Erc;
            dataGridView1[1, 9].Value = Params.Erp;

            #endregion

            #region Pogonie

            dataGridView1[1, 0].Value = Params.C11;
            dataGridView1[1, 1].Value = Params.C12;
            dataGridView1[1, 2].Value = Params.C22;
            dataGridView2[1, 0].Value = Params.L11;
            dataGridView2[1, 1].Value = Params.L12;
            dataGridView2[1, 2].Value = Params.L22;

            #endregion
            #region ImpedanceProvodimosti

            dataGridView2[1, 17].Value = Params.Z11;
            dataGridView2[1, 18].Value = Params.Z22;
            dataGridView2[1, 22].Value = Params.Z12;
            dataGridView1[1, 22].Value = Params.Zm;

            #endregion
            #region Impedance

            dataGridView1[1, 14].Value = Params.Z1;
            dataGridView1[1, 15].Value = Params.Z2;
            dataGridView1[1, 12].Value = Params.Zc;
            dataGridView1[1, 11].Value = Params.Zp;
            dataGridView2[1, 11].Value = Params.Zc1;
            dataGridView2[1, 12].Value = Params.Zc2;
            dataGridView2[1, 14].Value = Params.Zp1;
            dataGridView2[1, 15].Value = Params.Zp2;

            #endregion

            #region Koeff

            dataGridView2[1, 4].Value = Params.kl;
            dataGridView2[1, 5].Value = Params.kc;
            dataGridView2[1, 6].Value = Params.klc;
            dataGridView2[1, 7].Value = Params.ke;
            dataGridView2[1, 8].Value = Params.kv;
            dataGridView2[1, 9].Value = Params.m;

            #endregion
            #region Resistors

            dataGridView1[1, 17].Value = Params.Z01;
            dataGridView1[1, 18].Value = Params.Z02;
            dataGridView2[1, 20].Value = Params.Z1p;
            dataGridView2[1, 21].Value = Params.Z2p;
            dataGridView1[1, 20].Value = Params.Z1c;
            dataGridView1[1, 21].Value = Params.Z2c;
            dataGridView1[1, 24].Value = Params.S21;

            #endregion
        }


        private void Rechnen()
        {
            var format = new CalculateAndFormat();
            Params.Z0 = double.Parse(textBox1.Text);
            Params.k = double.Parse(textBox2.Text);
            Params.Rc = double.Parse(textBox3.Text);
            Params.Rp = double.Parse(textBox4.Text);
            Params.Erc = double.Parse(textBox5.Text);
            Params.Erp = double.Parse(textBox6.Text);


            var pogonie = format.CalculatePogonnie(Params.Z0, Params.k, Params.Rc, Params.Rp, Params.Erc, Params.Erp);



            var impedance1 =
                format.CalculateImpedanceProvodimosti(Params.Rc, Params.Rp, Params.Zc1, Params.Zp1, Params.Z0);


            var impedance = format.CalculateImpedance(Params.L11, Params.C11, Params.L22, Params.C22, Params.Zc1,
                Params.Zp1, Params.Rc, Params.Rp);




            var koeff = format.CalculateKoeff(Params.Erc, Params.Erp);



            var resistors = format.CalculateResistors(Params.Rc, Params.Rp, Params.Zp1, Params.Zp2, Params.Z0,
                Params.Zc1, Params.Zc2, Params.Z12);

            WriteParams();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (SetOfParameters)
            {
                case 1:
                    
                    Params.C11 = double.Parse(textBox4.Text)/mu;
                    Params.C12 = double.Parse(textBox5.Text)/mu;
                    Params.C22 = double.Parse(textBox6.Text)/mu;
                    Params.L11 = double.Parse(textBox1.Text)/epsilon;
                    Params.L12 = double.Parse(textBox2.Text)/epsilon;
                    Params.L22 = double.Parse(textBox3.Text)/epsilon;
                    _calculatorFromPogonie.Calculate(Params.C11, Params.C12, Params.C22, Params.L11, Params.L12, Params.L22);
                    WriteParams();
                    break;
                case 2:
                    Params.C11 = double.Parse(textBox4.Text);
                    Params.C12 = double.Parse(textBox5.Text);
                    Params.C22 = double.Parse(textBox6.Text);
                    Params.L11 = double.Parse(textBox1.Text);
                    Params.L12 = double.Parse(textBox2.Text);
                    Params.L22 = double.Parse(textBox3.Text);
                    _calculatorFromPogonie.Calculate(Params.C11, Params.C12, Params.C22, Params.L11, Params.L12, Params.L22);
                    WriteParams();
                    break;
                case 3:
                    Rechnen();
                    break;
                case 4:
                    Params.Zc1 = double.Parse(textBox1.Text);
                    Params.Zp1 = double.Parse(textBox2.Text);
                    Params.Rc = double.Parse(textBox3.Text);
                    Params.Rp = double.Parse(textBox4.Text);
                    Params.Erc = double.Parse(textBox5.Text);
                    Params.Erp = double.Parse(textBox6.Text);
                    _calculatorfrom.Calculate(Params.Zc1, Params.Zp1, Params.Rc, Params.Rp, Params.Erc, Params.Erp);
                    WriteParams();
                    break;
                case 5:
                    Params.Zc2 = double.Parse(textBox1.Text);
                    Params.Zp1 = double.Parse(textBox2.Text);
                    Params.Rc = double.Parse(textBox3.Text);
                    Params.Rp = double.Parse(textBox4.Text);
                    Params.Erc = double.Parse(textBox5.Text);
                    Params.Erp = double.Parse(textBox6.Text);
                    _calculatorfrom.Calculate1(Params.Zc2, Params.Zp1, Params.Rc, Params.Rp, Params.Erc, Params.Erp);
                    WriteParams();
                    break;
                case 6:
                    Params.Zc2 = double.Parse(textBox1.Text);
                    Params.Zp1 = double.Parse(textBox2.Text);
                    Params.Rc = double.Parse(textBox3.Text);
                    Params.Rp = double.Parse(textBox4.Text);
                    Params.Erc = double.Parse(textBox5.Text);
                    Params.Erp = double.Parse(textBox6.Text);
                    _calculatorfrom.Calculate1(Params.Zc2, Params.Zp1, Params.Rc, Params.Rp, Params.Erc, Params.Erp);
                    WriteParams();
                    break;
                case 7:
                    Rechnen();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (SetOfParameters)
            {
                case 1:
                    textBox1.Text = "70,5";
                    textBox2.Text = "0,527";
                    textBox3.Text = "0,994";
                    textBox4.Text = "-2,061";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case 2:
                    textBox1.Text = "0,588";
                    textBox2.Text = "0,379";
                    textBox3.Text = "0,801";
                    textBox4.Text = "158,298";
                    textBox5.Text = "66,793";
                    textBox6.Text = "112,058";
                    break;
                case 3:
                    textBox1.Text = "70,5";
                    textBox2.Text = "0,527";
                    textBox3.Text = "0,994";
                    textBox4.Text = "-2,061";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case 4:
                    textBox1.Text = "91,661";
                    textBox2.Text = "26,469";
                    textBox3.Text = "0,994";
                    textBox4.Text = "-2,061";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case 5:
                    textBox1.Text = "187,78";
                    textBox2.Text = "26,469";
                    textBox3.Text = "0,994";
                    textBox4.Text = "-2,061";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case 6:
                    textBox1.Text = "187,78";
                    textBox2.Text = "26,469";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
                case 7:
                    textBox1.Text = "70,5";
                    textBox2.Text = "0,527";
                    textBox5.Text = "6,387";
                    textBox6.Text = "5,523";
                    break;
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("L11/μ\u2080", "L12/μ\u2080", "L22/μ\u2080", "C11/ε\u2080", "C12/ε\u2080", "C22/ε\u2080");
            ClearTextBoxs();
            SetOfParameters = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("L11, μH/m", "L12, μH/m", "L22, μH/m", "C11, pF/m", "C12, pF/m", "C22, pF/m");
            ClearTextBoxs();
            SetOfParameters = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Z0, Ω", "k", "Rc", "Rп", "Erc", "Erп");
            ClearTextBoxs();
            SetOfParameters = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zc1, Ω", "Zп1, Ω", "Rc", "Rп", "Erc", "Erп");
            ClearTextBoxs();
            SetOfParameters = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zc2, Ω", "Zп1, Ω", "Rc", "Rп", "Erc", "Erп");
            ClearTextBoxs();
            SetOfParameters = 5;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zc2, Ω", "Zп1, Ω", "Rc", "Rп", "Erc", "Erп");
            ClearTextBoxs();
            textBox3.Text = "1";
            textBox3.ReadOnly = true;
            textBox4.Text = "-1E-10";
            textBox4.ReadOnly = true;
            SetOfParameters = 6;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Z0, Ω", "k", "Rc", "Rп", "Erc", "Erп");
            ClearTextBoxs();
            textBox3.Text = "1";
            textBox4.Text = "-1";
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            SetOfParameters = 7;
        }
    }
}
