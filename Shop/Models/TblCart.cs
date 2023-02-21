using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class TblCart
    {
        public int CartId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public string ProductSize { get; set; }
        public string ProductPrice { get; set; }
        public int? ProductQty { get; set; }
        public string ProductColor { get; set; }
        public string SubTotal { get; set; }
        public string TotalPrice { get; set; }

        public virtual TblProduct Product { get; set; }
        public virtual TblUser User { get; set; }
    }
}
