using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Books
    {
        public int ID { get; set; }
        public int Categories_ID { get; set; }
        public string Category { get; set; }
        public int Writers_ID { get; set; }
        public string Writer { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public int Publishers_ID { get; set; }
        public string Publisher { get; set; }
        public string Name { get; set; }
        public string Page { get; set; }
        public string ReleaseDate { get; set; }
        public string Image { get; set; }
        public bool State { get; set; }
        public string StateStr { get; set; }
    }
}
