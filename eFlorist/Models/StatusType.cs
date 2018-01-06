using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class StatusType
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}