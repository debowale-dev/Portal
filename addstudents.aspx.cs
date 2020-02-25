using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace umisportal
{
    
    public partial class addstudents : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;

        private string username = "";
        private string firstname = "";
        private string lastname = "";
        private string emaill = "";
        private string phonee = "";
        private string address = "";
        private string coursee = "";
        private string gender = "";
        private string password = "";
        private string department = "";
        private string a = "8";
        private string role = "Student";
        private string Amountpaid = "0";
        private string Amountleft = "0";
        private string Totalfees = "0";
        private string Registeredstatus = "NO";
        private string Financialstatus = "NO";
        string usern = "";

        string passwordString = "";
        string passwordStrings = "";
        string passw = "";
    
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionString();
        }
        protected void GeneratePass()
        {
            string allowedChars = "";
            allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "1,2,3,4,5,6,7,8,9,0";
            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);

            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(a); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
                passw = passwordString;
            }
        }
        protected void FetchUsername()
        {
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "";
                query = "SELECT Username FROM batch18 WHERE UserId=(SELECT max(UserID) FROM batch18)";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader readr = cmd.ExecuteReader();
                while (readr.Read())
                {
                    usern = readr[0].ToString();
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        protected void Buttonreg_Click(Object sender, EventArgs e)
        { 
            firstname = fname.Value;
            lastname = lname.Value;
            emaill = mail.Value;
            //coursee = course.Value;
            phonee = phone.Value;
            gender = radiomale.Checked ? "Male" : "Female";

            FetchUsername();
            GeneratePass();

            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(emaill) || string.IsNullOrEmpty(firstname) /*|| string.IsNullOrEmpty(coursee) || string.IsNullOrEmpty(department) */|| string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(phonee) || string.IsNullOrEmpty(passw))

                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errord()", true);
                }
                else
                {
                    string query = "INSERT into batch18 (Username,Firstname,Lastname,Email,Phone,Gender,Password,Role,Amountpaid,Amountleft,Totalfees,Financialstatus,Registeredstatus) VALUES (@username,@firstname,@lastname,@emaill,@coursee,@department,@phonee,@gender,@passw,@role,@Amountpaid,@Amountleft,@Totalfees,@Financialstatus,@Registeredstatus)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                    cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                    cmd.Parameters.Add(new SqlParameter("@emaill", emaill));
                    cmd.Parameters.Add(new SqlParameter("@coursee", coursee));
                    cmd.Parameters.Add(new SqlParameter("@department", department));
                    cmd.Parameters.Add(new SqlParameter("@phonee", phonee));
                    cmd.Parameters.Add(new SqlParameter("@gender", gender));
                    cmd.Parameters.Add(new SqlParameter("@passw", passw));
                    cmd.Parameters.Add(new SqlParameter("@role", role));
                    cmd.Parameters.Add(new SqlParameter("@Amountpaid", Amountpaid));
                    cmd.Parameters.Add(new SqlParameter("@Amountleft", Amountleft));
                    cmd.Parameters.Add(new SqlParameter("@Totalfees", Totalfees));
                    cmd.Parameters.Add(new SqlParameter("@Financialstatus", Financialstatus));
                    cmd.Parameters.Add(new SqlParameter("@Registeredstatus", Registeredstatus));


                    try
                    {

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.ToLower().Contains("duplicate key"))
                        {

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "erroruser()", true);
                        }

                    }
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "successadd()", true);

                }
                con.Close();
            }
        }
       
        protected void SessionString()
        {
            username = Session["Username"].ToString();
            usernamelabel.Text = username;
        }
    }
}