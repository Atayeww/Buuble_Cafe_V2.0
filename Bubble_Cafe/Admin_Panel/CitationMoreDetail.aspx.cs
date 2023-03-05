using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class CitationMoreDetail : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["citid"]);
                Citations citations = dm.CitationGet(id);
                ltrl_citation.Text = citations.Citation;
                ltrl_citbookname.Text = citations.BookName;
                ltrl_citbookpage.Text = citations.BookPage;
                ltrl_citpage.Text = citations.Page;
                ltrl_citusername.Text = citations.User;
                ltrl_citwrietr.Text = citations.BookWriters;
                if (citations.Opinion != " ")
                {
                    ltrl_citopinion.Text = citations.Opinion;
                    pnl_citopinion.Visible = true;
                }
                else
                {
                    pnl_citopinion.Visible = false;

                }
                img_picture.ImageUrl = "~/ImageSource/" + citations.BookImage;
            }
        }
    }
}