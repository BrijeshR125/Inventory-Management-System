using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        Inventory_ManagementEntities db = new Inventory_ManagementEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale s)
        {
            db.Sales.Add(s);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        public ActionResult Delete(int id, Sale s)
        {
            db.Sales.Remove(db.Sales.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(int id, Sale sale)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            s.sale_product = sale.sale_product;
            s.sale_quantity = sale.sale_quantity;
            s.sale_date = sale.sale_date;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }
    }
}