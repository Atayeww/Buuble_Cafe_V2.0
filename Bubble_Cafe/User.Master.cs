using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe
{
    public partial class User : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                pnl_notlogin.Visible = false;
                pnl_login.Visible = true;
                Users users = (Users)Session["user"];
                lbl_username.Text = users.Nickname;
            }
            else
            {
                pnl_login.Visible = false;
                pnl_notlogin.Visible = true;
            }
        }

        protected void lbtn_userexit_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Default.aspx");
            pnl_login.Visible = false;
            pnl_notlogin.Visible = true;
        }
    }
}