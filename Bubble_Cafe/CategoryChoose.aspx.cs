using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe
{
    public partial class CategoryChoose : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["ccid"]);
            rp_citations.DataSource = dm.CitationListing(id);
            rp_citations.DataBind();
        }

    }
}