using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bubble_Cafe
{
    public partial class CitUserAdd : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                pnl_notlogin.Visible = false;
                pnl_login.Visible = true;
            }
            else
            {
                pnl_login.Visible = false;
                pnl_notlogin.Visible = true;
            }
            if (!IsPostBack)
            {
                ddl_addCitCategory.DataValueField = "ID";
                ddl_addCitCategory.DataTextField = "Name";
                ddl_addCitCategory.DataSource = dm.CategoryListing();
                ddl_addCitCategory.DataBind();
            }
        }

        protected void lbtn_addCitation_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_addCitCategory.SelectedItem.Value) != 0)
            {
                if (!string.IsNullOrEmpty(tb_addCitBookName.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(tb_addCitWriterName.Text.Trim()) && !string.IsNullOrEmpty(tb_addCitWriterSurname.Text.Trim()))
                    {
                        if (!string.IsNullOrEmpty(tb_addCitPage.Text.Trim()))
                        {
                            if (!string.IsNullOrEmpty(tb_addCitation.Text.Trim()))
                            {
                                if (!string.IsNullOrEmpty(tb_addCitPublisher.Text.Trim()))
                                {
                                    if (!string.IsNullOrEmpty(tb_addCitReleaseDate.Text.Trim()))
                                    {
                                        if (!string.IsNullOrEmpty(tb_addCitPageBook.Text.Trim()))
                                        {
                                            Citations citations = new Citations();
                                            if (dm.HelpingControl("Books", "Name", tb_addCitBookName.Text.ToUpper().Trim()))
                                            {
                                                Books books = new Books();
                                                Writers writers = new Writers();
                                                Publisher publisher = new Publisher();
                                                if (dm.HelpingControlName(tb_addCitWriterName.Text.Trim()) || dm.HelpingControlSurname(tb_addCitWriterSurname.Text.Trim()))
                                                {
                                                    writers.Name = tb_addCitWriterName.Text;
                                                    writers.Surname = tb_addCitWriterSurname.Text;
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
                                                else
                                                {
                                                    int id1 = dm.HelpingControlReturnId("Writers", "Name", tb_addCitWriterName.Text.Trim());
                                                    int id2 = dm.HelpingControlReturnId("Writers", "Surname", tb_addCitWriterSurname.Text.Trim());
                                                    if (id1 == id2)
                                                    {
                                                        books.Writers_ID = id1;
                                                    }
                                                    else
                                                    {
                                                        writers.Name = tb_addCitWriterName.Text;
                                                        writers.Surname = tb_addCitWriterSurname.Text;
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
                                                if (dm.HelpingControl("Publishers", "Name", tb_addCitPublisher.Text.Trim()))
                                                {
                                                    publisher.Name = tb_addCitPublisher.Text;
                                                    publisher.State = false;
                                                    int id = Convert.ToInt32(dm.PublisherAddReturnId(publisher));
                                                    if (id > 0)
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
                                                    int id = dm.HelpingControlReturnId("Publishers", "Name", tb_addCitPublisher.Text.Trim());
                                                    books.Publishers_ID = id;
                                                }
                                                books.Categories_ID = Convert.ToInt32(ddl_addCitCategory.SelectedValue);
                                                books.Name = tb_addCitBookName.Text.ToUpper();
                                                books.Page = tb_addCitPageBook.Text;
                                                books.ReleaseDate = tb_addCitReleaseDate.Text;
                                                books.Image = "none.png";
                                                books.State = false;
                                                int num = Convert.ToInt32(dm.BookAddReturnId(books));
                                                if (num > 0)
                                                {
                                                    citations.Books_ID = num;
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
                                                int id = Convert.ToInt32(dm.HelpingControlReturnId("Books", "Name", tb_addCitBookName.Text.Trim()));
                                                citations.Books_ID = id;
                                            }
                                            int number = 0;
                                            Users user = (Users)Session["user"];
                                            citations.Users_ID= user.ID;
                                            citations.Citation = tb_addCitation.Text;
                                            citations.Page = tb_addCitPage.Text;
                                            citations.AddDateTime = DateTime.Now;
                                            if(tb_addOpinion.Text != null)
                                            {
                                                citations.Opinion = tb_addOpinion.Text;
                                            }
                                            else
                                            {
                                                citations.Opinion = " ";
                                            }
                                            citations.CitationView = number;
                                            citations.Liked = number;
                                            citations.Disliked = number;
                                            citations.State = true;
                                            if (dm.CitationAdd(citations))
                                            {
                                                tb_addCitBookName.Text = tb_addCitPageBook.Text = tb_addCitPublisher.Text = tb_addCitReleaseDate.Text = tb_addCitWriterName.Text = tb_addCitWriterSurname.Text = tb_addCitation.Text = tb_addCitPage.Text = tb_addOpinion.Text = "";
                                                ddl_addCitCategory.SelectedValue = "0";
                                                pnl_success.Visible = true;
                                                pnl_fail.Visible = false;
                                            }
                                        }
                                        else
                                        {
                                            pnl_success.Visible = false;
                                            pnl_fail.Visible = true;
                                            lbl_message.Text = "Kıtap Sayfasını Giriniz";
                                        }
                                    }
                                    else
                                    {
                                        pnl_success.Visible = false;
                                        pnl_fail.Visible = true;
                                        lbl_message.Text = "Kıtabın Basım Tarihini Giriniz";
                                    }
                                }
                                else
                                {
                                    pnl_success.Visible = false;
                                    pnl_fail.Visible = true;
                                    lbl_message.Text = "Yayınevi Alanı Boş Bırakılmaz";
                                }
                            }
                            else
                            {
                                pnl_success.Visible = false;
                                pnl_fail.Visible = true;
                                lbl_message.Text = "Alıntı Alanı Boş Bırakılmaz";
                            }
                        }
                        else
                        {
                            pnl_success.Visible = false;
                            pnl_fail.Visible = true;
                            lbl_message.Text = "Alıntı Yaptığınız Sayfayı Giriniz";
                        }
                    }
                    else
                    {
                        pnl_success.Visible = false;
                        pnl_fail.Visible = true;
                        lbl_message.Text = "Yazar Adı ve Soyadı Boş Bırakılmaz";
                    }
                }
                else
                {
                    pnl_success.Visible = false;
                    pnl_fail.Visible = true;
                    lbl_message.Text = "Kitap Adı Boş Bırakılmaz";
                }
            }
            else
            {
                pnl_success.Visible = false;
                pnl_fail.Visible = true;
                lbl_message.Text = "Lütfen Kategori Seçiniz";
            }
        }
    }
}