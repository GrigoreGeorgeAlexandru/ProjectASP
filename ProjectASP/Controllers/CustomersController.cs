using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProjectASP.Models;

namespace ProjectASP.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        

        private CustomerDBContext db = new CustomerDBContext();
        public ActionResult Index()
        {
            var customers = from customer in db.Customers
                           orderby customer.CustomerName
                           select customer;
            ViewBag.Customers = customers;
            return View();
        }
        public ActionResult Show(int id)
        {
            Customer customer = db.Customers.Find(id);
            ViewBag.Customer = customer;
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
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
            Customer customer = db.Customers.Find(id);
            ViewBag.Customer = customer;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Customer requestCustomer)
        {
            try
            {
                Customer customer = db.Customers.Find(id);
                if (TryUpdateModel(customer))
                {
                    customer.CustomerName = requestCustomer.CustomerName;
                    customer.CustomerEmail = requestCustomer.CustomerEmail;
                    customer.CustomerAddress = requestCustomer.CustomerAddress;
                    customer.CustomerPassword = requestCustomer.CustomerPassword;
                    customer.CustomerPhone = requestCustomer.CustomerPhone;
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
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }





}



