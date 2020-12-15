using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class OrdersController : Controller
    {


        private OrderDBContext db = new OrderDBContext();
        public ActionResult Index()
        {
            var orders = from order in db.Orders
                         orderby order.OrderDate
                         select order;
            ViewBag.Orders = orders;
            return View();
        }
        public ActionResult Show(int id)
        {
            Order order = db.Orders.Find(id);
            ViewBag.Order = order;
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Order order)
        {
            try
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            Order order = db.Orders.Find(id);
            ViewBag.Order = order;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Order requestOrder)
        {
            try
            {
                Order order = db.Orders.Find(id);
                if (TryUpdateModel(order))
                {
                    order.OrderDate = requestOrder.OrderDate;
                    order.OrderDetails = requestOrder.OrderDetails;
                    
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }





}



