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
    public partial class TPB : Form
    {
        public TPB()
        {
            InitializeComponent();
        }

        private void Platinum_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void Gold_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void regular_CheckedChanged(object sender, EventArgs e)
        { 
         
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void TPB_Load(object sender, EventArgs e)
            
        {  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Fursan f = new Fursan();
            if (f.check==1)
            {
                label2.Visible = true;
                label2.ForeColor = Color.Green;
                label2.Text = "LOOGED IN ";
            }
            else { label2.Visible = false; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Payment PT = new Payment();
            PT.payment();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
