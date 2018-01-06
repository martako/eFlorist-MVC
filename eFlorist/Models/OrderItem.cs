using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public Order Order { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
    }
}