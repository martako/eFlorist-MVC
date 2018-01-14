using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eFlorist.Models;

namespace eFlorist.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private EFloristDbContext db = new EFloristDbContext();

        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Invoice).Include(o => o.OrderPayment).Include(o => o.OrderStatus).Include(o => o.OrderTruck).Include(o => o.Warehouse);
            return View(orders.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            //order.OrderItems = db.OrderItems.Where(x => x.OrderId == id).Include(x => x.Item).ToList();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Invoices, "Id", "InvoiceNo");
            ViewBag.OrderPaymentId = new SelectList(db.PaymentTypes, "Id", "PaymentName");
            ViewBag.OrderStatusId = new SelectList(db.StatusTypes, "Id", "StatusName");
            ViewBag.OrderTruckId = new SelectList(db.Trucks, "Id", "TruckName");
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "WarehouseName");
            ViewBag.FloristId = new SelectList(db.Florists, "Id", "FloristName");

            return View(new Order { OrderCreatedDate = DateTime.Now });
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderNo,OrderCreatedDate,IsAccepted,IsRejected,OrderStatusId,OrderTruckId,WarehouseId,OrderPaymentId,FloristId")] Order order)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 100000);
                order.OrderNo = randomNumber.ToString();
                order.OrderCreatedDate = DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.Id = new SelectList(db.Invoices, "Id", "InvoiceNo", order.Id);
            ViewBag.OrderPaymentId = new SelectList(db.PaymentTypes, "Id", "PaymentName", order.OrderPaymentId);
            ViewBag.OrderStatusId = new SelectList(db.StatusTypes, "Id", "StatusName", order.OrderStatusId);
            ViewBag.OrderTruckId = new SelectList(db.Trucks, "Id", "TruckName", order.OrderTruckId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "WarehouseName", order.WarehouseId);
            ViewBag.FloristId = new SelectList(db.Florists, "Id", "FloristName", order.FloristId);

            return View(order);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            //order.OrderItems = db.OrderItems.Where(x => x.OrderId == id).Include(x => x.Item).ToList();
            //ViewBag.OrderNo = order.OrderNo;
            ViewBag.Id = new SelectList(db.Invoices, "Id", "InvoiceNo", order.Id);
            ViewBag.OrderPaymentId = new SelectList(db.PaymentTypes, "Id", "PaymentName", order.OrderPaymentId);
            ViewBag.OrderStatusId = new SelectList(db.StatusTypes, "Id", "StatusName", order.OrderStatusId);
            ViewBag.OrderTruckId = new SelectList(db.Trucks, "Id", "TruckName", order.OrderTruckId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "WarehouseName", order.WarehouseId);
            ViewBag.FloristId = new SelectList(db.Florists, "Id", "FloristName");

            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderNo,OrderCreatedDate,IsAccepted,IsRejected,OrderStatusId,OrderTruckId,WarehouseId,OrderPaymentId,FloristId")] Order order)
        {
            if (ModelState.IsValid)
            {
                //order.OrderNo = db.Orders.Single(x => x.Id == order.Id).OrderNo; //ViewBag.OrderNo;
                //order.OrderCreatedDate = DateTime.Now;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Invoices, "Id", "InvoiceNo", order.Id);
            ViewBag.OrderPaymentId = new SelectList(db.PaymentTypes, "Id", "PaymentName", order.OrderPaymentId);
            ViewBag.OrderStatusId = new SelectList(db.StatusTypes, "Id", "StatusName", order.OrderStatusId);
            ViewBag.OrderTruckId = new SelectList(db.Trucks, "Id", "TruckName", order.OrderTruckId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "WarehouseName", order.WarehouseId);
            ViewBag.FloristId = new SelectList(db.Florists, "Id", "FloristName");

            return View(order);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
