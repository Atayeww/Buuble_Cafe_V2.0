using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class CategoryAdd : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_addCategoryName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_addCategory.Text.Trim()))
            {
                if (dm.HelpingControl("Categories", "Name", tb_addCategory.Text.Trim()))
                {
                    Category category = new Category();
                    category.Name = tb_addCategory.Text;
                    category.State = false;
                    if (dm.CategoryAdd(category))
                    {
                        pnl_success.Visible = true;
                        pnl_fail.Visible = false;
                        tb_addCategory.Text = "";
                    }
                    else
                    {
                        pnl_success.Visible = false;
                        pnl_fail.Visible = true;
                        lbl_message.Text = "Kategori Eklenirken Bir Hata Oluştu";
                    }
                }
                else
                {
                    pnl_success.Visible = false;
                    pnl_fail.Visible = true;
                    lbl_message.Text = "Kategori Daha Önce Eklenmiştir";
                }
            }
            else
            {
                pnl_success.Visible = false;
                pnl_fail.Visible = true;
                lbl_message.Text = "Kategori Adı Boş Bırakılmaz";
            }
        }
    }
}