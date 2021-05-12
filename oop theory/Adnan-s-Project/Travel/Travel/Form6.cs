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
    public partial class cancel : Form
    {
        public cancel()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DOperations dao = new DOperations();
                dao.UDVisa();
                dao.cancelTicket();
                dao.cancelhotel();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DOperations dao = new DOperations();
                dao.UDVisa("e");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
