using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Citations
    {
        public int ID { get; set; }
        public int Users_ID { get; set; }
        public string User { get; set; }
        public int Books_ID { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public string BookPage { get; set; }
        public int BookWriters_ID { get; set; }
        public string BookWriters { get; set; }
        public int BookCategories_ID { get; set; }
        public string BookCategories { get; set; }
        public string Citation { get; set; }
        public string Opinion { get; set; }
        public string Page { get; set; }
        public int CitationView { get; set; }
        public DateTime AddDateTime { get; set; }
        public int Liked { get; set; }
        public int Disliked { get; set; }
        public bool State { get; set; }
    }
}
