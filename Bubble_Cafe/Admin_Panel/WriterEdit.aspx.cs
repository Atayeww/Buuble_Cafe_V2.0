using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class WriterEdit : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["wrid"]);
                    Writers writers = dm.WriterGet(id);
                    if (writers != null && writers.Name != null && writers.Surname != null)
                    {
                        tb_editWriterName.Text = writers.Name;
                        tb_editWriterSurname.Text = writers.Surname;
                    }
                    else
                    {
                        Response.Redirect("WriterListing.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("WriterListing.aspx");
            }
        }

        protected void lbtn_editWriter_Click(object sender, EventArgs e)
        {
            Writers writers = new Writers();
            writers.ID = Convert.ToInt32(Request.QueryString["wrid"]);
            writers.Name = tb_editWriterName.Text;
            writers.Surname = tb_editWriterSurname.Text;
            if (dm.WriterEdit(writers))
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