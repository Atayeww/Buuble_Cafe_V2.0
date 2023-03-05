using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe
{
    public partial class Signup : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.lbtn_usersignup.UniqueID;
        }

        protected void lbtn_usersignup_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Name = tb_username.Text;
            users.Surname = tb_usersurname.Text;
            users.Nickname = tb_usernickname.Text;
            users.Mail = tb_adminlogin.Text;
            users.Password= tb_adminpassword.Text;
            users.State = false;
            if (dm.UsersAdd(users))
            {
                lbl_adminloginerror.Text = "Başarılı";
                users = dm.UserLogin(tb_adminlogin.Text, tb_adminpassword.Text);
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
            }
            else
            {
                lbl_adminloginerror.Text = "Başarısız";
            }
        }
    }
}