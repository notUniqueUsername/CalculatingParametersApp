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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ModaleNameTextBox();
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
            dataGridView1.Rows[7].SetValues("Rp");
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

        private void ModaleNameTextBox()
        {
            label1.Text = "Z0";
            label2.Text = "k";
            label3.Text = "Rc";
            label4.Text = "Rp";
            label5.Text = "Erc";
            label6.Text = "Erp";
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

            #region Modal

            dataGridView1[1, 4].Value = Params.Z0;
            dataGridView1[1, 5].Value = Params.k;
            dataGridView1[1, 6].Value = Params.Rc;
            dataGridView1[1, 7].Value = Params.Rp;
            dataGridView1[1, 8].Value = Params.Erc;
            dataGridView1[1, 9].Value = Params.Erp;
            

            #endregion

            var pogonie = format.CalculatePogonnie(Params.Z0, Params.k, Params.Rc, Params.Rp, Params.Erc, Params.Erp);

            #region Pogonie

            dataGridView1[1, 0].Value = Params.C11;
            dataGridView1[1, 1].Value = Params.C12;
            dataGridView1[1, 2].Value = Params.C22;
            dataGridView2[1, 0].Value = Params.L11;
            dataGridView2[1, 1].Value = Params.L12;
            dataGridView2[1, 2].Value = Params.L22;

            #endregion

            var impedance1 =
                format.CalculateImpedanceProvodimosti(Params.Rc, Params.Rp, Params.Zc1, Params.Zp1, Params.Z0);

            #region ImpedanceProvodimosti

            dataGridView2[1, 17].Value = Params.Z11;
            dataGridView2[1, 18].Value = Params.Z22;
            dataGridView2[1, 22].Value = Params.Z12;
            dataGridView1[1, 22].Value = Params.Zm;

            #endregion
            var impedance = format.CalculateImpedance(Params.L11, Params.C11, Params.L22, Params.C22, Params.Zc1,
                Params.Zp1, Params.Rc, Params.Rp);

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


            var koeff = format.CalculateKoeff(Params.Erc, Params.Erp);

            #region Koeff

            dataGridView2[1, 4].Value = Params.kl;
            dataGridView2[1, 5].Value = Params.kc;
            dataGridView2[1, 6].Value = Params.klc;
            dataGridView2[1, 7].Value = Params.ke;
            dataGridView2[1, 8].Value = Params.kv;
            dataGridView2[1, 9].Value = Params.m;

            #endregion


            var resistors = format.CalculateResistors(Params.Rc, Params.Rp, Params.Zp1, Params.Zp2, Params.Z0,
                Params.Zc1, Params.Zc2, Params.Z12);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Rechnen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "70,5";
            textBox2.Text = "0,527";
            textBox3.Text = "0,994";
            textBox4.Text = "-2,061";
            textBox5.Text = "6,387";
            textBox6.Text = "5,523";
        }

    }
}
