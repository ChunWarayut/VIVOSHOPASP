using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIVOSHOP.Models;

namespace VIVOSHOP.Controllers
{
    public class LoginController : Controller
    {
        public vivoshopDBEntities db = new vivoshopDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(VIVOSHOP.Models.UserAccout userModel)
        {
            var userDetail = db.UserAccouts.Where(x => x.User_Email == userModel.User_Email && x.User_Tel == userModel.User_Tel).FirstOrDefault();
            if (userDetail == null)
            {
                userModel.LoginErrorMessage = "Email หรือ เบอร์โทรศัพท์ไม่ถูกต้อง";
                return View("Index" , userModel);
            }
            else
            {
                Session["userEmail"] = userDetail.User_Email;
                Session["userID"] = userDetail.User_Id;
                return RedirectToAction("Index","Home");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}