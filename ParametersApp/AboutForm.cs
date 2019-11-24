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
                "https://journal.tusur.ru/storage/124967/1-%D0%A1%D1%8B%D1%87%D0%B5%D0%B2-%D0%A0%D1%83%D0%B4%D1%8B%D0%B9.pdf?1553238272");
        }
    }
}
