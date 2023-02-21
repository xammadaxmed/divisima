using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblProduct = new HashSet<TblProduct>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }

        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
