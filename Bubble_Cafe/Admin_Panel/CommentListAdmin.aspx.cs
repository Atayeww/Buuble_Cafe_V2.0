using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class CommentListAdmin : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            rp_commentaccept.DataSource = dm.CommnetList(false);
            rp_commentaccept.DataBind();
        }
    }
}