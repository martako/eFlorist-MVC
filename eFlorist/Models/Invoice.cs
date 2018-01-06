using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Display(Name = "Numer faktury")]
        public string InvoiceNo { get; set; }
        public Warehouse Warehouse { get; set; }
        public Florist Florist { get; set; }
        public Order Order { get; set; }
        public int? WarehouseId { get; set; }
        public int? FloristId { get; set; }
    }
}