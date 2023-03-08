using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe
{
    public partial class UserEdit : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Users users = (Users)Session["user"];
                tb_username.Text = users.Name;
                tb_usersurname.Text = users.Surname;
                tb_usernickname.Text = users.Nickname;
                tb_adminlogin.Text = users.Mail;
                tb_adminpassword.Text = users.Password;
            }
        }

        protected void lbtn_usersignupp_Click(object sender, EventArgs e)
        {
            Users users = (Users)Session["user"];
            users.Name = tb_username.Text;
            users.Surname = tb_usersurname.Text;
            users.Nickname = tb_usernickname.Text;
            users.Mail = tb_adminlogin.Text;
            users.Password = tb_adminpassword.Text;
            users.State = false;
            if (dm.UsersEdit(users))
            {
                lbl_adminloginerror.Text = "Düzenleme Başarılı";
                users = dm.UserLogin(tb_adminlogin.Text, tb_adminpassword.Text);
                if (users != null)
                {
                    if (!users.State)
                    {
                        Session["user"] = users;
                        Response.Redirect("UserEdit.aspx");
                    }
                    else
                    {
                        pnl_loginerror.Visible = true;
                        lbl_adminloginerror.Text = "Giriş Yaparken Bir Hata Oluştu";
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