using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace _12113_Shahmeer_s_OOP_LAB_ASSIGNMENT_2
{
    class DAO
    {
        private string Connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Kiet 2nd Semester\OOP LAB\OOP LAB ASSIGNMENT 2\12113 Shahmeer's OOP LAB ASSIGNMENT 2 Database.accdb";
        private DataTable LoginData = new DataTable();
        private static string name, type, type_id;
        public int Q1q1 = 0, Q1q2 = 0, Q1q3 = 0, Q1q4 = 0, Q1q5 = 0;
        public int Q1;
        public int Q2q1 = 0, Q2q2 = 0, Q2q3 = 0, Q2q4 = 0, Q2q5 = 0;
        public int Q2;
        public void Login(string Name, string Type, string ID, string Password)//polymorphism type of contructor overloading
        {
            string Querry = "Select * From LoginData";
            OleDbConnection CONNECTION = new OleDbConnection(Connection);
            CONNECTION.Open();
            OleDbCommand CMD = new OleDbCommand(Querry, CONNECTION);
            OleDbDataAdapter DataAdapter = new OleDbDataAdapter(CMD);
            DataAdapter.Fill(LoginData);
            if (ID == LoginData.Rows[0]["LoginID"].ToString() && Password == LoginData.Rows[0]["Password"].ToString() && Type == LoginData.Rows[0]["Type"].ToString())
            {
                Junior_Quiz_1 JQ1 = new Junior_Quiz_1();
                JQ1.Show();
                CONNECTION.Close();
                StsLoginAttState(Name, Type, ID);
            }
            else if(ID == LoginData.Rows[1]["LoginID"].ToString() && Password == LoginData.Rows[1]["Password"].ToString() && Type == LoginData.Rows[1]["Type"].ToString())
            {
                Senior_Quiz_1 SQ1 = new Senior_Quiz_1();
                SQ1.Show();
                CONNECTION.Close();
                StsLoginAttState(Name, Type, ID);
            }
            else
            {
                MessageBox.Show("Invalid ID or/and Password");
                CONNECTION.Close();
            }
        }
        public void StsLoginAttState(string Name, string Type, string ID)
        {
            name = Name;//to save the textboxes values in static strings to be used for another work of data insertion
            type = Type;//to save the textboxes values in static strings to be used for another work of data insertion
            type_id = ID;//to save the textboxes values in static strings to be used for another work of data insertion
            //This method will work as attendance marker like it will save the data through name, ID textbox and comboxbox into the data base
            //whichever student will try to login for the quiz automatically
            string querry = "Insert into LoginStdAtt([Name],[Type],[Type_ID],[Attendance]) values ('" + Name + "', '" + Type + "', '" + ID + "', '" + "P" + "')";
            CONNECTION(querry);
        }
        public void CONNECTION(string QUERRY)
        {
            OleDbConnection CON = new OleDbConnection(Connection);
            OleDbCommand cmd = new OleDbCommand(QUERRY, CON);
            CON.Open();
            int a = cmd.ExecuteNonQuery();
            if (a <= 0)
            {
                MessageBox.Show("Students Data Insertion Failed!!!");
            }
            CON.Close();
        }
        public int Quiz1()
        {
            Q1 = Q1q1 + Q1q2 + Q1q3 + Q1q4 + Q1q5;
            return Q1;
        }
        public int Quiz2()
        {
            Q2 = Q2q1 + Q2q2 + Q2q3 + Q2q4 + Q2q5;
            return Q2;
        }
        public void Quiz1_Marks_Insertion()
        {
            int Q1 = Quiz1();
            string QUERRY = "Insert into Quiz1_Scores([Name],[Type],[Type_ID],[Scores]) values ('" + name + "', '" + type + "', '" + type_id + "', '" + Q1.ToString() + "')";
            CONNECTION(QUERRY);
        }
        public void Quiz2_Marks_Insertion()
        {
            int Q2 = Quiz2();
            string QUERRY = "Insert into Quiz2_Scores([Name],[Type],[Type_ID],[Scores]) values ('" + name + "', '" + type + "', '" + type_id + "', '" + Q2.ToString() + "')";
            CONNECTION(QUERRY);
        }
    }
}
