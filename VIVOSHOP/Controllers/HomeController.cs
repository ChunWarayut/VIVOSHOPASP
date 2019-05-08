using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VIVOSHOP.Models;

namespace VIVOSHOP.Controllers
{
    public class HomeController : Controller
    {
        public vivoshopDBEntities db = new vivoshopDBEntities();
        public ActionResult Index(string keyword)
        {
            if (keyword == " " || keyword == null)
            {
                return View(db.Products.ToList());
            }
            else
            {
                return View(db.Products.Where(x => x.Pro_Name.Contains(keyword)).ToList());
            }

        }

        public ActionResult Create(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Order_Id,Pro_Id,OrderDetails_Number,Pro_Price")]OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderDetail);
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