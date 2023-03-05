using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class UsersListing : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_users.DataSource = dm.UsersListing();
            lv_users.DataBind();
        }

        protected void lv_users_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.UsersHardDelete(id);
            }
            lv_users.DataSource = dm.UsersListing();
            lv_users.DataBind();
        }

    }
}