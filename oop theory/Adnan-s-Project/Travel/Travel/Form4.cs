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
    public partial class FURSAN : Form
    {
        public FURSAN()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FURSANSIGNUP fs = new FURSANSIGNUP();
            this.Close();
            fs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DOperations dao = new DOperations();
                dao.Login();
                Home hm = new Home();
                hm.Show();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Home hm = new Home();
            hm.Show();
        }
    }
}
