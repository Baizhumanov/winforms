using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flex00
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
            translate();
        }

        private void FormHelp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form1 = Application.OpenForms[0];
            form1.Show();
        }

        public void translate()
        {
            Text = "Инструкция";
        }
    }
}
