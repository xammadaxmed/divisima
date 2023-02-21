using System;
using System.Collections.Generic;

namespace Shop.Models
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrderProduct = new HashSet<TblOrderProduct>();
        }

        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerZipCode { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhoneNo { get; set; }
        public int? UserId { get; set; }
        public int? Status { get; set; }
        public DateTime? DateTimeStamp { get; set; }
        public string DelieveryCharges { get; set; }

        public virtual TblUser User { get; set; }
        public virtual ICollection<TblOrderProduct> TblOrderProduct { get; set; }
    }
}
