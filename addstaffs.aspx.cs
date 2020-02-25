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
    public partial class addstaffs : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        private string usernme = "";
        private string username = "";
        private string firstname = "";
        private string lastname = "";
        private string emaill = "";
        private string phonee = "";
        private string address = "";
        private string gender = "";
        private string password = "";
        private string department = "";
        private string a = "8";
        private string role = "Lecturer";
        string passwordString = "";
        string passwordStrings = "";
        string passw = "";
        string passw2 = "";
        private string role2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionString();
        }
        protected void Button1_Click(object sender, EventArgs e)
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
            passwordgen.Text = passwordString;
    

        }  
        protected void Button2_Click(object sender, EventArgs e)
        {
            string allowedCharss = "";
            allowedCharss = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
            allowedCharss += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedCharss += "1,2,3,4,5,6,7,8,9,0";
            char[] sep = { ',' };
            string[] arr = allowedCharss.Split(sep);

            string temps = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(a); i++)
            {
                temps = arr[rand.Next(0, arr.Length)];
                passwordStrings += temps;
                passw2 = passwordStrings;
            }
            passwordgen1.Text = passwordStrings;
  }
        protected void Buttonreg_Click (object sender, EventArgs e)
        {
            usernme = user.Value;
            firstname = fname.Value;
            lastname = lname.Value;
            emaill = mail.Value;
            department = dept.Value;
            phonee = phone.Value;
            passw = passwordgen.Text.Trim();
            gender = radiomale.Checked ? "Male" : "Female";
        
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                if (string.IsNullOrEmpty(usernme) || string.IsNullOrEmpty(emaill) || string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(department) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(phonee) || string.IsNullOrEmpty(passw))

                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errord()", true);
                }
                else
                {
                    string query = "INSERT into staffs (Username,Firstname,Lastname,Email,Department,Phone,Gender,Password,Role) VALUES (@username,@firstname,@lastname,@emaill,@department,@phonee,@gender,@passw,@role)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@username", usernme));
                    cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                    cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                    cmd.Parameters.Add(new SqlParameter("@emaill", emaill));
                    cmd.Parameters.Add(new SqlParameter("@department", department));
                    cmd.Parameters.Add(new SqlParameter("@phonee", phonee));
                    cmd.Parameters.Add(new SqlParameter("@gender", gender));
                    cmd.Parameters.Add(new SqlParameter("@passw", passw));
                    cmd.Parameters.Add(new SqlParameter("@role", role));


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
        protected void Buttonmod_Click(object sender, EventArgs e)
        {
            usernme = user2.Value;
            firstname = first2.Value;
            lastname = last2.Value;
            emaill = mail2.Value;
            phonee = phone2.Value;
            passw2 = passwordgen1.Text.Trim();
            gender = radiomale2.Checked ? "Male" : "Female";
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                if (string.IsNullOrEmpty(usernme) || string.IsNullOrEmpty(emaill) || string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(phonee) || string.IsNullOrEmpty(passw2))

                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errord()", true);
                }
                else
                {
                    string query = "INSERT into staffs (Username,Firstname,Lastname,Email,Department,Phone,Gender,Password,Role) VALUES (@username,@firstname,@lastname,@emaill,@department,@phonee,@gender,@passw2,@role2)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@usernme", usernme));
                    cmd.Parameters.Add(new SqlParameter("@firstname", firstname));
                    cmd.Parameters.Add(new SqlParameter("@lastname", lastname));
                    cmd.Parameters.Add(new SqlParameter("@emaill", emaill));
                    cmd.Parameters.Add(new SqlParameter("@phonee", phonee));
                    cmd.Parameters.Add(new SqlParameter("@gender", gender));
                    cmd.Parameters.Add(new SqlParameter("@passw", passw));
                    cmd.Parameters.Add(new SqlParameter("@role2", role2));


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