using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12113_Shahmeer_s_OOP_LAB_ASSIGNMENT_2
{
    public partial class Senior_Quiz_1 : Form
    {
        public Senior_Quiz_1()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quiz_Checker();
            Senior_Quiz_2 SQ2 = new Senior_Quiz_2();
            SQ2.Show();
        }
        public void Quiz_Checker()
        {
            DAO SQW1 = new DAO();
            if (Pressure.Checked == true)
            {
                SQW1.Q1q1 += 1;
            }
            else
            {
                SQW1.Q1q1 += 0;
            }
            if (Ohms_Law.Checked == true)
            {
                SQW1.Q1q2 += 1;
            }
            else
            {
                SQW1.Q1q2 += 0;
            }
            if (Plasma.Checked == true)
            {
                SQW1.Q1q3 += 1;
            }
            else
            {
                SQW1.Q1q3 += 0;
            }
            if (False.Checked == true)
            {
                SQW1.Q1q4 += 1;
            }
            else
            {
                SQW1.Q1q4 += 0;
            }
            if (Computer1st.Checked == true)
            {
                SQW1.Q1q5 += 1;
            }
            else
            {
                SQW1.Q1q5 += 0;
            }
            MessageBox.Show("Your Quiz Total Score is " + SQW1.Quiz1());
            SQW1.Quiz1_Marks_Insertion();
        }
    }
}
