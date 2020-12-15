using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace project.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        private OrderDBContext db = new OrderDBContext();
        public ActionResult Index()
        {
            var products = from product in db.Products
                          orderby product.ProductName
                            select product;
            ViewBag.Products = products;
            return View();
        }
        public ActionResult Show(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.Product = product;
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Product product)
        {
            try
            {
                db.Products.Add(product);
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
            Product product = db.Products.Find(id);
            ViewBag.Product = product;
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Product requestProduct)
        {
            try
            {
                Product product = db.Products.Find(id);
                if (TryUpdateModel(product))
                {
                    product.ProductColor= requestProduct.ProductColor;
                    product.ProductDescription = requestProduct.ProductDescription;
                    product.ProductName = requestProduct.ProductName;
                    product.ProductPrice = requestProduct.ProductPrice;
                    product.ProductSize = requestProduct.ProductSize;
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
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}