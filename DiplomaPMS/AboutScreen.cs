using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace DiplomaPMS
{
    public partial class AboutScreen : Form
    {
        public AboutScreen()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("" + AppDomain.CurrentDomain.ToString() + "LICENSE.txt");
            this.licenseRead1.ReadLicenseFromFile(AppDomain.CurrentDomain.BaseDirectory+"LICENSE.txt");
        }
    }
}
