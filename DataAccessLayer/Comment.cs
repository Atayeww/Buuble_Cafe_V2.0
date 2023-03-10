using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Comment
    {
        public int ID { get; set; }
        public int Users_ID { get; set; }
        public string UserNickname { get; set; }
        public int Citations_ID { get; set; }
        public string CitationsUserNickname { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string Commnet { get; set; }
        public bool State { get; set; }
        public int Books_ID { get; set; }
        public int Categories_ID { get; set; }
        public int CategoryID { get; set; }
    }
}
