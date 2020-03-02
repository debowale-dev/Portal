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
    public partial class staffboard : System.Web.UI.Page
    {
        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        private string username = "";
        private string joinname = "";
        private string firstname = "";
        private string lastname = "";
        private string text = "";
        private string md = "Moderator";
        private string lr = "Lecturer";
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
            }
            //SessionString();
            stafflabel.Visible = false;
            modlabel.Visible = false;

            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "select Firstname,Lastname,Email,Phone,Department,Role FROM staffs where Username=@username";
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
                string rolelog = "";

                while (readr.Read())
                {
                    firstlog = readr[0].ToString();
                    lastlog = readr[1].ToString();
                    emaillog = readr[2].ToString();
                    phonelog = readr[3].ToString();
                    departmentlog = readr[4].ToString();
                    rolelog = readr[5].ToString();

                    joinname = firstlog + " " + lastlog;


                    if (rolelog == md)
                    {
                        modlabel.Visible = true;
                        stafflabel.Visible = false;
                        hide5.Visible = false;

                    }
                    else if (rolelog == lr)
                    {
                        modlabel.Visible = false;
                        stafflabel.Visible = true;
                        hide1.Visible = false;
                        hide2.Visible = false;
                        hide4.Visible = false;
                        hide6.Visible = false;
                    }
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


                }
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();

                string query = "SELECT title,Text FROM Post Where Id=1";

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
    }
}
