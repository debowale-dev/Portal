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
    public partial class fees : System.Web.UI.Page
    {

        private string conObj = ConfigurationManager.ConnectionStrings["PORTALDB"].ConnectionString;
        string username = "";
        string joinname = "";
        string firstname = "";
        string lastname = "";
        string courselog = "";
        string levellog = "";
        string registeredlog = "";
        string sub1 = "";
        string sub11 = "";
        string sub22 = "";
        string sub2 = "";
        string gend = "";
        string totfees = "";
        string subtotal = "";
        string sub3 = "";
        decimal a;
        decimal b;
        string yes = "YES";
        string no = "NO";
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionString();
            if (registeredlog == yes)
            {
                Details();
                subdetails();
                show1.Visible = false;
                show2.Visible = false;
                show3.Visible = false;
                show4.Visible = true;
            }
            else if (registeredlog == no)
            {
                tuition();
                Details();

                show1.Visible = true;
                show2.Visible = false;
                show3.Visible = false;
                show4.Visible = false;
            }
        }
        protected void SessionString()
        {
            username = Session["Username"].ToString();
            courselog = Session["Courselog"].ToString();
            registeredlog = Session["Registeredlog"].ToString();
            usernamelabel.Text = username;
            //courselabel.Text = courselog;
        }
        protected void Details()
        {
            SessionString();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "select Firstname,Lastname,Course,Department,Financialstatus,Gender,Level FROM batch18 where Username=@username";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@Username", username));
                SqlDataReader readr = cmd.ExecuteReader();
                string firstlog = "";
                string lastlog = "";
                string departmentlog = "";
                string financelog = "";
                string genderlog = "";
                string levellog = "";

                while (readr.Read())
                {
                    firstlog = readr[0].ToString();
                    lastlog = readr[1].ToString();
                    courselog = readr[2].ToString();
                    departmentlog = readr[3].ToString();
                    financelog = readr[4].ToString();
                    genderlog = readr[5].ToString();
                    levellog = readr[6].ToString();
                    joinname = firstlog + " " + lastlog;


                    firstname = firstlog.Substring(0, 1);
                    lastname = lastlog.Substring(0, 1);

                    string joinindex = "";
                    
                    joinindex = firstname + lastname;
                    gend = genderlog;

                    joinlabel.Text = joinindex;
                    namelabel.Text = joinname;
                    courselabel.Text = courselog;
                    financialstatuslabel.Text = financelog;
                    levellabel.Text = levellog;


                }
                con.Close();
            }
        }
       public void tuition()
        {
            SessionString();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "select Course,CONVERT(varchar, convert (Money,Fees),1) AS Fees FROM courses where Course=@courselog";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@Courselog", courselog));

               SqlDataReader readr = cmd.ExecuteReader();
                string firstlog = "";
                string lastlog = "";

               

                while (readr.Read())
                {
                    firstlog = readr[0].ToString();
                    lastlog = readr[1].ToString();
                 
                    Tuitionfee.Text = lastlog;
                    sub1 = lastlog;
                    a =Convert.ToDecimal(sub1);
                    

                 
                }
                con.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            show1.Visible = false;
            show2.Visible = true;
        }
          protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
            {
            sub2 = CheckBoxList1.SelectedIndex.ToString();
            sub3 = CheckBoxList1.SelectedValue;

            Session["sub2"] = sub2;
            Session["sub3"] = sub3;
            
           }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sub22 = DropDownList1.SelectedItem.Text;
            Session["sub22"] = sub22;

        }
        protected void subsections()
        {
            sub2 = Session["sub2"].ToString();
            sub3 = Session["sub3"].ToString();
        }
        protected void subhall()
        {
            sub22 = Session["sub22"].ToString();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            subsections();

            string f = "1";
            show1.Visible = false;
            show2.Visible = false;

            if (sub2 == f)
            {
                show1.Visible = false;
                show2.Visible = false;
                show3.Visible = true;

                using (SqlConnection con = new SqlConnection(conObj))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select Id,Residence from Hall where Gender =@gender"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Parameters.Add(new SqlParameter("gender", gend));
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;

                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                DropDownList1.DataSource = dt;
                                DropDownList1.DataTextField = "Residence";
                                DropDownList1.DataValueField = "Id";
                                DropDownList1.DataBind();
                                DropDownList1.Items.Insert(0, new ListItem("Select Residence", "0"));

                            }
                            con.Close();
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conObj))
                {
                    con.Open();
                    string query = "update batch18 SET totalfees = @a, Registeredstatus=@yes WHERE Username = @username";  
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@Username", username));
                    cmd.Parameters.Add(new SqlParameter("@a",a));
                    cmd.Parameters.Add(new SqlParameter("@yes", yes));
                   SqlDataReader readr = cmd.ExecuteReader();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                    subtotallabel.Text = sub1;
                    con.Close();
                }
                show1.Visible = false;
                show2.Visible = false;
                show3.Visible = false;
                show4.Visible = true;
            }

        }
        protected void Button3_Click(object sender,EventArgs e)
        {
            subsections();
            subhall();
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "Select CONVERT(varchar, convert (Money,Fees),1) AS Fees from Hall WHERE Residence = @sub22";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@sub22", sub22));

                SqlDataReader readr = cmd.ExecuteReader();

                string firstlog = "";
                while (readr.Read())
                {
                    firstlog = readr[0].ToString();
                    totfees = firstlog;
                    b = Convert.ToDecimal(totfees);
                }
                con.Close();
            }
            System.Decimal subtotal = System.Decimal.Add(a, b);
            
        
            using (SqlConnection con = new SqlConnection(conObj))
            {
                con.Open();
                string query = "update batch18 SET totalfees = @subtotal ,Registeredstatus=@yes WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@Username", username));
                cmd.Parameters.Add(new SqlParameter("@subtotal", subtotal));
                cmd.Parameters.Add(new SqlParameter("@yes", yes));
                SqlDataReader readr = cmd.ExecuteReader();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                subtotallabel.Text = subtotal.ToString();
                con.Close();
            }
            show1.Visible = false;
            show2.Visible = false;
            show3.Visible = false;
            show4.Visible = true;
        }
        protected void subdetails()
        {
              
                using (SqlConnection con = new SqlConnection(conObj))
                {
                    con.Open();
                    string query = "Select CONVERT(varchar, convert (Money,Totalfees),1) AS Totalfees,CONVERT(varchar, convert (Money,Amountpaid),1) AS Amountpaid,CONVERT(varchar, convert (Money,Amountleft),1) AS Amountleft from batch18 WHERE Username = @username";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@Username", username));

                    SqlDataReader readr = cmd.ExecuteReader();

                    string firstlog = "";
                    string seclog = "";
                    string thirdlog = "";
                    while (readr.Read())
                    {
                        firstlog = readr[0].ToString();
                        seclog = readr[1].ToString();
                        thirdlog = readr[2].ToString();

                         totfees = firstlog;
                         b = Convert.ToDecimal(totfees);

                    subtotallabel.Text = firstlog.ToString();
                    amountpaidlabel.Text = seclog.ToString();
                    amountleftlabel.Text = thirdlog.ToString();

                    }
                    con.Close();
                }
                System.Decimal subtotal = System.Decimal.Add(a, b);


            }
        }
}