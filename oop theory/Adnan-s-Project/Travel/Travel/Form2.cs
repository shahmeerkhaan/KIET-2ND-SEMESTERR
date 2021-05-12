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
    public partial class VISA : Form
    {
        public VISA()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Visa vs = new Visa();
                vs.uploadPhoto();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Exception Unhandled",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visa vs = new Visa();
            vs.ClearData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                Visa VS = new Visa();
                VS.AssignValues();
                Airline air = new Airline();
                air.passing();
                this.Hide();
            }
           catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                TICKET tk = new TICKET();
                tk.Show();
                this.Hide();
                Airline air = new Airline();
                air.AssignValues();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void vsaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void vsageupdown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void vsfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void vslname_TextChanged(object sender, EventArgs e)
        {

        }

        private void vsppnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void vsemailid_TextChanged(object sender, EventArgs e)
        {

        }

        private void photo_Click(object sender, EventArgs e)
        {

        }
    }

}
