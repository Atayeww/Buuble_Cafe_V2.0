using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class CitationListing : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                rp_citationsAdmin.DataSource = dm.CitationListing(false);
                rp_citationsAdmin.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["citid"]);
                rp_citationsAdmin.DataSource = dm.CitationListing(id, false);
                rp_citationsAdmin.DataBind();
            }
        }
    }
}