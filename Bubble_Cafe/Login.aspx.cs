using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe
{
    public partial class Login : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.lbtn_userlogin.UniqueID;
        }

        protected void lbtn_userlogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_adminlogin.Text) && !string.IsNullOrEmpty(tb_adminpassword.Text))
            {
                Users users = dm.UserLogin(tb_adminlogin.Text, tb_adminpassword.Text);
                if (users != null)
                {
                    if (!users.State)
                    {
                        Session["user"] = users;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        pnl_loginerror.Visible = true;
                        lbl_adminloginerror.Text = "Kullanıcı Hesabınız Aktif Değil";
                    }
                }
                else
                {
                    pnl_loginerror.Visible = true;
                    lbl_adminloginerror.Text = "Kullanıcı Bulunamadı";
                }
            }
            else
            {
                pnl_loginerror.Visible = true;
                lbl_adminloginerror.Text = "E-posta veya Şifre alanı boş bırakılamaz";
            }
        }
    }
}