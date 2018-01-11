using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class Florist
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa kwiaciarni")]
        public string FloristName { get; set; }
        public virtual ICollection<Item> ItemsList { get; set; }
        public virtual ICollection<Invoice> InvoiceList { get; set; }
        public virtual ICollection<Warehouse> WarehouseList { get; set; }
    }
}