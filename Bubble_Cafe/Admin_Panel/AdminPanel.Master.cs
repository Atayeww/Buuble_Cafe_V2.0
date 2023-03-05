using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class AdminPanel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["managers"] != null)
            {
                Manager manager = (Manager)Session["managers"];
                lbl_managers.Text = manager.Name + " " + manager.Surname;
            }
            else
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void lbtn_exit_Click(object sender, EventArgs e)
        {
            Session["managers"] = null;
            Response.Redirect("AdminLogin.aspx");
        }
    }
}