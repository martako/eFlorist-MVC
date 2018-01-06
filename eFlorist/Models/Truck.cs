using System.Collections.Generic;

namespace eFlorist.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string TruckName { get; set; }
        public TruckType TruckType { get; set; }
        public string Brand { get; set; }
        public string RegistrationNo { get; set; }
        public ICollection<Order> Orders { get; set; }
        public int TruckTypeId { get; set; }
    }
}