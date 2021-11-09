using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_ManagementEntities db = new Inventory_ManagementEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = db.Products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pr)
        {
            db.Purchases.Add(pr);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(int id, Purchase pr)
        {
            db.Purchases.Remove(db.Purchases.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(int id, Purchase pr)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            p.purchase_product = pr.purchase_product;
            p.purchase_quantity = pr.purchase_quantity;
            p.purchase_date = pr.purchase_date;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }
    }
}