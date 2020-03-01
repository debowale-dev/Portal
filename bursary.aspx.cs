using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace umisportal
{
    public partial class bursary : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        private string username = "";
        private string password = "";
        private string rolelog="";
        string md = "Moderator";
        string lr = "Lecturer";
        private string text = "";
        //private string email = "";
        //private string phone = "";
        //private string financialstatus = "";
        //private string course = "";
        //private string department = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionString();
            if (rolelog != md)
            {
                Response.Redirect("accessdenied.aspx");
            }
            else
            {
                stafflabel.Visible = false;
                modlabel.Visible = false;

                if (rolelog == md)
                {
                    modlabel.Visible = true;
                    stafflabel.Visible = false;
                }
                else if (rolelog == lr)
                {

                    Response.Redirect("staffboard.aspx");
                }
            }
        }
        protected void Button1_Click (object sender, EventArgs e)
        {
            password = pass.Value;
           using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();

                string query = "SELECT Password FROM bursary where Username = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@Username", username));


                SqlDataReader readr = cmd.ExecuteReader();

                string passwordlog = "";
                
                while (readr.Read())
                {
                   passwordlog = readr[0].ToString();
                    if (passwordlog == password)
                    {
                        Response.Redirect("welcomeburser.aspx");
                    }
                    else
                    {

                    }
                }
                con.Close();
            }
        }
        private void SessionString()
        {
            try
            {

                username = Session["Username"].ToString();
                rolelog = Session["Rolelog"].ToString();
                usernamelabel.Text = username;
                outputlabel.Text = username;
            }
            catch (Exception ex)
            {

            }
        }
             

    }
}