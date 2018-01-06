using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public ItemType ItemType { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Florist> Florists { get; set; }
        public int ItemTypeId { get; set; }
    }
}