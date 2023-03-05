using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class WriterAdd : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_addWriter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_addWriterName.Text.Trim()) && !string.IsNullOrEmpty(tb_addWriterSurname.Text.Trim()))
            {
                if (dm.HelpingControlName(tb_addWriterName.Text.Trim()) && dm.HelpingControlSurname(tb_addWriterSurname.Text.Trim()))
                {
                    Writers writers = new Writers();
                    writers.Name = tb_addWriterName.Text;
                    writers.Surname = tb_addWriterSurname.Text;
                    writers.State = false;
                    if (dm.WriterAdd(writers))
                    {
                        pnl_success.Visible = true;
                        pnl_fail.Visible = false;
                        tb_addWriterName.Text = "";
                    }
                    else
                    {
                        pnl_success.Visible = false;
                        pnl_fail.Visible = true;
                        lbl_message.Text = "Yeni Yazar Eklenirken Bir Hata Oluştu";
                    }
                }
                else
                {
                    pnl_success.Visible = false;
                    pnl_fail.Visible = true;
                    lbl_message.Text = "Yazar Daha Önce Eklenmiştir";
                }
            }
            else
            {
                pnl_success.Visible = false;
                pnl_fail.Visible = true;
                lbl_message.Text = "Yazar Adı Veya Soyadı Boş Bırakılmaz";
            }
        }
    }
}