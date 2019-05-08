using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VIVOSHOP.Models;

namespace VIVOSHOP.Controllers
{
    public class BankController : Controller
    {
        public vivoshopDBEntities db = new vivoshopDBEntities();
        // GET: Bank
        public ActionResult Index(string keyword)
        {
            if (keyword == " " || keyword == null)
            {
                return View(db.Banks.ToList());
            }
            else
            {
                var c = db.Banks.Where(x => x.Bank_Name.Contains(keyword)).ToList();
                var b = db.Banks.Where(x => x.Bank_Number.Contains(keyword)).ToList();
                var A = db.Banks.Where(x => x.Bank_Number.Contains("123456789")).ToList();
                if (b.Count > 0)
                {
                    A = b;
                }
                if (c.Count > 0)
                {
                    A = c;
                }
                return View(A);
            } 
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Bank_Number,Bank_Name,Bank_User")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Banks.Add(bank);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(bank);
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bank_Number,Bank_Name,Bank_User")] Bank bank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bank);
        }
         


        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank == null)
            {
                return HttpNotFound();
            }
            return View(bank);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bank bank = db.Banks.Find(id);
            if (bank==null)
            {
                return HttpNotFound();
            }
            return View(bank); 
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