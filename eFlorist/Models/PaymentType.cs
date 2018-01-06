using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Display(Name = "Płatność")]
        public string PaymentName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}