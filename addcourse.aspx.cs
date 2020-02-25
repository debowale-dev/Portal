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
    public partial class addcourse : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        string username = "";
        string lect = "";
        string lect1 = "";
        string tb1 = "";
        string tb2 = "";
        string tb3 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //SessionString();
            if (!this.IsPostBack)
            {
                this.BindGrid();
                this.BindDrop();
            }

        }
        protected void SessionString()
        {
            username = Session["Username"].ToString();
            usernamelabel.Text = username;
        }
        private void BindGrid()
        {
            //SessionString();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CourseId,Course,Lecturer,Level from courses"))

                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.Add(new SqlParameter("Username", username));
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }

                }
            }

        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = GridView1.Rows[index];
        //    var id = row.Cells[0].Text;
        //    GridView gv = (GridView)sender;

        //    DropDownList Dl1 = (DropDownList)(row.FindControl("DropDownList1"));

        //    if (Dl1 == null)
        //    {
        //        throw new ApplicationException("Could not find DropDown");

        //    }
        //    else
        //    {
        //        var DropDownList1 = Dl1;
        //        using (SqlConnection con = new SqlConnection(conObj))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("select * from staffs where Role = 'Lecturer'"))

        //            {
        //                using (SqlDataAdapter sda = new SqlDataAdapter())
        //                {
        //                    cmd.Connection = con;
        //                    sda.SelectCommand = cmd;
        //                    using (DataTable dt = new DataTable())
        //                    {
        //                        sda.Fill(dt);
        //                        DropDownList1.DataSource = dt;
        //                        DropDownList1.DataTextField = "Lecturer";
        //                        DropDownList1.DataValueField = "Lecturer";
        //                        DropDownList1.DataBind();
        //                        DropDownList1.Items.Insert(0, new ListItem("--Select Lecturer--", "0"));


        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            var id = row.Cells[0].Text;

            var matno = row.Cells[1].Text;

            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "UPDATE courses SET Lecturer= @lect WHERE CourseId= @id ";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@lect", lect));
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteNonQuery();
                RefreshGrid();

                con.Close();
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dd = e.Row.Cells[0].FindControl("ddlitem") as DropDownList;

                using (SqlConnection con = new SqlConnection(conObj))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select Id,Username from staffs where Role = 'Lecturer'"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;

                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dd.DataSource = dt;
                                dd.DataTextField = "Username";
                                dd.DataValueField = "Id";
                                dd.DataBind();
                                dd.Items.Insert(0, new ListItem("Select Lecturer", "0"));

                            }
                            con.Close();
                        }
                    }
                }
            }
        }
        protected void BindDrop()
        {
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select Id,Username from staffs where Role = 'Lecturer'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            DropDownList1.DataSource = dt;
                            DropDownList1.DataTextField = "Username";
                            DropDownList1.DataValueField = "Id";
                            DropDownList1.DataBind();
                            DropDownList1.Items.Insert(0, new ListItem("Select Lecturer", "0"));

                        }
                        con.Close();
                    }
                }
            }
        }
        protected void ddlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
            DropDownList dd = (DropDownList)gvr.FindControl("ddlitem");
            lect = dd.SelectedItem.Text;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lect1 = DropDownList1.SelectedItem.Text;
            tb1 = TextBo1.Value ;
            tb2 = TextBo2.Value;

        }
        protected void RefreshGrid()
        {
            BindGrid();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lect1) || string.IsNullOrEmpty(tb1) || string.IsNullOrEmpty(tb2))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "(errord)", true);
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conObj))
                {

                    con.Open();
                    string query = "Insert into courses (Course,Lecturer,Level) VALUES (@tb1,@lect1,@tb2)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@tb1", tb1));
                    cmd.Parameters.Add(new SqlParameter("@lect1", lect1));
                    cmd.Parameters.Add(new SqlParameter("@tb2", tb2));
                    cmd.ExecuteNonQuery();
                    RefreshGrid();

                    con.Close();
                }
            }
          
        }
    }
}
