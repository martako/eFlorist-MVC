using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Display(Name = "Baza magazynowa")]
        public string WarehouseName { get; set; }
        public WarehouseType WarehouseType { get; set; }
        public ICollection<Order> OrderList { get; set; }
        public ICollection<Invoice> InvoiceList { get; set; }
        public virtual ICollection<Florist> FloristList { get; set; }
        public int? WarehouseTypeId { get; set; }
    }
}