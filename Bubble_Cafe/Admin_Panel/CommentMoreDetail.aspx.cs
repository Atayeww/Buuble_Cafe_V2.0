using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class CommentMoreDetail : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["comid"]);
            Comment comment = dm.CommnetGet(id);
            ltrl_citusernamecom.Text = comment.UserNickname;
            ltrl_comment.Text = comment.Commnet;
        }

        protected void lbtn_acceptcitation_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["comid"]);
            dm.CommentState(id);
            Response.Redirect("Default.aspx");
        }

        protected void lbtn_deletecitation_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["comid"]);
            dm.CommentHardDelete(id);
            Response.Redirect("Default.aspx");
        }
    }
}