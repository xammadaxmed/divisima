using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class TblOrderProduct
    {
        public int OrderProductId { get; set; }
        public int? ProductId { get; set; }
        public string OrderProductQty { get; set; }
        public int? OrderId { get; set; }
        public string OrderProductColor { get; set; }
        public string OrderProductSize { get; set; }

        public virtual TblOrder Order { get; set; }
        public virtual TblProduct Product { get; set; }
    }
}
