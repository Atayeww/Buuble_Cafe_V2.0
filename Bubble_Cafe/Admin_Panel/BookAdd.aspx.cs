using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe.Admin_Panel
{
    public partial class BookAdd : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddl_category.DataValueField = "ID";
                ddl_category.DataTextField = "Name";
                ddl_category.DataSource = dm.CategoryListing(); 
                ddl_category.DataBind();
            }
        }

        protected void lbtn_addBook_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_addbook.Text.Trim()) && !string.IsNullOrEmpty(tb_addpage.Text.Trim()) && !string.IsNullOrEmpty(tb_addpublisher.Text.Trim()) && !string.IsNullOrEmpty(tb_addreleaseData.Text.Trim()) && !string.IsNullOrEmpty(tb_addwritername.Text.Trim()) && !string.IsNullOrEmpty(tb_addwritersurname.Text.Trim()) && Convert.ToInt32(ddl_category.SelectedItem.Value)!=0)
            {
                if (dm.HelpingControl("Books", "Name", tb_addbook.Text.ToUpper().Trim()))
                {
                    Books books = new Books();
                    Writers writers = new Writers();
                    Publisher publisher = new Publisher();
                    if (dm.HelpingControlName(tb_addwritername.Text.Trim()) || dm.HelpingControlSurname(tb_addwritersurname.Text.Trim()))
                    {
                        writers.Name = tb_addwritername.Text;
                        writers.Surname = tb_addwritersurname.Text;
                        writers.State = false;
                        int id = Convert.ToInt32(dm.WriterAddReturnId(writers));
                        if (id>0)
                        {
                            books.Writers_ID = id;
                        }
                        else
                        {
                            pnl_success.Visible = false;
                            pnl_fail.Visible = true;
                            lbl_message.Text = "Yazar Adı Eklenirken Bir Hata Oluştu";
                        }

                    }
                    else
                    {
                        int id1 = dm.HelpingControlReturnId("Writers", "Name", tb_addwritername.Text.Trim());
                        int id2 = dm.HelpingControlReturnId("Writers", "Surname", tb_addwritersurname.Text.Trim());
                        if (id1 == id2)
                        {
                            books.Writers_ID = id1;
                        }
                        else
                        {
                            writers.Name = tb_addwritername.Text;
                            writers.Surname = tb_addwritersurname.Text;
                            writers.State = false;
                            int id = Convert.ToInt32(dm.WriterAddReturnId(writers));
                            if (id > 0)
                            {
                                books.Writers_ID = id;
                            }
                            else
                            {
                                pnl_success.Visible = false;
                                pnl_fail.Visible = true;
                                lbl_message.Text = "Yazar Adı Eklenirken Bir Hata Oluştu";
                            }
                        }
                    }
                    if (dm.HelpingControl("Publishers", "Name", tb_addpublisher.Text.Trim()))
                    {
                        publisher.Name = tb_addpublisher.Text;
                        publisher.State = false;
                        int id = Convert.ToInt32(dm.PublisherAddReturnId(publisher));
                        if (id>0)
                        {
                            books.Publishers_ID = id;
                        }
                        else
                        {
                            pnl_success.Visible = false;
                            pnl_fail.Visible = true;
                            lbl_message.Text = "Yayınevi Eklenirken Bir Hata Oluştu";
                        }
                    }
                    else
                    {
                        int id = dm.HelpingControlReturnId("Publishers", "Name", tb_addpublisher.Text.Trim());
                        books.Publishers_ID = id;
                    }
                    if (fu_addimage.HasFile)
                    {
                        FileInfo fi = new FileInfo(fu_addimage.FileName);
                        if(fi.Extension== ".jpg" || fi.Extension == ".png")
                        {
                            string extension = fi.Extension;
                            string name = Guid.NewGuid().ToString();
                            books.Image = name + extension;
                            fu_addimage.SaveAs(Server.MapPath("~/ImageSource/" + name + extension));
                        }
                        else
                        {
                            books.Image = "none.png";
                        }
                    }
                    books.Categories_ID = Convert.ToInt32(ddl_category.SelectedItem.Value);
                    books.Name = tb_addbook.Text.ToUpper();
                    books.Page = tb_addpage.Text;
                    books.ReleaseDate = tb_addreleaseData.Text;
                    books.State = false;
                    if (dm.BookAdd(books))
                    {
                        tb_addbook.Text = tb_addpage.Text = tb_addreleaseData.Text  =  tb_addpublisher.Text = tb_addwritername.Text = tb_addwritersurname.Text = "";
                        ddl_category.SelectedValue = "0";
                        pnl_success.Visible = true;
                        pnl_fail.Visible = false;
                        lbl_message.Text = "Kitap Ekleme Başarılı";
                    }
                    else
                    {
                        pnl_success.Visible = false;
                        pnl_fail.Visible = true;
                        lbl_message.Text = "Kitap Adı Eklenirken Bir Hata Oluştu";
                    }
                }
                else
                {
                    pnl_success.Visible = false;
                    pnl_fail.Visible = true;
                    lbl_message.Text = "Bu Kitap Daha Önce Eklenmiştir";
                }
                
            }
            else
            {
                pnl_success.Visible = false;
                pnl_fail.Visible = true;
                lbl_message.Text = "Kitap Adı Boş Bırakılmaz";
            }
        }
    }
}