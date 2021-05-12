using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Travel
{
    public partial class TICKET : Form
    {
        SqlConnection connec = new SqlConnection("Data Source=DESKTOP-SVVMCOI;Initial Catalog=Travel;Integrated Security=True");
        public TICKET()
        { 
            InitializeComponent();


        }

        private void TICKET_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VISA vs = new VISA();
            vs.Show();
            this.Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {   try
            {
                Airline air = new Airline();
                air.AssignValues();
                Hotel ht = new Hotel();
                ht.passing();
                this.Hide();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Airline air = new Airline();
            air.Clear();
        }

        private void flightoperators_SelectedIndexChanged(object sender, EventArgs e)
        {  try
            {
                Airline air = new Airline();
                air.layovers();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void ShowAirlines()
        {
            string query1 = "select * from AIRLINES";
            SqlCommand cmd = new SqlCommand(query1, connec);
            try
            {
                connec.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    flightoperators.Items.Add(dr["airlines"].ToString());
                }

            }
            catch (Exception banana)
            {
                MessageBox.Show(banana.Message);
            }
            connec.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tkMC_CheckedChanged(object sender, EventArgs e)
        {try
            {
                if (tkMC.Checked == true)
                {
                    labelayover.Visible = true;
                    tklayover.Visible = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void tkDF_CheckedChanged(object sender, EventArgs e)
        {   try
            {
                if (tkDF.Checked == true)
                {
                    labelayover.Visible = false;
                    tklayover.Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception Unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void arrivalairports_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }
    }
}
