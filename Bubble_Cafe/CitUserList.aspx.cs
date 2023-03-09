using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe
{
    public partial class CitUserList : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["citid"]);
                rp_commentlist.DataSource = dm.CommnetCitList(id);
                rp_commentlist.DataBind();
                Citations citations = dm.CitationGet(id);
                ltrl_citation.Text = citations.Citation;
                ltrl_citbookname.Text = citations.BookName;
                ltrl_citbookpage.Text = citations.BookPage;
                ltrl_citpage.Text = citations.Page;
                ltrl_citusername.Text = citations.User;
                ltrl_citwrietr.Text = citations.BookWriters;
                ltrl_likedshow.Text = citations.Liked.ToString();
                if (citations.Opinion != " ")
                {
                    ltrl_citopinion.Text = citations.Opinion;
                    pnl_citopinion.Visible = true;
                }
                else
                {
                    pnl_citopinion.Visible = false;

                }
                img_picture.ImageUrl = "ImageSource/" + citations.BookImage;
                if (Session["user"] != null)
                {
                    if (!IsPostBack)
                    {
                        dm.CitationViewUpdate(id);
                        ltrl_citview.Text = citations.CitationView.ToString();
                    }
                }
                else
                {
                    ltrl_citview.Text = citations.CitationView.ToString();
                }
                if (Session["user"] != null)
                {
                    pnl_login.Visible = true;
                    pnl_notlogin.Visible = false;
                }
            }
        }

        protected void lbtn_disliked_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["citid"]);
            if (Session["user"] != null)
            {
                dm.CitationDislikedUpdate(id);
            }
        }

        protected void lbtn_liked_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["citid"]);
            Citations citations = dm.CitationLikedUpdateGet(id);
            if (Session["user"] != null)
            {
                dm.CitationLikedUpdate(id);
                ltrl_likedshow.Text = citations.Liked.ToString();
            }
            else
            {
                ltrl_likedshow.Text = citations.Liked.ToString();
            }
        }

        protected void lbtn_commentsend_Click(object sender, EventArgs e)
        {
            Comment comment = new Comment();
            int cid = Convert.ToInt32(Request.QueryString["citid"]);
            comment.Citations_ID= cid;
            Users users = (Users)Session["user"];
            int usid = users.ID;
            comment.Users_ID= usid;
            comment.State = true;
            comment.CommentDateTime= DateTime.Now;
            comment.Commnet = tb_writecomment.Text;
            dm.CommentAdd(comment);
        }
    }
}