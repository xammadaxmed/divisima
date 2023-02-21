using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class TblReviwes
    {
        public int ReviweId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public string Comments { get; set; }
        public int? Stars { get; set; }

        public virtual TblProduct Product { get; set; }
        public virtual TblUser User { get; set; }
    }
}
