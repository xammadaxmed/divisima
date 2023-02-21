using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblCart = new HashSet<TblCart>();
            TblOrder = new HashSet<TblOrder>();
            TblReviwes = new HashSet<TblReviwes>();
        }

        public int UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }
        public int? NewsLetter { get; set; }

        public virtual ICollection<TblCart> TblCart { get; set; }
        public virtual ICollection<TblOrder> TblOrder { get; set; }
        public virtual ICollection<TblReviwes> TblReviwes { get; set; }
    }
}
