using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace umisportal
{
    public partial class modifystudents : System.Web.UI.Page
    {
        string username = "";
        string rolelog = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SessionString()
        {
            username = Session["Username"].ToString();
            usernamelabel.Text = username;

        }
    }
}