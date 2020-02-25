using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace umisportal
{
    public partial class accessdenied : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        string username = "";
        string md = "Moderator";
        string newpassword = "";
        string rolelog = "";
        string st = "Student";

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                SessionString();

                if (string.IsNullOrEmpty(username))
                {
                    Response.Redirect("error.aspx");
                }
    
            }
            catch (Exception ex)
            {

            }
            try
            {
                string username = Session["Username"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
            private void SessionString()
            {

            try
            {
                rolelog = Session["Rolelog"].ToString();
                username = Session["Username"].ToString();
                usernamelabel.Text = username;
                namelabel.Text = username;
            }
            catch (Exception ex)
            {

            }


        }
    }
}
