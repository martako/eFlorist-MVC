using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class StatusType
    {
        public int Id { get; set; }
        [Display(Name = "Status zamówienia")]
        public string StatusName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}