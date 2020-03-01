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
    public partial class deletetimeline : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        string a = "Empty";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "Update Post Set title = @a, Text=@a WHERE Id=3";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("a", a));
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("staffboard.aspx");
            }
        }
        }
    }