using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class WriterListing : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_writer.DataSource= dm.WriterListing();
            lv_writer.DataBind();
        }

        protected void lv_writer_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "remove")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.WriterDelete(id);
            }
            lv_writer.DataSource= dm.WriterListing();
            lv_writer.DataBind();
        }
    }
}