using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        Inventory_ManagementEntities db = new Inventory_ManagementEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]

        public ActionResult UpdateProduct(int id)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(int id, Product prod)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();
            product.product_name = prod.product_name;
            product.product_quantity = prod.product_quantity;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult ProductDetail(int id)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(product);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id, Product prod)
        {
            db.Products.Remove(db.Products.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}