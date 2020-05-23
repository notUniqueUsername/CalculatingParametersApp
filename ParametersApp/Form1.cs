using CalculatingParametersLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParametersApp
{
    public partial class MainForm : Form
    {
        private CalculateFromPogonie _calculatorFromPogonie = new CalculateFromPogonie();
        private CalculateFromZC12ZP12 _calculatorfrom = new CalculateFromZC12ZP12();
        private readonly double mu = 1.2566370614;
        private readonly double epsilon = 8.8541878128;
        //private readonly double mu = 1.2566370614 * Math.Pow(10, -6);
        //private readonly double epsilon = 8.8541878128 * Math.Pow(10, -12);
        private int SetOfParameters = 3;

        public MainForm()
        {
            InitializeComponent();
#if !DEBUG
            button2.Visible = false;
#endif
            ModaleNameTextBox("Z0", "k", "Rc", "Rп", "Erc", "Erп");
            FormatShit();
            FormatGridView1();
            
            FormatGridView2();
            button2_Click(null,null);
            button1.FlatStyle = FlatStyle.System;
            button2.FlatStyle = FlatStyle.System;
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
            dataGridView2.Rows[8].SetValues("kv");
            dataGridView2.Rows[9].SetValues("m");
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

        private void FormatShit()
        {
            radioButton1.Text = "(L11; L22; L12)/μ\u2080; (C11; C22; C12)/ε\u2080";
        }

        private void WriteParams()
        {
            dataGridView2[1, 23].Value = Params.PhysRelease();
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
            dataGridView1[1, 1].Value = Params.C22;
            dataGridView1[1, 2].Value = Params.C12;
            dataGridView2[1, 0].Value = Params.L11;
            dataGridView2[1, 1].Value = Params.L22;
            dataGridView2[1, 2].Value = Params.L12;

            #endregion
            #region ImpedanceProvodimosti

            dataGridView2[1, 16].Value = Params.Z11;
            dataGridView2[1, 17].Value = Params.Z22;
            dataGridView2[1, 21].Value = Params.Z12;
            dataGridView1[1, 22].Value = Params.Zm;

            #endregion
            #region Impedance

            dataGridView1[1, 14].Value = Params.Z1;
            dataGridView1[1, 15].Value = Params.Z2;
            dataGridView1[1, 11].Value = Params.Zc;
            dataGridView1[1, 12].Value = Params.Zp;
            dataGridView2[1, 11].Value = Params.Zc1;
            dataGridView2[1, 13].Value = Params.Zc2;
            dataGridView2[1, 12].Value = Params.Zp1;
            dataGridView2[1, 14].Value = Params.Zp2;

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
            dataGridView2[1, 19].Value = Params.Z1p;
            dataGridView2[1, 20].Value = Params.Z2p;
            dataGridView1[1, 20].Value = Params.Z1c;
            dataGridView1[1, 21].Value = Params.Z2c;
            dataGridView1[1, 24].Value = Params.S21;

            #endregion
            
        }


        private void Rechnen()
        {
            var format = new CalculateAndFormat();
            Params.Z0 = double.Parse(textBox1.Text.Replace(".", ","));
            Params.k = double.Parse(textBox2.Text.Replace(".", ","));
            Params.Rc = double.Parse(textBox3.Text.Replace(".", ","));
            Params.Rp = double.Parse(textBox4.Text.Replace(".", ","));
            Params.Erc = double.Parse(textBox5.Text.Replace(".", ","));
            Params.Erp = double.Parse(textBox6.Text.Replace(".", ","));


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

                    Params.C11 = double.Parse(textBox4.Text.Replace(".", ",")) * epsilon;
                    Params.C12 = double.Parse(textBox6.Text.Replace(".", ",")) * epsilon;
                    Params.C22 = double.Parse(textBox5.Text.Replace(".", ",")) * epsilon;
                    Params.L11 = double.Parse(textBox1.Text.Replace(".", ",")) * mu;
                    Params.L12 = double.Parse(textBox3.Text.Replace(".", ",")) * mu;
                    Params.L22 = double.Parse(textBox2.Text.Replace(".", ",")) * mu;
                    _calculatorFromPogonie.Calculate(Params.C11, Params.C12, Params.C22, Params.L11, Params.L12, Params.L22);
                    WriteParams();
                    break;
                case 2:
                    Params.C11 = double.Parse(textBox4.Text.Replace(".", ","));
                    Params.C12 = double.Parse(textBox6.Text.Replace(".", ","));
                    Params.C22 = double.Parse(textBox5.Text.Replace(".", ","));
                    Params.L11 = double.Parse(textBox1.Text.Replace(".", ","));
                    Params.L12 = double.Parse(textBox3.Text.Replace(".", ","));
                    Params.L22 = double.Parse(textBox2.Text.Replace(".", ","));
                    _calculatorFromPogonie.Calculate(Params.C11, Params.C12, Params.C22, Params.L11, Params.L12, Params.L22);
                    WriteParams();
                    break;
                case 3:
                    Rechnen();
                    break;
                case 4:
                    Params.Zc1 = double.Parse(textBox1.Text.Replace(".", ","));
                    Params.Zp1 = double.Parse(textBox2.Text.Replace(".", ","));
                    Params.Rc = double.Parse(textBox3.Text.Replace(".", ","));
                    Params.Rp = double.Parse(textBox4.Text.Replace(".", ","));
                    Params.Erc = double.Parse(textBox5.Text.Replace(".", ","));
                    Params.Erp = double.Parse(textBox6.Text.Replace(".", ","));
                    _calculatorfrom.CalculateWithZc1Zp1(Params.Zc1, Params.Zp1, Params.Rc, Params.Rp, Params.Erc, Params.Erp);
                    WriteParams();
                    break;
                case 5:
                    Params.Zc2 = double.Parse(textBox2.Text.Replace(".", ","));
                    Params.Zp1 = double.Parse(textBox1.Text.Replace(".", ","));
                    Params.Rc = double.Parse(textBox3.Text.Replace(".", ","));
                    Params.Rp = double.Parse(textBox4.Text.Replace(".", ","));
                    Params.Erc = double.Parse(textBox5.Text.Replace(".", ","));
                    Params.Erp = double.Parse(textBox6.Text.Replace(".", ","));
                    _calculatorfrom.CalculateZc2Zp1(Params.Zc2, Params.Zp1, Params.Rc, Params.Rp, Params.Erc, Params.Erp);
                    WriteParams();
                    break;
                case 6:
                    Params.Zc2 = double.Parse(textBox2.Text.Replace(".", ","));
                    Params.Zp1 = double.Parse(textBox1.Text.Replace(".", ","));
                    Params.Rc = double.Parse(textBox3.Text.Replace(".", ","));
                    Params.Rp = double.Parse(textBox4.Text.Replace(".", ","));
                    Params.Erc = double.Parse(textBox5.Text.Replace(".", ","));
                    Params.Erp = double.Parse(textBox6.Text.Replace(".", ","));
                    _calculatorfrom.CalculateZc2Zp1(Params.Zc2, Params.Zp1, Params.Rc, Params.Rp, Params.Erc, Params.Erp);
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
                    textBox1.Text = "4704e-4";
                    textBox2.Text = "6453e-4";
                    textBox3.Text = "3024e-4";
                    textBox4.Text = "1788e-2";
                    textBox5.Text = "1266e-2";
                    textBox6.Text = "755e-2";
                    break;
                case 2:
                    textBox1.Text = "0,588";
                    textBox3.Text = "0,379";
                    textBox2.Text = "0,801";
                    textBox4.Text = "158,298";
                    textBox6.Text = "66,793";
                    textBox5.Text = "112,058";
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
            ModaleNameTextBox("L11/μ\u2080", "L22/μ\u2080", "L12/μ\u2080", "C11/ε\u2080", "C22/ε\u2080", "C12/ε\u2080");
            ClearTextBoxs();
            SetOfParameters = 1;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("L11, μH/m", "L22, μH/m", "L12, μH/m", "C11, pF/m", "C22, pF/m", "C12, pF/m");
            ClearTextBoxs();
            SetOfParameters = 2;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Z0, Ω", "k", "Rc", "Rп", "Erc", "Erп");
            ClearTextBoxs();
            SetOfParameters = 3;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zc1, Ω", "Zп1, Ω", "Rc", "Rп", "Erc", "Erп");
            ClearTextBoxs();
            SetOfParameters = 4;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zп1, Ω", "Zc2, Ω", "Rc", "Rп", "Erc", "Erп");
            ClearTextBoxs();
            SetOfParameters = 5;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ModaleNameTextBox("Zп1, Ω", "Zc2, Ω", "Rc", "Rп", "Erc", "Erп");
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
                    using (StreamWriter file = new StreamWriter(dialog.FileName, true))
                    {
                        file.WriteLine(dataGridView1.Rows[0].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[0].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[1].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[1].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[2].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[2].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[4].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[4].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[5].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[5].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[6].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[6].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[7].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[7].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[8].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[8].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[9].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[9].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[11].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[11].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[12].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[12].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[14].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[14].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[15].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[15].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[17].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[17].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[18].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[18].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[20].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[20].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[21].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[21].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[22].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[22].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView1.Rows[24].Cells[0].Value.ToString() + "=" + dataGridView1.Rows[24].Cells[1].Value.ToString());

                        file.WriteLine(dataGridView2.Rows[0].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[0].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[1].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[1].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[2].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[2].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[4].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[4].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[5].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[5].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[6].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[6].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[7].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[7].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[8].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[8].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[9].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[9].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[11].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[11].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[12].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[12].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[13].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[13].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[14].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[14].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[16].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[16].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[17].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[17].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[19].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[19].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[20].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[20].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[21].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[21].Cells[1].Value.ToString());
                        file.WriteLine(dataGridView2.Rows[23].Cells[0].Value.ToString() + "=" + dataGridView2.Rows[23].Cells[1].Value.ToString());
                    }
                }
                catch (NullReferenceException exception)
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
                radioButton3.Checked = true;
                var pathToFile = dialog.FileName;
                var z0= "";
                var k = "";
                var rc = "";
                var rp = "";
                var erc = "";
                var erp = "";
                using (StreamReader sr = new StreamReader(pathToFile, Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("Z0, Ω="))
                        {
                            var index = line.IndexOf('=');
                            z0 = line.Substring(index+1);
                        }
                        if (line.Contains("k="))
                        {
                            var index = line.IndexOf('=');
                            k = line.Substring(index+1);
                        }
                        if (line.Contains("Rc="))
                        {
                            var index = line.IndexOf('=');
                            rc = line.Substring(index+1);
                        }
                        if (line.Contains("Rп="))
                        {
                            var index = line.IndexOf('=');
                            rp = line.Substring(index+1);
                        }
                        if (line.Contains("Erc"))
                        {
                            var index = line.IndexOf('=');
                            erc = line.Substring(index+1);
                        }
                        if (line.Contains("Erп="))
                        {
                            var index = line.IndexOf('=');
                            erp = line.Substring(index+1);
                        }
                        textBox1.Text = z0;
                        textBox2.Text = k;
                        textBox3.Text = rc;
                        textBox4.Text = rp;
                        textBox5.Text = erc;
                        textBox6.Text = erp;
                    }
                }
                button1_Click(sender, e);
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
    }
}
