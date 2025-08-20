using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using introEF.EF;

namespace introEF.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductDBEntities db = new ProductDBEntities();
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = db.Products.Find(id); //searches with PK
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            var upData = db.Products.Find(p.ProdcutId); 
            if (upData != null)
            {
                upData.Name = p.Name;
                upData.Price = p.Price;
                upData.Quantity = p.Quantity;
                upData.Description = p.Description;

                db.SaveChanges();
            }

            return RedirectToAction("Index"); 
        }

        public ActionResult Delete(int id)
        {
            var dlData = db.Products.Find(id);

            if(dlData != null)
            {
                db.Products.Remove(dlData);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }


    }
}