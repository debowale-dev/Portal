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
    public partial class _Default : Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        private string username = "";
        private string joinname = "";
        private string firstname = "";
        private string lastname = "";
        private string text = "";
        string tb1 = "";
        string tb2 = "";
        string a = "Empty";
        //private string email = "";
        //private string phone = "";
        //private string financialstatus = "";
        //private string course = "";
        //private string department = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.BindGrid();
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button3.Visible = false;
                Button2.Visible = true;
            }
            SessionString();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "select Firstname,Lastname,Email,Phone,Course,Department,Financialstatus,Gender FROM batch18 where Username=@username";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@Username", username));

                SqlDataReader readr = cmd.ExecuteReader();
                string firstlog = "";
                string lastlog = "";
                string emaillog = "";
                string phonelog = "";
                string courselog = "";
                string departmentlog = "";
                string financelog = "";
                string genderlog = "";

                while (readr.Read())
                {
                    firstlog = readr[0].ToString();
                    lastlog = readr[1].ToString();
                    emaillog = readr[2].ToString();
                    phonelog = readr[3].ToString();
                    courselog = readr[4].ToString();
                    departmentlog = readr[5].ToString();
                    financelog = readr[6].ToString();
                    genderlog = readr[7].ToString();

                    joinname = firstlog + " " + lastlog;


                    firstname = firstlog.Substring(0, 1);
                    lastname = lastlog.Substring(0, 1);

                    string joinindex = "";
                    joinindex = firstname + lastname;

                    joinlabel.Text = joinindex;
                    namelabel.Text = joinname;
                    firstnamelabel.Text = firstlog;
                    lastnamelabel.Text = lastlog;
                    emaillabel.Text = emaillog;
                    departmentlabel.Text = departmentlog;
                    phonelabel.Text = phonelog;
                    courselabel.Text = courselog;
                    financelabel.Text = financelog;
                    genderlabel.Text = genderlog;

                }
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();

                string query = "SELECT title,Text FROM Post Where Id=3";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@Username", username));


                SqlDataReader readr = cmd.ExecuteReader();

                string titlelog = "";
                string topiclog = "";


                while (readr.Read())
                {
                    titlelog = readr[0].ToString();
                    topiclog = readr[1].ToString();

                    if (titlelog == a)
                    {
                        theading.Visible = false;
                    }
                    else
                    {
                        timelinetitle.Text = titlelog;
                        timelinebody.Text = topiclog;
                    }

                }
                con.Close();
            }
        }
        protected void rebind()
        {

            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "select Firstname,Lastname,Email,Phone,Course,Department,Financialstatus,Gender FROM batch18 where Username=@username";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@Username", username));

                SqlDataReader readr = cmd.ExecuteReader();
                string firstlog = "";
                string lastlog = "";
                string emaillog = "";
                string phonelog = "";
                string courselog = "";
                string departmentlog = "";
                string financelog = "";
                string genderlog = "";

                while (readr.Read())
                {
                    firstlog = readr[0].ToString();
                    lastlog = readr[1].ToString();
                    emaillog = readr[2].ToString();
                    phonelog = readr[3].ToString();
                    courselog = readr[4].ToString();
                    departmentlog = readr[5].ToString();
                    financelog = readr[6].ToString();
                    genderlog = readr[7].ToString();

                    joinname = firstlog + " " + lastlog;


                    firstname = firstlog.Substring(0, 1);
                    lastname = lastlog.Substring(0, 1);

                    string joinindex = "";
                    joinindex = firstname + lastname;

                    joinlabel.Text = joinindex;
                    namelabel.Text = joinname;
                    firstnamelabel.Text = firstlog;
                    lastnamelabel.Text = lastlog;
                    emaillabel.Text = emaillog;
                    departmentlabel.Text = departmentlog;
                    phonelabel.Text = phonelog;
                    courselabel.Text = courselog;
                    financelabel.Text = financelog;
                    genderlabel.Text = genderlog;

                }
                con.Close();
            }
        } 
        private void SessionString()
        {
            try
            {

                username = Session["Username"].ToString();
                usernamelabel.Text = username;
            }
            catch (Exception ex)
            {

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SessionString();
            text = textinput.Value;
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "Insert into todotable VALUES (@username,@text)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@text", text));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                con.Close();
               
            }
            RefreshGrid();
        }
        private void BindGrid()
        {
            SessionString();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ROW_NUMBER() OVER(ORDER BY Id) AS SN, ID, Username,Text from todotable WHERE Username = @username"))

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                GridViewRow row = GridView1.Rows[index];
                var id = row.Cells[0].Text;
                using (SqlConnection con = new SqlConnection(conObj))
                {
                    con.Open();
                    string query = "DELETE FROM todotable WHERE Id= @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                RefreshGrid();
            }
            catch (Exception ex)
            {

            }
        }

        private void RefreshGrid()
        {
            BindGrid();

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Button2.Visible = false;
            Button3.Visible = true;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            tb1 = TextBox1.Text;
            tb2 = TextBox2.Text;

            using (SqlConnection con = new SqlConnection(conObj)){

                con.Open();
                string query = " update batch18 set Phone = @tb1,Email= @tb2 where Username = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@tb1", tb1));
                cmd.Parameters.Add(new SqlParameter("@tb2", tb2));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }

                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button3.Visible = false;
                Button2.Visible = true;
                rebind();
                con.Close();

            }
        }
    }
}
