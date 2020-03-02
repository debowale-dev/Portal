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
    public partial class register : System.Web.UI.Page
    {

        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        string username ="";
        string statuslog = "";
        string y = "YES";
        string n =  "NO";
        string p = "PENDING";
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionString();
            statuslabel.Visible = false;
            verifystatus();
        }
        protected void SessionString()
        {
            username = Session["Username"].ToString();
            usernamelabel.Text = username;
        }
        protected void verifystatus()
        {
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "select Financialstatus FROM batch18 where Username=@username";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@Username", username));

                SqlDataReader readr = cmd.ExecuteReader();
                while (readr.Read())
                {
                    statuslog = readr[0].ToString();

                   if (statuslog == y)
                    {
                        statuslabel.Visible = false;
                    }
                   else if (statuslog == n || statuslog == p)
                    {
                        statuslabel.Visible = true;
                    }
                   
                }
            }
        }

    }
}