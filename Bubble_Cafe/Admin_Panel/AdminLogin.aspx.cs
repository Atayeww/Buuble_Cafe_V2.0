using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.lbtn_adminlogin.UniqueID;
        }

        protected void lbtn_adminlogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tb_adminlogin.Text) && !string.IsNullOrEmpty(tb_adminpassword.Text))
            {
                Manager manager = dm.ManagerLogin(tb_adminlogin.Text, tb_adminpassword.Text);
                if (manager != null)
                {
                    if(manager.State)
                    {
                        Session["managers"] = manager;
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