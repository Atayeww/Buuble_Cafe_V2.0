using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class BookListing : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_booklisting.DataSource = dm.BooksListing();
            lv_booklisting.DataBind();
        }

        protected void lv_booklisting_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "remove")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.BookDelete(id);
            }
            lv_booklisting.DataSource = dm.BooksListing();
            lv_booklisting.DataBind();
        }
    }
}