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
    public partial class Junior_Quiz_1 : Form
    {
        public Junior_Quiz_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quiz1_Checker();
            Junior_Quiz_2 JQ2 = new Junior_Quiz_2();
            JQ2.Show();
        }
        Login_Main Lm = new Login_Main();
        public void Quiz1_Checker()
        {
            DAO JQW1 = new DAO();
            if (F5.Checked == true)
            {
                JQW1.Q1q1 += 1;
            }
            else
            {
                JQW1.Q1q1 += 0;
            }
            if (Distance.Checked == true)
            {
                JQW1.Q1q2 += 1;
            }
            else
            {
                JQW1.Q1q2 += 0;
            }
            if (Liquid.Checked == true)
            {
                JQW1.Q1q3 += 1;
            }
            else
            {
                JQW1.Q1q3 += 0;
            }
            if (_1939.Checked == true)
            {
                JQW1.Q1q4 += 1;
            }
            else
            {
                JQW1.Q1q4 += 0;
            }
            if (_1.Checked == true)
            {
                JQW1.Q1q5 += 1;
            }
            else
            {
                JQW1.Q1q5 += 0;
            }
            MessageBox.Show("Your Score in Medium level is " + JQW1.Quiz1());
            JQW1.Quiz1_Marks_Insertion();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
