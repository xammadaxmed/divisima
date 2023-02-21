using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblCart = new HashSet<TblCart>();
            TblOrderProduct = new HashSet<TblOrderProduct>();
            TblReviwes = new HashSet<TblReviwes>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductColor { get; set; }
        public string ProductPrice { get; set; }
        public string ProductSize { get; set; }
        public string ProductQty { get; set; }
        public string IsFeatured { get; set; }
        public string Image { get; set; }

        public virtual TblCategory Category { get; set; }
        public virtual ICollection<TblCart> TblCart { get; set; }
        public virtual ICollection<TblOrderProduct> TblOrderProduct { get; set; }
        public virtual ICollection<TblReviwes> TblReviwes { get; set; }
    }
}
