using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class CategoryListing : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_categories.DataSource = dm.CategoryListing();
            lv_categories.DataBind();
        }

        protected void lv_categories_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "remove")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.CategoryDelete(id);
            }
            lv_categories.DataSource = dm.CategoryListing();
            lv_categories.DataBind();
        }
    }
}