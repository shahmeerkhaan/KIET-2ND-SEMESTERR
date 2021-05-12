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
using System.IO;
using System.Text.RegularExpressions;

namespace Travel
{
        public  class Destination 
    {
        
        public string location = "KARACHI , KHI";
    }
        public class Identity 
    {
        
        public string FirstName;
        public string LastName;
        public int Age;
        public Int64 PassportNumber;
        public string residency;
        public string email;
        public string nationality;

  
    }
    public class Airline : Identity, Billing, Information

    {
        TICKET tkchange = Application.OpenForms.OfType<TICKET>().FirstOrDefault();
        VISA CHANGE = Application.OpenForms.OfType<VISA>().FirstOrDefault();
        public int passengers;
        public string depdate;
        public string returndate;
        public string trclass;
        public string arrivalairport;
        public string ope;
        public string via;
        public double tkbill = 1000;
        public void passing()
        {
            TICKET tk = new TICKET();
            try
            {
                tkchange.tkfname.Text = CHANGE.vsfname.Text;
                tkchange.tklname.Text = CHANGE.vslname.Text;
                tkchange.tkage.Text = Convert.ToString(CHANGE.vsageupdown.Value);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Exception Unhandled",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
        public void AssignValues()
        {   if (tkchange.flightoperators.Text != null && tkchange.arrivalairports.Text != null && tkchange.tkpassengers.Value !=0 && tkchange.tkDF.Checked != false || tkchange.tkMC.Checked !=false)
            {   
                depdate = tkchange.tkdepdate.Text;
                returndate = tkchange.tkreturndate.Text;
                arrivalairport = tkchange.arrivalairports.Text;
                via = tkchange.tklayover.Text;
                ope = tkchange.flightoperators.Text;
                if (tkchange.tkfirst.Checked == true) { trclass = tkchange.tkfirst.Text; }
                if (tkchange.tkbuisness.Checked == true) { trclass = tkchange.tkbuisness.Text; }
                else { trclass = tkchange.tkeconomy.Text; }
                if (tkchange.tkDF.Checked == true)
                {
                    DOperations dao = new DOperations();
                    dao.dest(Convert.ToInt64(CHANGE.vsppnumber.Text), CHANGE.vsfname.Text, CHANGE.vslname.Text, depdate, returndate, "KARACHI , KHI", arrivalairport, ope, trclass);
                }
                 if (tkchange.tkMC.Checked == true)
                {
                    DOperations dao = new DOperations();
                    dao.dest(Convert.ToInt64(CHANGE.vsppnumber.Text), CHANGE.vsfname.Text, CHANGE.vslname.Text, depdate, returndate, "KARACHI , KHI", arrivalairport, via, ope, trclass);
                }
            }
        else { MessageBox.Show("Please Fill in All the Fields ", "Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }
        public void ShowInformation()
        {
            Destination dt = new Destination();
            MessageBox.Show("Your flight will be indirect from \n" + dt.location + "\nto \n" + tkchange.arrivalairports.Text + "\nvia\n" + tkchange.tklayover.Text + "." +
                     " ", "Indirect Flight", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Clear()
        {
            tkchange.tkDF.Checked = false;
            tkchange.tkMC.Checked = false;
            tkchange.flightoperators.Text = null;
            tkchange.arrivalairports.Text = null;
            tkchange.tkeconomy.Checked = false;
            tkchange.tkfirst.Checked = false;
            tkchange.tkbuisness.Checked = false;
            tkchange.tkregular.Checked = false;
            tkchange.tkspecial.Checked = false;
            tkchange.tkvegan.Checked = false;
            tkchange.tknoofbags.Value = 0;
            tkchange.tkpassengers.Value = 0;
            tkchange.labelayover.Visible = false;
            tkchange.tklayover.Visible = false;
            tkchange.tklayover.Text = "";
            MessageBox.Show("All entered data has been cleared","Cleared",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public void layovers()
        {
            if (tkchange.flightoperators.SelectedIndex == 1)
            {
                tkchange.tklayover.Text = "Riyadh , RUH";
            }
            if (tkchange.flightoperators.SelectedIndex == 0)
            {
                tkchange.tklayover.Text = "Islamabad , ISB";
            }
            if (tkchange.flightoperators.SelectedIndex == 2)
            {
                tkchange.tklayover.Text = "Dubai , DXB";
            }
            if (tkchange.flightoperators.SelectedIndex == 3)
            {
                tkchange.tklayover.Text = "BAHRAIN , BAH";
            }
            if (tkchange.flightoperators.SelectedIndex == 4)
            {
                tkchange.tklayover.Text = "Muscat , MCT";
            }
        }
        public void ShowBill()
        { 
            if (tkchange.tkMC.Checked==true)
            {
                tkbill = tkbill - 150;
                ShowInformation();
                    
            }
            else { tkchange.tkDF.Checked=true;
                Destination dt = new Destination();
                MessageBox.Show("Your flight will be Direct from \n" + dt.location + "\nto \n" + tkchange.arrivalairports.Text + "", "Direct Flight", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (tkchange.tkbuisness.Checked==true)
            {
                tkbill += 200;
            }
            else if (tkchange.tkfirst.Checked==true)
            { tkbill += 400; }
            else { tkchange.tkeconomy.Checked = true; }
            if (tkchange.tkspecial.Checked==true)
            {
                tkbill += 20;
            }
            else if (tkchange.tkvegan.Checked==true)
            {
                tkbill += 40;
            }
            else { tkchange.tkregular.Checked = true; }
            tkbill += Convert.ToDouble(tkchange.tknoofbags.Value) * 20;
            MessageBox.Show("Bill For Ticket Booking : " + tkbill + " PKR", "Bill",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


    }
  
    public class Card 
    {
        public double Credit=50000;
        
    }
    public class GoldCard : Card
    {   
        public double discount = 0.85;

        public void payment()           
        {   Credit = 100000;
           
        }
    }
    public class PlatCard : Card
    {
        public double discount = 0.75;
        public void payment()
        {
            Credit = 200000;
            
        }
    }
    public class Visa : Identity,Billing , Information  
    {
        public double e;
        public string visatype;
        public double vsbill = 2500;
        public void AssignValues()
        {   
            int a = 0;
            if (Regex.IsMatch(CHANGE.vsemailid.Text, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z"))
            { email = CHANGE.vsemailid.Text; }
            else { a++; }
            if (CHANGE.vsfname.Text!="" && CHANGE.vslname.Text !="" && CHANGE.vsageupdown.Value!=0 && CHANGE.vsnatiionality.Text !="" && 
                CHANGE.vsppnumber.Text !="" && CHANGE.vsemailid.Text != "" && CHANGE.vsaddress.Text != "" && CHANGE.vsvisatype.Text !="" 
                && CHANGE.vsppnumber.Text.Length < 8 && CHANGE.vsppnumber.Text.Length > 6 && a==0 && CHANGE.photo.Image!=null)
            { FirstName = CHANGE.vsfname.Text;
                LastName = CHANGE.vslname.Text;
                Age = Convert.ToInt32(CHANGE.vsageupdown.Value);
                nationality = CHANGE.vsnatiionality.Text;
                PassportNumber = Convert.ToInt64(CHANGE.vsppnumber.Text);
                residency = CHANGE.vsaddress.Text;
                visatype = CHANGE.vsvisatype.Text;
                ShowInformation();

                DOperations dao = new DOperations();
                dao.ApplyVisa(FirstName, LastName, Age, nationality, PassportNumber, email, residency, visatype);
            }
        
        else
            {   if (a!=0)
                { MessageBox.Show("Please enter a valid email address. ", "Invalid Email Entered", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                if (CHANGE.vsppnumber.TextLength != 7)
                { MessageBox.Show("Please enter a passport number which has 7 digits", "Invalid Passport Number", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                if (CHANGE.photo.Image==null)
                { MessageBox.Show("Please upload a recent passport size photo","NO photo Uploaded",MessageBoxButtons.OK,MessageBoxIcon.Error); }
                if (CHANGE.vsfname.Text == "" || CHANGE.vslname.Text == "" || CHANGE.vsageupdown.Value == 0 || CHANGE.vsnatiionality.Text == "" ||
                    CHANGE.vsppnumber.Text == "" || CHANGE.vsemailid.Text == "" || CHANGE.vsaddress.Text == "" || CHANGE.vsvisatype.Text == "") 
                MessageBox.Show("Please Fill in All the Fields ","Fields Missing",MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }
        }
        public static bool IsValidEmail(string email)
        {
            VISA vs = new VISA();
            vs.vsemailid.Text = email;
            return Regex.IsMatch(email, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z")
                && Regex.IsMatch(email, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
        }

        public void ShowInformation()
        {
            MessageBox.Show("These are the values you entered : " + "\nFirst Name : " + FirstName + "\nLast Name : " + LastName + "\nAge : " + Age +
                "\nNationality : " + nationality + "\nPassport Number : " + PassportNumber + "\nEmail ID : " + email + "\nAddress : " + residency +
               "\nVisa Type : " + visatype, "Apply Visa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ShowBill()
        {
            MessageBox.Show("Visa applications charges are : " +vsbill+ " PKR","Bill",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
         VISA CHANGE = Application.OpenForms.OfType<VISA>().FirstOrDefault();
        public void ClearData()
        {
            CHANGE.vsfname.Text = "";
            CHANGE.vslname.Text = "";
            CHANGE.vsageupdown.Value = 0;
            CHANGE.vsppnumber.Text = "";
            CHANGE.vsnatiionality.Text = "";
            CHANGE.vsemailid.Text = "";
            CHANGE.vsaddress.Text = "";
            CHANGE.photo.Image = null;
            CHANGE.vsvisatype.Text = null;
            MessageBox.Show(" All Text Values entered have been cleared ."," CLEARED " , MessageBoxButtons.OK ,MessageBoxIcon.Information);
        }
        public void uploadPhoto()
        {
            OpenFileDialog tasweer = new OpenFileDialog();
            tasweer.Title = "SELECT IMAGE";
            tasweer.Filter = "Image Files(*.PNG;*.BMP;*.JPG;*.GIF)|*.PNG;*.BMP;*.JPG;*.GIF";
            if (tasweer.ShowDialog() == DialogResult.OK)
            {
                CHANGE.photo.Image = new Bitmap(tasweer.FileName);
            }

        }
        public byte[] SaveImage()
        {
            MemoryStream mem = new MemoryStream();
            CHANGE.photo.Image.Save(mem, CHANGE.photo.Image.RawFormat);
            return mem.GetBuffer();
        }
    }
    public class Hotel : Identity ,Billing , Information 
    {
        HOTEL hchange = Application.OpenForms.OfType<HOTEL>().FirstOrDefault();
        VISA CHANGE = Application.OpenForms.OfType<VISA>().FirstOrDefault();
        TICKET tk = new TICKET();
        public string hname;
        public int rooms;
        public string roomtype;
        public string transport;
        public double hbill=1000;
        public int net;
        public int rate;
        public int days;
        public void Hotels()
        {
            HOTEL ht = new HOTEL();
            if (hchange.hotelname.SelectedIndex==0 || hchange.hotelname.SelectedIndex==4)
            {
                rate = 550;
            }
            else { rate = 350; }
        }
        public void passing()
        {  
            Visa vs = new Visa();
            try
            {
                hchange.hfname.Text = CHANGE.vsfname.Text;
                hchange.hflname.Text = CHANGE.vslname.Text;
                hchange.hpp.Text = (CHANGE.vsppnumber.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Exception unhandled", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        public void Assignvalues()
        {
            HOTEL ht = new HOTEL();
            if (ht.hotelname.Text != "" && ht.roomtype.Text != "" && ht.roomsno.Value != 0 && ht.transport.Text != "" &&
                 ht.days.Value != 0)
            {
                MessageBox.Show("Please fill all teh fields","Fields Missing",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else {
                hname = hchange.hotelname.Text;
                roomtype = hchange.roomtype.Text;
                rooms = Convert.ToInt32(hchange.roomsno.Value);
                transport = hchange.transport.Text;
                days = Convert.ToInt32(hchange.days.Value);
                if (hchange.hspecial.Checked == true) { hbill += 50; }
                if (hchange.hvegan.Checked == true) { hbill += 100; }
                else { hchange.hregular.Checked = true; hbill += 20; }
                if (hchange.hundredmbs.Checked == true) { hbill += 100; }
                else { hchange.fiftymbs.Checked = true; hbill += 50; }
                int a = Convert.ToInt32(hchange.roomsno.Value) * rate;
                hbill += Convert.ToInt32(ht.days.Value) * a;
                MessageBox.Show(hname);
                DOperations dao = new DOperations();
                dao.bookhotel(hname, rooms, days, transport, roomtype);
                ShowInformation();
                ShowBill();
            }

        }
        public void ShowInformation()
        {
            MessageBox.Show("You have booked " +rooms+ " rooms for "+days+" and you will stay at "+hname+". You will be picked up by a "+transport+" " +
                "from your home to the airport and from the airport to the hotel . ","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);   
        }
        public void ShowBill()
        {
            MessageBox.Show("Your Bill for Hotel Booking : " + hbill,"Bill",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
    public class Payment
    {
     
        public double finalbill;
        public void show()
        {
            
        }   public void payment()
        {
            TPB TT = Application.OpenForms.OfType<TPB>().FirstOrDefault();
            Fursan l = new Fursan();
            PlatCard pc = new PlatCard();
            Airline air = new Airline();
            double final;
            double a = 2500;
            Hotel gt = new Hotel();
            final = a + air.tkbill + gt.hbill;
            final = final * 1.24;
            MessageBox.Show("Your Final bill is : " + final, " BILL ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(l.check==1)
            { final = final - 500;
                MessageBox.Show("You have recieved a flat discount of 500 PKR for being a Fursan Member , your bill now is : " +final,"Fursan account logged in",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
             if (TT.pcard.Checked == true)
            {
                pc.Credit = 200000;
                final = final * pc.discount;
                MessageBox.Show(Convert.ToString(final));
                pc.Credit = pc.Credit - final;
                MessageBox.Show("YOU HAVE RECIEVED A 25% FOR BEING A PLATCARD OWNER AND YOUR BILL NOW IS : " + final + " \nYour payment has been received ," +
                    " deducted from your credit . Your remaining balance is : " + pc.Credit + " Thank you for choosing BABAJI TRAVEL AGENCY", "Payment Rceived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TT.Close();
                Home hm = new Home();
                hm.Show();
            }
            else if (TT.gcard.Checked == true)
            {
                GoldCard gc = new GoldCard();
                gc.Credit = 100000;
                final = final * gc.discount;
                gc.Credit = gc.Credit - final;
                MessageBox.Show("YOU HAVE RECIEVED A 15% FOR BEING A GOLDCARD OWNER AND YOUR BILL NOW IS : " + final + " \nYour payment has been received ," +
                    " deducted from your credit . Your remaining balance is : " + gc.Credit + " Thank you for choosing BABAJI TRAVEL AGENCY", "Payment Rceived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TT.Hide();
                Home hm = new Home();
                hm.Show();

            }
            else if (TT.ccard.Checked == true)
            {
                Card c = new Card();
                c.Credit = c.Credit - final;
                MessageBox.Show(" YOUR BILL IS : " + final + " Your payment has been received ," +
                   " deducted from your credit . Your remaining balance is : " + c.Credit + " Thank you for choosing BABAJI TRAVEL AGENCY", "Payment Rceived", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TT.Close();
                Home hm = new Home();
                hm.Show();

            }
            else { MessageBox.Show("Please select card type", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }
       
    }
    public interface Billing
    {
        void ShowBill();
    }
    public interface Information
    {
        void ShowInformation();
    }
    public sealed class Fursan : Identity
    {   public int check =0;
        private string password;
        FURSANSIGNUP fs = Application.OpenForms.OfType<FURSANSIGNUP>().FirstOrDefault();
        public void AssignValues()
        { if (fs.fursanaccfname.Text!="" && fs.fursanacclname.Text!="" && fs.fursannationality.Text != "" && fs.fursanaccpp.Text!="" 
                && fs.fursanaccpass.Text!="" && fs.fursanacccnfrmpass.Text!= "" && fs.fursanaccpass.Text==fs.fursanacccnfrmpass.Text && fs.fursanaccpp.Text.Length ==7 )
            {
                FirstName = fs.fursanaccfname.Text;
                LastName = fs.fursanacclname.Text;
                nationality = fs.fursannationality.Text;
                PassportNumber = Convert.ToInt64(fs.fursanaccpp.Text);
                password = fs.fursanaccpass.Text;
                DOperations dao = new DOperations();
                dao.signup(FirstName, LastName, nationality, PassportNumber, password);
            }
              
        else
            {
                if (fs.fursanaccfname.Text == "" || fs.fursanacclname.Text == "" || fs.fursannationality.Text == "" || fs.fursanaccpp.Text == ""
                || fs.fursanaccpass.Text == "" || fs.fursanacccnfrmpass.Text == "") { MessageBox.Show("Please fill in all the fields", "Fields Mising", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                if (fs.fursanaccpass.Text != fs.fursanacccnfrmpass.Text) { MessageBox.Show("Your entered password and confirm passwords do not match","Fursan Signup",MessageBoxButtons.OK,MessageBoxIcon.Error); }
                if(fs.fursanaccpp.Text.Length!=7) { MessageBox.Show("Please enter a passport number of 7 digits", "SIGN UP", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                
            }

        }
        public void clear()
        {
            fs.fursanaccfname.Text = "";
            fs.fursanacclname.Text = "";
            fs.fursannationality.Text = "";
            fs.fursanaccpp.Text = "";
            fs.fursanaccpass.Text = "";
            fs.fursanacccnfrmpass.Text = "";
            MessageBox.Show(" All Text Values entered have been cleared .", " CLEARED ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class DOperations : Hotel
    {    
        SqlConnection connec = new SqlConnection("Data Source=DESKTOP-SVVMCOI;Initial Catalog=Travel;Integrated Security=True");
        FURSAN F = Application.OpenForms.OfType<FURSAN>().FirstOrDefault();
        public void Login()
        {
            Int64 pp; 
            string pass;
            pp = Convert.ToInt64(F.fursanpp.Text);
            pass = F.fursanpass.Text;
            MessageBox.Show(Convert.ToString(pp));
            if (F.fursanpp.Text != "" && F.fursanpass.Text != "" && F.fursanpp.Text.Length ==7) { string query1 = "select ppnumber,pass from fursan where ppnumber = '" +pp + "' and pass = '" + pass+ "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query1, connec);
                connec.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Log In successful", "Log IN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Fursan f = new Fursan();
                    f.check = 1;
                    F.Hide();
                }
               else { MessageBox.Show("Incorrect Passport Number or password", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else { MessageBox.Show("Incorrect Passport Number or password","Log In",MessageBoxButtons.OK,MessageBoxIcon.Error);
             if (F.fursanpp.Text.Length !=7 ) { MessageBox.Show("Please enter passport number of 7 digits","Log In",MessageBoxButtons.OK,MessageBoxIcon.Error); }
             
            }
            connec.Close();
        }
        public void signup(string a , string b , string c , Int64 d , string e)
        {
            FirstName = a;
            LastName = b;
            nationality = c;
            PassportNumber = d;
            connec.Open();
            string query = "insert into fursan values (@ppnumber , @fname , @lname , @nationality , @pass)";
            SqlCommand cmd = new SqlCommand(query , connec);
            cmd.Parameters.AddWithValue("@ppnumber",PassportNumber);
            cmd.Parameters.AddWithValue("@fname",FirstName);
            cmd.Parameters.AddWithValue("@lname ",LastName);
            cmd.Parameters.AddWithValue("@nationality",nationality);
            cmd.Parameters.AddWithValue("pass",e);
            int x = cmd.ExecuteNonQuery();
            if (x > 0)
            {
                MessageBox.Show("Your account has been made succesfully.",
                "Account MADE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FURSANSIGNUP f = new FURSANSIGNUP();
                FURSAN fs = new FURSAN();
                f.Hide();

            }
            else { MessageBox.Show("Account registration unsuccesful.", "Make Account", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            connec.Close();
        }
        public void ApplyVisa(string ab, string b , int c , string d , Int64 e , string f , string g , string h)
        {
            Visa vs = new Visa();
            this.FirstName = ab;
            this.LastName = b;
            this.Age = c;
            this.nationality = d;
            this.PassportNumber = e;
            this.email = f;
            this.residency = g;
            vs.visatype = h;
            connec.Open();
            string query = "insert into VISAAPPLICATIONS values (@fname,@lname,@age,@nationality,@ppnumber,@email,@residency,@visatype,@photo)";
            SqlCommand command = new SqlCommand(query, connec);
            command.Parameters.AddWithValue("@fname", FirstName); ;
            command.Parameters.AddWithValue("@lname", LastName);
            command.Parameters.AddWithValue("@age", Age);
            command.Parameters.AddWithValue("@nationality", nationality);
            command.Parameters.AddWithValue("@ppnumber", PassportNumber);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@residency", residency);
            command.Parameters.AddWithValue("@visatype", vs.visatype);
            command.Parameters.AddWithValue("@photo", vs.SaveImage());
            int a = command.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Your Visa application has been submitted , You can proceed towards ticket booking now .",
                "Visa Succesfully Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vs.ShowBill();
                TICKET tk = new TICKET();
                tk.Show();
                VISA VS = new VISA();
                VS.Hide();
            }
            else { MessageBox.Show("Visa Application submission unsuccesful .", "Apply Visa", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            connec.Close();
        }
        public void bookhotel(string htname ,int rm , int dy , string trans , string rt)
        {
            VISA vs = Application.OpenForms.OfType<VISA>().FirstOrDefault();
            Hotel h = new Hotel();
            hname = htname;
            rooms = rm;
            days = dy;
            transport = trans;
            roomtype = rt;
            string fullname = vs.vsfname.Text + " " + vs.vslname.Text;
            connec.Open();
            string query = "insert into hotel values (@ppnumber,@fullname,@hotelname,@norooms,@noofdays,@transport ,@roomtype)";
            SqlCommand cmd = new SqlCommand(query , connec);
            cmd.Parameters.AddWithValue("@ppnumber",vs.vsppnumber.Text);
            cmd.Parameters.AddWithValue("@fullname",fullname);
            cmd.Parameters.AddWithValue("@hotelname",hname);
            cmd.Parameters.AddWithValue("@norooms",rooms);
            cmd.Parameters.AddWithValue("noofdays",days);
            cmd.Parameters.AddWithValue("@transport",transport);
            cmd.Parameters.AddWithValue("@roomtype",roomtype);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Your Hotel  has been booked succesfully , You'll proceed towards billing now .",
                "Hotel Succesfully Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                h.ShowBill();

            }
            else { MessageBox.Show("Hotel Booking unsuccesful .", "Hotel Booking", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            connec.Close();
        }
        public void cancelTicket()
        {
            cancel cancel = Application.OpenForms.OfType<cancel>().FirstOrDefault();
            if (cancel.cancelpp.Text.Length == 7)
            {
                string query = "Delete from ticket where ppnumber = '" + cancel.cancelpp.Text + "'";
                SqlCommand command = new SqlCommand(query, connec);
                connec.Open();
                command.ExecuteNonQuery();
                connec.Close();
                MessageBox.Show("Your Ticket has been cancelled successfully", "Ticket Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Please enter a passport number which has 7 digits", "Invalid Passport Number", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void cancelhotel()
        {
            cancel cancel = Application.OpenForms.OfType<cancel>().FirstOrDefault();
            if (cancel.cancelpp.Text.Length == 7)
            {               
                string query = "Delete from hotel where ppnumber = " + cancel.cancelpp.Text + " ";
                SqlCommand command = new SqlCommand(query, connec);
                connec.Open();
                command.ExecuteNonQuery();
                connec.Close();
                MessageBox.Show("Your Hotel Booking has been cancelled successfully", "Hotel Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void UDVisa()
        {
            cancel cancel = Application.OpenForms.OfType<cancel>().FirstOrDefault();
            if (cancel.cancelpp.Text.Length==7)
            { string query = "Delete from VISAAPPLICATIONS where ppnumber = '" + cancel.cancelpp.Text + "'";
                SqlCommand command = new SqlCommand(query, connec);
                connec.Open();
                command.ExecuteNonQuery();
                connec.Close();
                MessageBox.Show("Your Visa has been cancelled successfully", "Visa Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { MessageBox.Show("Please enter a passport number which has 7 digits", "Invalid Passport Number", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void UDVisa(string a)
        {   
            connec.Open();
            cancel update = Application.OpenForms.OfType<cancel>().FirstOrDefault();
            if (update.updatepp.Text.Length==7)             
            {
                string query1 = "select * from VISAAPPLICATIONS ppnumber where ppnumber= '"+update.updatepp.Text+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(query1 , connec);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {   
                    int check = 0;
                    if (Regex.IsMatch(update.updateemail.Text, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z"))
                    { check = 0; }
                    else { check++; }
                    if (update.updatefname.Text != "" &&
                        update.updatelname.Text != "" && update.updateage.Value != 0 && update.updateemail.Text != "" && update.updatevisatype.Text != ""
                        && update.updatepp.Text.Length < 8 && update.updatepp.Text.Length > 6 && check == 0)
                    {
                        string query = "update VISAAPPLICATIONS set fname = '" + update.updatefname.Text + "'  , lname = '" + update.updatelname.Text + "' ," +
                             " age = '" + update.updateage.Value + "' , email = '" + update.updateemail.Text + "' , visatype = '" + update.updatevisatype.Text + "' where ppnumber = '" + update.updatepp.Text + "'";
                        SqlCommand command = new SqlCommand(query, connec);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Your Visa has been updated successfully", "Visa Information Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (check != 0)
                        { MessageBox.Show("Please enter a valid email address. ", "Invalid Email Entered", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        if (update.updatepp.TextLength != 7)
                        { MessageBox.Show("Please enter a passport number which has 7 digits", "Invalid Passport Number", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        if (update.updatefname.Text == "" ||
                        update.updatelname.Text == "" || update.updateage.Value == 0 || update.updateemail.Text == "" || update.updatevisatype.Text == "")
                            MessageBox.Show("Please Fill in All the Fields ", "Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else { MessageBox.Show("Your Passport is valid , but either youve cancelled your visa or havent applied yet ", "Passport Number not found", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else  { MessageBox.Show("Please enter a passport number which has 7 digits", "Invalid Passport Number", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            connec.Close();
        }
        public static bool IsValidEmail(string email)
        {
            VISA vs = new VISA();
            vs.vsemailid.Text = email;
            return Regex.IsMatch(email, @"\A[a-z0-9]+([-._][a-z0-9]+)*@([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,4}\z")
                && Regex.IsMatch(email, @"^(?=.{1,64}@.{4,64}$)(?=.{6,100}$).*");
        }
        public void dest(Int64 pp, string firstname , string lastname , string departured , string rd , string ff , string tf , string op , string tr)
        {
            Airline air = new Airline();
            air.PassportNumber = pp;
            air.FirstName = firstname;
            air.LastName = lastname;
            air.depdate = departured;
            air.returndate = rd;
            ff = "KARACHI , KHI";
            air.arrivalairport = tf;
            air.via = "-";
            air.ope = op;
            air.trclass = tr;
            connec.Open();
            string query = "insert into ticket values (@ppnumber,@fname,@lname,@Depdate,@returndate ,@ff , @rf ,@via , @fo , @travelclass)";
            SqlCommand cmd = new SqlCommand(query,connec);
            cmd.Parameters.AddWithValue("@ppnumber", air.PassportNumber);
            cmd.Parameters.AddWithValue("@fname",air.FirstName);
            cmd.Parameters.AddWithValue("@lname",air.LastName);
            cmd.Parameters.AddWithValue("@Depdate",air.depdate);
            cmd.Parameters.AddWithValue("@returndate",air.returndate);
            cmd.Parameters.AddWithValue("@ff",ff);
            cmd.Parameters.AddWithValue("@rf",air.arrivalairport);
            cmd.Parameters.AddWithValue("@via",air.via);
            cmd.Parameters.AddWithValue("@fo",air.ope);
            cmd.Parameters.AddWithValue("@travelclass",air.trclass);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Your Ticket has been booked , You can proceed towards hotel booking now .",
                "Ticket Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                air.ShowBill();
                HOTEL ht = new HOTEL();
                ht.Show();
                TICKET tk = new TICKET();
                tk.Hide();
            }
            else { MessageBox.Show(" Ticket Booking unsuccesful .", "Book Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            connec.Close();
        }
        public void dest(Int64 pp,string firstname, string lastname, string departured, string rd, string ff, string tf, string v, string op, string tr)
        {
            Airline air = new Airline();
            air.PassportNumber = pp;
            air.FirstName = firstname;
            air.LastName = lastname;
            air.depdate = departured;
            air.returndate = rd;
            ff = "KARACHI , KHI";
            air.arrivalairport = tf;
            air.via = v;
            air.ope = op;
            air.trclass = tr;
            connec.Open();
            string query = "insert into ticket values (@ppnumber,@fname,@lname,@Depdate,@returndate, @ff , @rf ,@via , @fo , @travelclass)";
            SqlCommand cmd = new SqlCommand(query, connec);
            cmd.Parameters.AddWithValue("@ppnumber", air.PassportNumber);
            cmd.Parameters.AddWithValue("@fname", air.FirstName);
            cmd.Parameters.AddWithValue("@lname", air.LastName);
            cmd.Parameters.AddWithValue("@Depdate", air.depdate);
            cmd.Parameters.AddWithValue("@returndate", air.returndate);
            cmd.Parameters.AddWithValue("@ff", ff);
            cmd.Parameters.AddWithValue("@rf", air.arrivalairport);
            cmd.Parameters.AddWithValue("@via", air.via);
            cmd.Parameters.AddWithValue("@fo", air.ope);
            cmd.Parameters.AddWithValue("@travelclass", air.trclass);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Your Ticket has been booked , You can proceed towards hotel booking now .",
                  "Ticket Booked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                air.ShowBill();
                HOTEL ht = new HOTEL();
                ht.Show();
                TICKET tk = new TICKET();
                tk.Hide();
            }
            else { MessageBox.Show(" Ticket Booking unsuccesful .", "Book Ticket", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            connec.Close();
        }
    }
 
}
