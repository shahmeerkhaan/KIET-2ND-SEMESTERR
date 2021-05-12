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
    public partial class Junior_Quiz_2 : Form
    {
        public Junior_Quiz_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quiz2_Checker();
            Application.Exit();
        }
        public void Quiz2_Checker()
        {
            DAO JQW2 = new DAO();
            if(ctrlcv.Checked == true)
            {
                JQW2.Q2q1 += 1;
            }
            else
            {
                JQW2.Q2q1 += 0;
            }
            if(GA.Checked == true)
            {
                JQW2.Q2q2 += 1;
            }
            else
            {
                JQW2.Q2q2 += 0;
            }
            if(__1.Checked == true)
            {
                JQW2.Q2q3 += 1;
            }
            else
            {
                JQW2.Q2q3 += 0;
            }
            if(Speed.Checked == true)
            {
                JQW2.Q2q4 += 1;
            }
            else
            {
                JQW2.Q2q4 += 0;
            }
            if(_4096.Checked == true)
            {
                JQW2.Q2q5 += 1;
            }
            else
            {
                JQW2.Q2q5 += 0;
            }
            MessageBox.Show("Your Score in high level is " + JQW2.Quiz2());
            JQW2.Quiz2_Marks_Insertion();
            MessageBox.Show("Correct Answers were: " + "\n*Medium Level:\nQ1: F5\nQ2: S=VxT\nQ3: Liquid Form\nQ4: 1939\nQ5: 1" +
                "\n*High Level:\nQ1: ctrl c+ ctrlv\nQ2: 9.8 m/s^2\nQ3: -1\nQ4: m/s\nQ5: -4096");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
