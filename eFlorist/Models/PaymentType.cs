using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string PaymentName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}