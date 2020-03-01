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
    public partial class changepass : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        string username = "";
        string password = "";
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
                    Response.Redirect("admin.aspx");
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
        protected void Button1_Click(object sender, EventArgs e)

        {
            if (rolelog == st)
            {

                if (IsPostBack)
                {
                    password = oldpass.Value;
                    newpassword = newpass.Value;
                    Session["Username"] = username;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        SessionString();

                        string query = "SELECT Password FROM batch18 WHERE username=@Username";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@Username", username));
                        SqlDataReader readr = cmd.ExecuteReader();
                        string oldlog = "";
                        while (readr.Read())

                            oldlog = readr[0].ToString();
                        {
                            if (password == oldlog)
                            {
                                string query2 = "UPDATE batch18 SET Password=@Newpassword WHERE Username=@Username";
                                SqlCommand cmd2 = new SqlCommand(query2, con);
                                cmd2.Parameters.Add(new SqlParameter("@Username", username));
                                cmd2.Parameters.Add(new SqlParameter("@Newpassword", newpassword));
                                newpassword = newpass.Value;
                                readr.Close();
                                cmd2.ExecuteNonQuery();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "success()", true);

                            }

                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errorchange()", true);
                            }

                            readr.Close();
                            cmd.ExecuteNonQuery();

                            con.Close();
                        }
                    }
                }
            }
            else
            {
                if (IsPostBack)
                {
                    password = oldpass.Value;
                    newpassword = newpass.Value;
                    Session["Username"] = username;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        SessionString();

                        string query = "SELECT Password FROM staffs WHERE username=@Username";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.Add(new SqlParameter("@Username", username));
                        SqlDataReader readr = cmd.ExecuteReader();
                        string oldlog = "";
                        while (readr.Read())

                            oldlog = readr[0].ToString();
                        {
                            if (password == oldlog)
                            {
                                string query2 = "UPDATE staffs SET Password=@Newpassword WHERE Username=@Username";
                                SqlCommand cmd2 = new SqlCommand(query2, con);
                                cmd2.Parameters.Add(new SqlParameter("@Username", username));
                                cmd2.Parameters.Add(new SqlParameter("@Newpassword", newpassword));
                                newpassword = newpass.Value;
                                readr.Close();
                                cmd2.ExecuteNonQuery();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "success()", true);

                            }

                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "errorchange()", true);
                            }

                            readr.Close();
                            cmd.ExecuteNonQuery();

                            con.Close();
                        }
                    }
                }
            }
        }
        private void SessionString()
        {

            try
            {
                rolelog = Session["Rolelog"].ToString();
                username = Session["Username"].ToString();
                usernamelabel.Text = username;
            }
            catch (Exception ex)
            {

            }


        }
    }
}
   