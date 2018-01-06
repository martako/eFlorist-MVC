using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eFlorist.Models
{
    public class Truck
    {
        public int Id { get; set; }
        [Display(Name = "Pojazd")]
        public string TruckName { get; set; }
        public TruckType TruckType { get; set; }
        public string Brand { get; set; }
        public string RegistrationNo { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int? TruckTypeId { get; set; }
    }
}