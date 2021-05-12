using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Travel
{
    public partial class FURSANSIGNUP : Form
    {
        public FURSANSIGNUP()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Fursan f = new Fursan();
                f.AssignValues();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message,"Exception Unhandled" ,MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fursan f = new Fursan();
            f.clear();
        }
    }
}
