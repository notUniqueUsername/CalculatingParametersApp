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

            

            var pogonie = format.CalculatePogonnie(double.Parse(textBox1.Text), double.Parse(textBox2.Text),
                double.Parse(textBox3.Text), double.Parse(textBox4.Text), double.Parse(textBox5.Text),
                double.Parse(textBox6.Text));
            var s123 = format.PogonieItem(pogonie);
            foreach (var VARIABLE in s123)
            {
                listBox1.Items.Add(VARIABLE);
            }

            var impedance1 = format.CalculateImpedanceProvodimosti(double.Parse(textBox3.Text),
                double.Parse(textBox4.Text), pogonie[6], pogonie[7], double.Parse(textBox1.Text));
            var s12345 = format.ImpedanceProvodimostiItem(impedance1);
            foreach (var VARIABLE in s12345)
            {
                listBox3.Items.Add(VARIABLE);
            }
            var impedance = format.CalculateImpedance(pogonie[0], pogonie[3], pogonie[2], pogonie[5], pogonie[6],
                pogonie[7], double.Parse(textBox3.Text), double.Parse(textBox4.Text), impedance1);
            var s1234 = format.ImpedanceItem(impedance);
            foreach (var VARIABLE in s1234)
            {
                listBox2.Items.Add(VARIABLE);
            }

            var koeff = format.CalculateKoeff(pogonie, double.Parse(textBox5.Text), double.Parse(textBox6.Text));
            var s123456 = format.KoeffItem(koeff);
            foreach (var VARIABLE in s123456)
            {
                listBox4.Items.Add(VARIABLE);
            }

            var resistors = format.CalculateResistors(double.Parse(textBox3.Text),
                double.Parse(textBox4.Text), impedance[5], impedance[7], double.Parse(textBox1.Text), impedance[4],
                impedance[6], impedance1[1]);
            var s1234567 = format.ResistorsItem(resistors);
            foreach (var VARIABLE in s1234567)
            {
                listBox6.Items.Add(VARIABLE);
            }
            listBox5.Items.Add(label1.Text + "=" + textBox1.Text);
            listBox5.Items.Add(label2.Text + "=" + textBox2.Text);
            listBox5.Items.Add(label3.Text + "=" + textBox3.Text);
            listBox5.Items.Add(label4.Text + "=" + textBox4.Text);
            listBox5.Items.Add(label5.Text + "=" + textBox5.Text);
            listBox5.Items.Add(label6.Text + "=" + textBox6.Text);
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
