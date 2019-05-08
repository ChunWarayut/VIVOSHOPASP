using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Create(string id,string amout)
        {
            List<string> modes = new List<string>();
            modes.Add("Simple");
            modes.Add("Advanced");
            modes.Add("Manual");
            modes.Add("Complete");
            ViewBag["Modes"] = modes;
            return View();
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