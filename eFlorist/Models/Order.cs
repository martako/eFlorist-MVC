using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eFlorist.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public StatusType OrderStatus { get; set; }
        public Truck OrderTruck { get; set; }
        public Warehouse Warehouse { get; set; }
        public PaymentType OrderPayment { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRejected { get; set; }
        public int OrderStatusId { get; set; }
        public int OrderTruckId { get; set; }
        public int WarehouseId { get; set; }
        public int OrderPaymentId { get; set; }
    }
}