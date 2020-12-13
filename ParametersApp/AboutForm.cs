using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParametersApp
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Process.Start(
                "https://elibrary.ru/item.asp?id=30006562");
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start(
                "https://elibrary.ru/item.asp?id=21633543");
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Process.Start(
                "https://elibrary.ru/item.asp?id=30070189");
        }
        private void label5_Click(object sender, EventArgs e)
        {
            Process.Start(
                "https://elibrary.ru/item.asp?id=37605508");
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Process.Start(
                "https://elibrary.ru/item.asp?id=38527010");
        }
        private void label7_Click(object sender, EventArgs e)
        {
            Process.Start(
                "https://journal.tusur.ru/storage/140608/2-Sychev-Bondar-Zharov__.pdf?1606386094");
        }
        private void label8_Click(object sender, EventArgs e)
        {
            Process.Start(
                "https://journal.tusur.ru/storage/140610/3-Sychev-Anisimov-Bondar__.pdf?1606387373");
        }
    }
}
