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
    public partial class HOTEL : Form
    {
        public HOTEL()
        {
            InitializeComponent();
            Visa vs = new Visa();
            hpp.Text = Convert.ToString(vs.PassportNumber);
            hflname.Text = vs.LastName;
            hfname.Text = vs.FirstName;
        }

        private void HOTEL_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DOperations dao = new DOperations();
            try
            {
                Hotel ht = new Hotel();
                ht.Hotels();
                ht.Assignvalues();
                TPB TP = new TPB();
                Payment tp = new Payment();
                tp.show();
                TP.Show();
                this.Hide();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void hregular_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hotelname_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hotel ht = new Hotel();
            ht.Hotels();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void hfname_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void hflname_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void hpp_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
