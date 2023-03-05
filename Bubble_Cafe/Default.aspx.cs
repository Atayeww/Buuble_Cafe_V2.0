using Bubble_Cafe.Admin_Panel;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count == 0) {
                rp_citations.DataSource = dm.CitationListing(false);
                rp_citations.DataBind();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["citid"]);
                rp_citations.DataSource = dm.CitationListing(id,false);
                rp_citations.DataBind();
            }
        }
    }
}