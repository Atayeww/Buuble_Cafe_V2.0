using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class CategoryEdit : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["cid"]);
                    Category category = dm.CategoryGet(id);
                    if (category != null && category.Name != null)
                    {
                        tb_editCategory.Text = category.Name;
                    }
                    else
                    {
                        Response.Redirect("CategoryListing.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("CategoryListing.aspx");
            }
        }

        protected void lbtn_editCategoryName_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.ID = Convert.ToInt32(Request.QueryString["cid"]);
            category.Name = tb_editCategory.Text;
            if (dm.CategoryEdit(category))
            {
                pnl_success.Visible = true;
                pnl_fail.Visible = false;
            }
            else
            {
                pnl_success.Visible = false;
                pnl_fail.Visible = true;
            }
        }
    }
}