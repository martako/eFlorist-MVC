using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class WarehouseType
    {
        public int Id { get; set; }
        public string WarehouseTypeName { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}