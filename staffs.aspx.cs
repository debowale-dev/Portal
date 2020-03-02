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
    public partial class staffs : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        private string username = "";
        private string password = "";
        private string rolelog = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            username = userno.Value;
            password = pass.Value;
            Session["Username"] = username;
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "select Username, Password, Role FROM staffs where Username=@Username AND Password=@Password; ";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));


                SqlDataReader readr = cmd.ExecuteReader();
                string userlog = "";
                string pswlog = "";
                string rolelog = "";
                while (readr.Read())
                {
                    userlog = readr[0].ToString();
                    pswlog = readr[1].ToString();
                    rolelog = readr[2].ToString();
                    if (userlog == username && pswlog == password)
                    {
                        Session["Rolelog"] = rolelog;
                        Response.Redirect("staffboard.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errorc()", true);
                    }
                }
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errorc()", true);

                con.Close();
            }
        }

    }
}
