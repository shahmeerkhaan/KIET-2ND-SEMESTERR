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
    public partial class Senior_Quiz_2 : Form
    {
        public Senior_Quiz_2()
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
            Application.Exit();
        }
        public void Quiz_Checker()
        {
            DAO SQW2 = new DAO();
            if (Spiral.Checked == true)
            {
                SQW2.Q2q1 += 1;
            }
            else
            {
                SQW2.Q2q1 += 0;
            }
            if (temparature.Checked == true)
            {
                SQW2.Q2q2 += 1;
            }
            else
            {
                SQW2.Q2q2 += 0;
            }
            if (__60.Checked == true)
            {
                SQW2.Q2q3 += 1;
            }
            else
            {
                SQW2.Q2q3 += 0;
            }
            if (Newton.Checked == true)
            {
                SQW2.Q2q4 += 1;
            }
            else
            {
                SQW2.Q2q4 += 0;
            }
            if (_5.Checked == true)
            {
                SQW2.Q2q5 += 1;
            }
            else
            {
                SQW2.Q2q5 += 0;
            }
            MessageBox.Show("Your Score in High level is " + SQW2.Quiz2());
            SQW2.Quiz2_Marks_Insertion();
            MessageBox.Show("Correct Answers were: " + "\n*Medium Level:\nQ1: P=F/A\nQ2: V=IxR\nQ3: 4th State of Matter\nQ4: False\nQ5: Vacuum Tubes" +
                "\n*High Level:\nQ1: Spiral\nQ2: Temparature\nQ3: 60\nQ4: N\nQ5: 0.07");
        }
    }
}
