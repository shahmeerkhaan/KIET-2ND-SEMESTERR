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
    public partial class Login_Main : Form
    {
        public Login_Main()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            DAO Login_work = new DAO();
            Login_work.Login(Name_Textbox.Text, TypeCombo.Text, ID_textbox.Text, Password_Textbox.Text);
        }
    }
}
