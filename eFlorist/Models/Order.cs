using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Display(Name = "Numer zamówienia")]
        public string OrderNo { get; set; }
        [Display(Name = "Data zamówienia")]
        public DateTime OrderCreatedDate { get; set; }
        public StatusType OrderStatus { get; set; }
        public Truck OrderTruck { get; set; }
        public Warehouse Warehouse { get; set; }
        public PaymentType OrderPayment { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        [Display(Name = "Zaakceptowane")]
        public bool IsAccepted { get; set; }
        [Display(Name = "Odrzucone")]
        public bool IsRejected { get; set; }
        public int? OrderStatusId { get; set; }
        public int? OrderTruckId { get; set; }
        public int? WarehouseId { get; set; }
        public int? OrderPaymentId { get; set; }
    }
}