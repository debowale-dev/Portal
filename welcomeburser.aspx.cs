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

    public partial class welcomeburser : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        string username = "";
        string rolelog = "";
        string a = "Approved";
        string b = "Unapproved";
        string c = "All";
        string d = "YES";
        string e = "NO";
        string f = "Select";
        string totfees = "";
        decimal bs;
        string search = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            notfoundlabel.Visible = false;
            searchlabel.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = false;
            GridView4.Visible = false;
            if (!this.IsPostBack)
            {
                this.BindGrid();

                ListItemCollection collection = new ListItemCollection();
                collection.Add(new ListItem("Select"));
                collection.Add(new ListItem("All"));
                collection.Add(new ListItem("Approved"));
                collection.Add(new ListItem("Unapproved"));


                //Pass ListItemCollection as datasource
                DropDownList1.DataSource = collection;
                DropDownList1.DataBind();
            }



        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == a)
            {
                GridView1.Visible = false;
                GridView2.Visible = true;
                GridView3.Visible = false;
                this.BindGrid2();
                RefreshGrid2();
            }

            if (DropDownList1.SelectedValue == c)
            {
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;

                this.BindGrid();
                RefreshGrid();

            }

            if (DropDownList1.SelectedValue == b)
            {
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = true;

                this.BindGrid3();
                RefreshGrid3();

            }
            if (DropDownList1.SelectedValue == f)
            {
                GridView1.Visible = true;
                GridView2.Visible = false;
                GridView3.Visible = false;

                this.BindGrid();
                RefreshGrid();
            }
        }
        private void BindGrid()
        {
            SessionString();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UserId, Username,Firstname,Lastname,Financialstatus,Course,Level,CONVERT(varchar, convert (Money,Amountpaid),1) AS Amountpaid,CONVERT(varchar, convert (Money,Amountleft),1) AS Amountleft,CONVERT(varchar, convert (Money,Totalfees),1) AS Totalfees,Date from batch18"))

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
        private void BindGrid2()
        {
            SessionString();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UserId, Username,Firstname,Lastname,Financialstatus,Course,Level,CONVERT(varchar, convert (Money,Amountpaid),1) AS Amountpaid,CONVERT(varchar, convert (Money,Amountleft),1) AS Amountleft,Totalfees,Date from batch18 WHERE Financialstatus = @d"))

                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.Add(new SqlParameter("Username", username));
                        cmd.Parameters.Add(new SqlParameter("d", d));
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                        }
                    }

                }
            }
        }
        private void BindGrid3()
        {
            SessionString();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UserId, Username,Firstname,Lastname,Financialstatus,Course,Level,CONVERT(varchar, convert (Money,Amountpaid),1) AS Amountpaid,CONVERT(varchar, convert (Money,Amountleft),1) AS Amountleft,Totalfees,Date from batch18 WHERE Financialstatus = @e"))

                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.Add(new SqlParameter("Username", username));
                        cmd.Parameters.Add(new SqlParameter("e", e));
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView3.DataSource = dt;
                            GridView3.DataBind();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string a = "paid";
            string b = "notpaid";
            string c = "pending";
            string d = "textbox";

            if (e.CommandName == a)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'YES' WHERE UserId= @id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.CommandName == b)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'NO' WHERE UserId=@id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.CommandName == c)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView1.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'PENDING' WHERE UserId= @id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.CommandName == d)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                var id = row.Cells[0].Text;
                var matno = row.Cells[1].Text;

                GridView gv = (GridView)sender;
                TextBox tb = (TextBox)(row.FindControl("TextBox1"));
                if (tb == null)
                {
                    throw new ApplicationException("Could not find TextBox");

                }
                string TextBox1 = tb.Text;
                using (SqlConnection con = new SqlConnection(conObj))
                {
                    try
                    {
                        con.Open();
                        string query = "Select CONVERT(varchar, convert (Money,Totalfees),1) AS Totalfees from batch18 WHERE UserId=@id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@TextBox1", TextBox1));
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        SqlDataReader readr = cmd.ExecuteReader();

                        string firstlog = "";
                        while (readr.Read())
                        {
                            firstlog = readr[0].ToString();
                            totfees = firstlog;
                            bs = Convert.ToDecimal(totfees);
                        }


                    }
                    catch (Exception ex)
                    {

                    }

                }
                using (SqlConnection con = new SqlConnection(conObj))
                {
                    try
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Amountpaid = @TextBox1 WHERE UserId=@id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@TextBox1", TextBox1));
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        try
                        {
                            cmd.ExecuteNonQuery();
                            RefreshGrid();

                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    catch (Exception ex)
                    {

                    }

                }
                using (SqlConnection con = new SqlConnection(conObj))
                {
                    try
                    {
                        System.Decimal subtotal = System.Decimal.Subtract(bs, Convert.ToDecimal(TextBox1));
                        con.Open();
                        string query = "UPDATE batch18 SET Amountleft = @subtotal WHERE UserId=@id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@subtotal", subtotal));
                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid();

                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string a = "paid";
            string b = "notpaid";
            string c = "pending";


            if (e.CommandName == a)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView2.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'YES' WHERE UserId= @id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid2();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.CommandName == b)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView2.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'NO' WHERE UserId=@id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid2();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.CommandName == c)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView2.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'PENDING' WHERE UserId= @id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid2();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            string a = "paid";
            string b = "notpaid";
            string c = "pending";
            string d = "textbox";


            if (e.CommandName == a)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView3.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'YES' WHERE UserId= @id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid3();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.CommandName == b)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView3.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'NO' WHERE UserId=@id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid3();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else if (e.CommandName == c)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView3.Rows[index];
                    var id = row.Cells[0].Text;

                    var matno = row.Cells[1].Text;

                    using (SqlConnection con = new SqlConnection(conObj))
                    {
                        con.Open();
                        string query = "UPDATE batch18 SET Financialstatus = 'PENDING' WHERE UserId= @id AND Username=@matno";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@id", id));
                        cmd.Parameters.Add(new SqlParameter("@matno", matno));
                        cmd.ExecuteNonQuery();
                        RefreshGrid3();

                        con.Close();
                    }
                }
                catch (Exception ex)
                {

                }

            }


        }
        private void RefreshGrid()
        {
            BindGrid();
        }
        private void RefreshGrid2()
        {
            BindGrid2();
            GridView1.Visible = false;
            GridView2.Visible = true;
            GridView3.Visible = false;
        }
        private void RefreshGrid3()
        {
            BindGrid3();
            GridView1.Visible = false;
            GridView2.Visible = false;
            GridView3.Visible = true;
        }
        private void SessionString()
        {
            try
            {

                username = Session["Username"].ToString();
                rolelog = Session["Rolelog"].ToString();
                usernamelabel.Text = username;
                //outputlabel.Text = username;
            }
            catch (Exception ex)
            {

            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            search = searchid.Value;
            if (string.IsNullOrEmpty(search))
            {
                searchlabel.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
                GridView2.Visible = false;
                GridView3.Visible = false;
                GridView4.Visible = true;

                using (SqlConnection con = new SqlConnection(conObj))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT UserId, Username,Firstname,Lastname,Financialstatus,Course,Level,CONVERT(varchar, convert (Money,Amountpaid),1) AS Amountpaid,CONVERT(varchar, convert (Money,Amountleft),1) AS Amountleft,Totalfees,Date from batch18 WHERE Username = @search"))

                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.Add(new SqlParameter("Search", search));
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            SqlDataReader readr = cmd.ExecuteReader();
                            string firstlog = "";

                          while (readr.Read())
                            {
                                firstlog = readr[1].ToString();
                            }
                            con.Close();
                                if (search == firstlog)
                                {
                                    using (DataTable dt = new DataTable())
                                    {
                                    con.Open();
                                        sda.Fill(dt);
                                        GridView4.DataSource = dt;
                                        GridView4.DataBind();
                                    }
                                }
                                else
                                {
                                    notfoundlabel.Visible = true;
                                    BindGrid();
                                    GridView1.Visible = true;
                               
                                }

                            }
                        }
                    }
                }
            }
        }
    }
