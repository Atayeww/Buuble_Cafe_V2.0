using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con;
        SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConnectionString);
            cmd = con.CreateCommand();
        }

        #region Categories
        public List<Category> CategoryListing()
        {
            List<Category> list = new List<Category>();
            try
            {
                cmd.CommandText = "SELECT ID, Name, State FROM Categories WHERE State=0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category();
                    category.ID = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.State = reader.GetBoolean(2);
                    list.Add(category);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }

        public bool CategoryEdit(Category category)
        {
            try
            {
                cmd.CommandText = "UPDATE Categories SET Name = @name WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", category.ID);
                cmd.Parameters.AddWithValue("@name", category.Name);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }

        public Category CategoryGet(int id)
        {
            try
            {
                Category category = new Category();
                cmd.CommandText = "SELECT ID, Name, State FROM Categories WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    category.ID = reader.GetInt32(0);
                    category.Name = reader.GetString(1);
                    category.State = reader.GetBoolean(2);
                }
                return category;
            }
            catch { return null; }
            finally { con.Close(); }

        }
        public void CategoryDelete(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Categories SET State = 1 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id); con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }

        public bool CategoryAdd(Category category)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Categories(Name, State) VALUES(@name, @state)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", category.Name);
                cmd.Parameters.AddWithValue("@state", category.State);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        #endregion

        #region Helper
        public bool HelpingControl(string table, string column, string name)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM " + table + " WHERE " + column + " = @name";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                cmd.ExecuteScalar();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { con.Close(); }
        }
        public int HelpingControlReturnId(string table, string column, string name)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM " + table + " WHERE " + column + " = @name SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                cmd.ExecuteScalar();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                return number;
            }
            finally { con.Close(); }
        }
        #endregion

        #region Writers
        public List<Writers> WriterListing()
        {
            try
            {
                List<Writers> listwriter = new List<Writers>();
                cmd.CommandText = "SELECT * FROM Writers WHERE State = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Writers writer = new Writers();
                    writer.ID = reader.GetInt32(0);
                    writer.Name = reader.GetString(1);
                    writer.Surname = reader.GetString(2);
                    writer.State = reader.GetBoolean(3);
                    listwriter.Add(writer);
                }
                return listwriter;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public Writers WriterGet(int id)
        {
            try
            {
                Writers writer = new Writers();
                cmd.CommandText = "SELECT * FROM Writers WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    writer.ID = reader.GetInt32(0);
                    writer.Name = reader.GetString(1);
                    writer.Surname = reader.GetString(2);
                    writer.State = reader.GetBoolean(3);
                }
                return writer;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public void WriterDelete(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Writers SET State=1 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        public bool WriterEdit(Writers writers)
        {
            try
            {
                cmd.CommandText = "UPDATE Writers SET Name = @name, Surname = @surname WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", writers.ID);
                cmd.Parameters.AddWithValue("@name", writers.Name);
                cmd.Parameters.AddWithValue("@surname", writers.Surname);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public bool WriterAdd(Writers writers)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Writers(Name, Surname, State) VALUES (@name, @surname, @state)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", writers.Name);
                cmd.Parameters.AddWithValue("@surname", writers.Surname);
                cmd.Parameters.AddWithValue("@state", writers.State);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public int WriterAddReturnId(Writers writers)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Writers(Name, Surname, State) VALUES(@name, @surname, @state) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", writers.Name);
                cmd.Parameters.AddWithValue("@surname", writers.Surname);
                cmd.Parameters.AddWithValue("@state", writers.State);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            finally { con.Close(); }
        }
        public bool HelpingControlName(string name)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Writers WHERE Name = @name";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", name);
                con.Open();
                cmd.ExecuteScalar();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { con.Close(); }
        }
        public bool HelpingControlSurname(string surname)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Writers WHERE Surname = @surname";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@surname", surname);
                con.Open();
                cmd.ExecuteScalar();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally { con.Close(); }
        }
        #endregion

        #region Admin Login
        public Manager ManagerLogin(string mail, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Managers WHERE Mail = @mail AND Password = @password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                cmd.ExecuteScalar();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number > 0)
                {
                    cmd.CommandText = "SELECT * FROM Managers WHERE Mail = @mail AND Password = @password";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Manager manager = new Manager();
                    while (reader.Read())
                    {
                        manager.ID = reader.GetInt32(0);
                        manager.Name = reader.GetString(1);
                        manager.Surname = reader.GetString(2);
                        manager.Nickname = reader.GetString(3);
                        manager.Mail = reader.GetString(4);
                        manager.Password = reader.GetString(5);
                        manager.State = reader.GetBoolean(6);
                    }
                    return manager;
                }
                else { return null; }
            }
            catch { return null; }
            finally { con.Close(); }
        }
        #endregion

        #region Publisher
        public List<Publisher> PublisherListing()
        {
            try
            {
                List<Publisher> list = new List<Publisher>();
                cmd.CommandText = "SELECT * FROM Publishers WHERE State = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Publisher publisher = new Publisher();
                    publisher.ID = reader.GetInt32(0);
                    publisher.Name = reader.GetString(1);
                    publisher.State = reader.GetBoolean(2);
                    list.Add(publisher);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public Publisher PublisherGet(int id)
        {
            try
            {
                cmd.CommandText = "SELECT * FROM Publishers WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Publisher publishers = new Publisher();
                while (reader.Read())
                {
                    publishers.ID = reader.GetInt32(0);
                    publishers.Name = reader.GetString(1);
                    publishers.State = reader.GetBoolean(2);
                }
                return publishers;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public void PublisherDelete(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Publishers SET State = 1 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        public bool PublisherAdd(Publisher publisher)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Publishers(Name, State) VALUES (@name, @state)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", publisher.Name);
                cmd.Parameters.AddWithValue("@state", publisher.State);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public int PublisherAddReturnId(Publisher publisher)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Publishers(Name, State) VALUES (@name, @state) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", publisher.Name);
                cmd.Parameters.AddWithValue("@state", publisher.State);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            finally { con.Close(); }
        }
        public bool PublisherEdit(Publisher publisher)
        {
            try
            {
                cmd.CommandText = "UPDATE Publishers SET Name = @name WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", publisher.ID);
                cmd.Parameters.AddWithValue("@name", publisher.Name);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        #endregion

        #region Books
        public List<Books> BooksListing()
        {
            try
            {
                List<Books> list = new List<Books>();
                cmd.CommandText = "SELECT B.ID, B.Categories_ID, C.Name, B.Writers_ID, W.Name + ' ' + W.Surname, B.Publishers_ID, P.Name, B.Name, B.Page, B.ReleaseDate, B.Image, B.State FROM Books AS B JOIN Categories AS C ON B.Categories_ID = C.ID JOIN Writers AS W ON B.Writers_ID = W.ID JOIN Publishers AS P ON B.Publishers_ID = P.ID WHERE B.State = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Books book = new Books();
                    book.ID = reader.GetInt32(0);
                    book.Categories_ID = reader.GetInt32(1);
                    book.Category = reader.GetString(2);
                    book.Writers_ID = reader.GetInt32(3);
                    book.Writer = reader.GetString(4);
                    book.Publishers_ID = reader.GetInt32(5);
                    book.Publisher = reader.GetString(6);
                    book.Name = reader.GetString(7);
                    book.Page = reader.GetString(8);
                    book.ReleaseDate = reader.GetString(9);
                    book.Image = reader.GetString(10);
                    book.State = reader.GetBoolean(11);
                    list.Add(book);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public List<Books> BooksListing(bool state)
        {
            try
            {
                List<Books> list = new List<Books>();
                cmd.CommandText = "SELECT B.ID, B.Categories_ID, C.Name, B.Writers_ID, W.Name + ' ' + W.Surname, B.Publishers_ID, P.Name, B.Name, B.Page, B.ReleaseDate, B.Image, B.State FROM Books AS B JOIN Categories AS C ON B.Categories_ID = C.ID JOIN Writers AS W ON B.Writers_ID = W.ID JOIN Publishers AS P ON B.Publishers_ID = P.ID WHERE B.State = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Books book = new Books();
                    book.ID = reader.GetInt32(0);
                    book.Categories_ID = reader.GetInt32(1);
                    book.Category = reader.GetString(2);
                    book.Writers_ID = reader.GetInt32(3);
                    book.Writer = reader.GetString(4);
                    book.Publishers_ID = reader.GetInt32(5);
                    book.Publisher = reader.GetString(6);
                    book.Name = reader.GetString(7);
                    book.Page = reader.GetString(8);
                    book.ReleaseDate = reader.GetString(9);
                    book.Image = reader.GetString(10);
                    book.State = reader.GetBoolean(11);
                    list.Add(book);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public bool BookAdd(Books books)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Books(Categories_ID, Writers_ID, Publishers_ID, Name, Page, ReleaseDate, Image, State) VALUES (@categories_ID, @writers_ID, @publishers_ID, @name, @page, @releaseDate, @image, @state)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categories_ID", books.Categories_ID);
                cmd.Parameters.AddWithValue("@writers_ID", books.Writers_ID);
                cmd.Parameters.AddWithValue("@publishers_ID", books.Publishers_ID);
                cmd.Parameters.AddWithValue("@name", books.Name);
                cmd.Parameters.AddWithValue("@page", books.Page);
                cmd.Parameters.AddWithValue("@releaseDate", books.ReleaseDate);
                cmd.Parameters.AddWithValue("@image", books.Image);
                cmd.Parameters.AddWithValue("@state", books.State);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch{ return false; }
            finally { con.Close(); }
        }
        public int BookAddReturnId(Books books)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Books(Categories_ID, Writers_ID, Publishers_ID, Name, Page, ReleaseDate, State, Image) VALUES (@categories_ID, @writers_ID, @publishers_ID, @name, @page, @releaseDate, @state, @image) SELECT @@IDENTITY";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@categories_ID", books.Categories_ID);
                cmd.Parameters.AddWithValue("@writers_ID", books.Writers_ID);
                cmd.Parameters.AddWithValue("@publishers_ID", books.Publishers_ID);
                cmd.Parameters.AddWithValue("@name", books.Name);
                cmd.Parameters.AddWithValue("@page", books.Page);
                cmd.Parameters.AddWithValue("@releaseDate", books.ReleaseDate);
                cmd.Parameters.AddWithValue("@state", books.State);
                cmd.Parameters.AddWithValue("@image", books.Image);
                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
            finally { con.Close(); }
        }
        public bool BookEdit(Books books)
        {
            try
            {
                cmd.CommandText = "UPDATE Books SET Categories_ID = @categories_ID, Writers_ID = @writers_ID, Publishers_ID = @publishers_ID, Name = @name, Page = @page, ReleaseDate = @releaseDate, Image = @image, State = @state WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", books.ID);
                cmd.Parameters.AddWithValue("@categories_ID", books.Categories_ID);
                cmd.Parameters.AddWithValue("@writers_ID", books.Writers_ID);
                cmd.Parameters.AddWithValue("@publishers_ID", books.Publishers_ID);
                cmd.Parameters.AddWithValue("@name", books.Name);
                cmd.Parameters.AddWithValue("@page", books.Page);
                cmd.Parameters.AddWithValue("@releaseDate", books.ReleaseDate);
                cmd.Parameters.AddWithValue("@image", books.Image);
                cmd.Parameters.AddWithValue("@state", books.State);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public Books BookGet(int id)
        {
            try
            {
                cmd.CommandText = "SELECT B.ID, B.Categories_ID, C.Name, B.Writers_ID, W.Name, W.Surname, B.Publishers_ID, P.Name, B.Name, B.Page, B.ReleaseDate, B.Image, B.State FROM Books AS B JOIN Categories AS C ON B.Categories_ID = C.ID JOIN Writers AS W ON B.Writers_ID = W.ID JOIN Publishers AS P ON B.Publishers_ID = P.ID WHERE B.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Books book = new Books();
                while (reader.Read())
                {
                    book.ID = reader.GetInt32(0);
                    book.Categories_ID = reader.GetInt32(1);
                    book.Category = reader.GetString(2);
                    book.Writers_ID = reader.GetInt32(3);
                    book.WriterName = reader.GetString(4);
                    book.WriterSurname = reader.GetString(5);
                    book.Publishers_ID = reader.GetInt32(6);
                    book.Publisher = reader.GetString(7);
                    book.Name = reader.GetString(8);
                    book.Page = reader.GetString(9);
                    book.ReleaseDate = reader.GetString(10);
                    book.Image = reader.GetString(11);
                    book.State = reader.GetBoolean(12);
                }
                return book;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public void BookDelete(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Books SET State = 1 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        #endregion

        #region Users
        public List<Users> UsersListing()
        {
            try
            {
                List<Users> list = new List<Users>();
                cmd.CommandText = "SELECT * FROM Users WHERE State = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    Users users = new Users();
                    users.ID = r.GetInt32(0);
                    users.Name = r.GetString(1);
                    users.Surname = r.GetString(2);
                    users.Nickname = r.GetString(3);
                    users.Mail = r.GetString(4);
                    users.Password = r.GetString(5);
                    users.State = r.GetBoolean(6);
                    list.Add(users);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public List<Users> UsersListing(bool state)
        {
            try
            {
                List<Users> list = new List<Users>();
                cmd.CommandText = "SELECT * FROM Users WHERE State = @state";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@state", state);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    Users users = new Users();
                    users.ID = r.GetInt32(0);
                    users.Name = r.GetString(1);
                    users.Surname = r.GetString(2);
                    users.Nickname = r.GetString(3);
                    users.Mail = r.GetString(4);
                    users.Password = r.GetString(5);
                    users.State = r.GetBoolean(6);
                    list.Add(users);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public Users UsersGet(int id)
        {
            try
            {
                cmd.CommandText = "SELECT * From Users WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader r = cmd.ExecuteReader();
                Users users = new Users();
                while (r.Read())
                {
                    users.ID = r.GetInt32(0);
                    users.Name = r.GetString(1);
                    users.Surname = r.GetString(2);
                    users.Nickname = r.GetString(3);
                    users.Mail = r.GetString(4);
                    users.Password = r.GetString(5);
                    users.State = r.GetBoolean(6);
                }
                return users;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public void UsersAccept(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Users SET State = 0 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        public void UsersHardDelete(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Citations WHERE Users_ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Comments WHERE Users_ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Users WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        public bool UsersAdd(Users users)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Users(Name, Surname, Nickname, Mail, Password, State) VALUES (@name, @surname, @nickname, @mail, @password, @state)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", users.Name);
                cmd.Parameters.AddWithValue("@surname", users.Surname);
                cmd.Parameters.AddWithValue("@nickname", users.Nickname);
                cmd.Parameters.AddWithValue("@mail", users.Mail);
                cmd.Parameters.AddWithValue("@password", users.Password);
                cmd.Parameters.AddWithValue("@state", users.State);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public bool UsersEdit(Users users)
        {
            try
            {
                cmd.CommandText = "UPDATE Users SET Name = @name, Surname = @surname, Nickname = @nickname, Mail = @mail, Password = @password, State = @state";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@name", users.Name);
                cmd.Parameters.AddWithValue("@surname", users.Surname);
                cmd.Parameters.AddWithValue("@nickname", users.Nickname);
                cmd.Parameters.AddWithValue("@mail", users.Mail);
                cmd.Parameters.AddWithValue("@password", users.Password);
                cmd.Parameters.AddWithValue("@state", users.State);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public Users UserLogin(string mail, string password)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Mail = @mail AND Password = @password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@password", password);
                con.Open();
                cmd.ExecuteScalar();
                int number = Convert.ToInt32(cmd.ExecuteScalar());
                if (number > 0)
                {
                    cmd.CommandText = "SELECT * FROM Users WHERE Mail = @mail AND Password = @password";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Users users = new Users();
                    while (reader.Read())
                    {
                        users.ID = reader.GetInt32(0);
                        users.Name = reader.GetString(1);
                        users.Surname = reader.GetString(2);
                        users.Nickname = reader.GetString(3);
                        users.Mail = reader.GetString(4);
                        users.Password = reader.GetString(5);
                        users.State = reader.GetBoolean(6);
                    }
                    return users;
                }
                else { return null; }
            }
            catch { return null; }
            finally { con.Close(); }
        }
        #endregion

        #region Citation
        public List<Citations> CitationListing()
        {
            try
            {
                List<Citations> list = new List<Citations>();
                cmd.CommandText = "SELECT C.ID, C.Users_ID, U.Nickname, C.Books_ID, B.Name, C.Citation, C.Opinion, C.Page, C.CitationView, C.AddDateTime, C.Liked, C.Disliked, C.State FROM Citations AS C JOIN Users AS U ON C.Users_ID = U.ID JOIN Books AS B ON C.Books_ID = B.ID WHERE C.State = 0";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Citations citations = new Citations();
                    citations.ID = reader.GetInt32(0);
                    citations.Users_ID = reader.GetInt32(1);
                    citations.User = reader.GetString(2);
                    citations.Books_ID = reader.GetInt32(3);
                    citations.BookName = reader.GetString(4);
                    citations.Citation = reader.GetString(5);
                    citations.Opinion = reader.GetString(6);
                    citations.Page = reader.GetString(7);
                    citations.CitationView = reader.GetInt32(8);
                    citations.AddDateTime = reader.GetDateTime(9);
                    citations.Liked = reader.GetInt32(10);
                    citations.Disliked = reader.GetInt32(11);
                    citations.State = reader.GetBoolean(12);
                    list.Add(citations);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public List<Citations> CitationListing(bool state)
        {
            try
            {
                List<Citations> list = new List<Citations>();
                cmd.CommandText = "SELECT C.ID, C.Users_ID, U.Nickname, C.Books_ID, B.Name, B.Image, B.Writers_ID, W.Name + ' ' + W.Surname, B.Categories_ID, CY.Name, C.Citation, C.Opinion, C.Page, C.CitationView, C.AddDateTime, C.Liked, C.Disliked, C.State FROM Citations AS C JOIN Users AS U ON C.Users_ID = U.ID JOIN Books AS B ON C.Books_ID = B.ID JOIN Writers AS W ON B.Writers_ID = W.ID JOIN Categories AS CY ON B.Categories_ID = CY.ID WHERE C.State = @state";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@state", state);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Citations citations = new Citations();
                    citations.ID = reader.GetInt32(0);
                    citations.Users_ID = reader.GetInt32(1);
                    citations.User = reader.GetString(2);
                    citations.Books_ID = reader.GetInt32(3);
                    citations.BookName = reader.GetString(4);
                    citations.BookImage = reader.GetString(5);
                    citations.BookWriters_ID= reader.GetInt32(6);
                    citations.BookWriters = reader.GetString(7);
                    citations.BookCategories_ID = reader.GetInt32(8);
                    citations.BookCategories = reader.GetString(9);
                    citations.Citation = reader.GetString(10);
                    citations.Opinion = reader.GetString(11);
                    citations.Page = reader.GetString(12);
                    citations.CitationView = reader.GetInt32(13);
                    citations.AddDateTime = reader.GetDateTime(14);
                    citations.Liked = reader.GetInt32(15);
                    citations.Disliked = reader.GetInt32(16);
                    citations.State = reader.GetBoolean(17);
                    list.Add(citations);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public List<Citations> CitationListing(int citid, bool state)
        {
            try
            {
                List<Citations> list = new List<Citations>();
                cmd.CommandText = "SELECT C.ID, C.Users_ID, U.Nickname, C.Books_ID, B.Name, B.Image, B.Writers_ID, W.Name + ' ' + W.Surname, B.Categories_ID, CY.Name, C.Citation, C.Opinion, C.Page, C.CitationView, C.AddDateTime, C.Liked, C.Disliked, C.State FROM Citations AS C JOIN Users AS U ON C.Users_ID = U.ID JOIN Books AS B ON C.Books_ID = B.ID JOIN Writers AS W ON B.Writers_ID = W.ID JOIN Categories AS CY ON B.Categories_ID = CY.ID WHERE C.ID = @id AND C.State = @state";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", citid);
                cmd.Parameters.AddWithValue("@state", state);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Citations citations = new Citations();
                    citations.ID = reader.GetInt32(0);
                    citations.Users_ID = reader.GetInt32(1);
                    citations.User = reader.GetString(2);
                    citations.Books_ID = reader.GetInt32(3);
                    citations.BookName = reader.GetString(4);
                    citations.BookImage = reader.GetString(5);
                    citations.BookWriters_ID = reader.GetInt32(6);
                    citations.BookWriters = reader.GetString(7);
                    citations.BookCategories_ID = reader.GetInt32(8);
                    citations.BookCategories = reader.GetString(9);
                    citations.Citation = reader.GetString(10);
                    citations.Opinion = reader.GetString(11);
                    citations.Page = reader.GetString(12);
                    citations.CitationView = reader.GetInt32(13);
                    citations.AddDateTime = reader.GetDateTime(14);
                    citations.Liked = reader.GetInt32(15);
                    citations.Disliked = reader.GetInt32(16);
                    citations.State = reader.GetBoolean(17);
                    list.Add(citations);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public bool CitationAdd(Citations citations)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Citations(Users_ID, Books_ID, Citation, Opinion, Page, AddDateTime, State, Liked, Disliked, CitationView) VALUES (@users_ID, @books_ID, @citation, @opinion, @page, @addDateTime, @state, @liked, @disliked, @citationView)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@users_ID", citations.Users_ID);
                cmd.Parameters.AddWithValue("@books_ID", citations.Books_ID);
                cmd.Parameters.AddWithValue("@citation", citations.Citation);
                cmd.Parameters.AddWithValue("@opinion", citations.Opinion);
                cmd.Parameters.AddWithValue("@page", citations.Page);
                cmd.Parameters.AddWithValue("@addDateTime", citations.AddDateTime);
                cmd.Parameters.AddWithValue("@state", citations.State);
                cmd.Parameters.AddWithValue("@liked", citations.Liked);
                cmd.Parameters.AddWithValue("@disliked", citations.Disliked);
                cmd.Parameters.AddWithValue("@citationView", citations.CitationView);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public Citations CitationGet(int id)
        {
            try
            {
                cmd.CommandText = "SELECT C.ID, C.Users_ID, U.Nickname, C.Books_ID, B.Name, B.Image, B.Writers_ID, W.Name + ' ' + W.Surname, B.Categories_ID, CY.Name, C.Citation, C.Opinion, C.Page, C.CitationView, C.AddDateTime, C.Liked, C.Disliked, C.State, B.Page FROM Citations AS C JOIN Users AS U ON C.Users_ID = U.ID JOIN Books AS B ON C.Books_ID = B.ID JOIN Writers AS W ON B.Writers_ID = W.ID JOIN Categories AS CY ON B.Categories_ID = CY.ID WHERE C.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Citations citations = new Citations();
                while (reader.Read())
                {
                    citations.ID = reader.GetInt32(0);
                    citations.Users_ID = reader.GetInt32(1);
                    citations.User = reader.GetString(2);
                    citations.Books_ID = reader.GetInt32(3);
                    citations.BookName = reader.GetString(4);
                    citations.BookImage = reader.GetString(5);
                    citations.BookWriters_ID = reader.GetInt32(6);
                    citations.BookWriters = reader.GetString(7);
                    citations.BookCategories_ID = reader.GetInt32(8);
                    citations.BookCategories = reader.GetString(9);
                    citations.Citation = reader.GetString(10);
                    citations.Opinion = reader.GetString(11);
                    citations.Page = reader.GetString(12);
                    citations.CitationView = reader.GetInt32(13);
                    citations.AddDateTime = reader.GetDateTime(14);
                    citations.Liked = reader.GetInt32(15);
                    citations.Disliked = reader.GetInt32(16);
                    citations.State = reader.GetBoolean(17);
                    citations.BookPage = reader.GetString(18);
                }
                return citations;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public bool CitationViewUpdate(int id)
        {
            try
            {
                cmd.CommandText = "SELECT CitationView FROM Citations WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int num = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Citations SET CitationView = @num WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                num = num + 1;
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public bool CitationLikedUpdate(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Liked FROM Citations WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int num = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Citations SET Liked = @num WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                num = num + 1;
                cmd.Parameters.AddWithValue("@num", num);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public Citations CitationLikedUpdateGet(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Liked FROM Citations WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int num = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Citations SET Liked = @num WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                num = num + 1;
                cmd.Parameters.AddWithValue("@num", num);
                SqlDataReader reader = cmd.ExecuteReader();
                Citations citations = new Citations();
                while (reader.Read())
                {
                    citations.Liked = reader.GetInt32(0);
                }
                return citations;
            }
            finally { con.Close(); }
        }
        public bool CitationDislikedUpdate(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Disliked FROM Citations WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int num = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Citations SET Disliked = @num WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                num = num + 1;
                cmd.Parameters.AddWithValue("@num", num);

                cmd.CommandText = "SELECT Liked FROM Citations WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                int number = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Citations SET Liked = @num WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                number = number - 1;
                cmd.Parameters.AddWithValue("@num", number);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        public void CitationState(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Citations SET State = 0 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        public void CitationHardDelete(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Comments WHERE Citations_ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "DELETE FROM Citations WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            finally { con.Close(); }
        }
        #endregion

        #region Comment
        public List<Comment> CommnetList(bool state)
        {
            try
            {
                List<Comment> list = new List<Comment>();
                cmd.CommandText = "SELECT C.ID, C.Users_ID, U.Nickname, C.Citations_ID, C.CommentDateTime, C.Comment FROM Comments AS C JOIN Users AS U ON C.Users_ID = U.ID WHERE C.State = @state";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@state", state);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comment comment = new Comment();
                    comment.ID = reader.GetInt32(0);
                    comment.Users_ID= reader.GetInt32(1);
                    comment.UserNickname = reader.GetString(2);
                    comment.Citations_ID = reader.GetInt32(3);
                    comment.CommentDateTime= reader.GetDateTime(4);
                    comment.Commnet = reader.GetString(5);
                    list.Add(comment);
                }
                return list;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public Comment CommnetGet(bool state)
        {
            try
            {
                cmd.CommandText = "SELECT C.ID, C.Users_ID, U.Nickname, C.Citations_ID, C.CommentDateTime, C.Comment FROM Comments AS C JOIN Users AS U ON C.Users_ID = U.ID WHERE C.State = @state";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@state", state);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Comment comment = new Comment();
                while (reader.Read())
                {
                    comment.ID = reader.GetInt32(0);
                    comment.Users_ID = reader.GetInt32(1);
                    comment.UserNickname = reader.GetString(2);
                    comment.Citations_ID = reader.GetInt32(3);
                    comment.CommentDateTime = reader.GetDateTime(4);
                    comment.Commnet = reader.GetString(5);
                }
                return comment;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public bool CommentAdd(Comment comment)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Comments(Users_ID, Citations_ID, CommentDateTime, Comment, State) VALUES (@users_ID, @citations_ID, @commentDateTime, @comment, @state)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@users_ID", comment.Users_ID);
                cmd.Parameters.AddWithValue("@citations_ID", comment.Citations_ID);
                cmd.Parameters.AddWithValue("@commentDateTime", comment.CommentDateTime);
                cmd.Parameters.AddWithValue("comment", comment.Commnet);
                cmd.Parameters.AddWithValue("@state", comment.State);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        #endregion

    }
}
