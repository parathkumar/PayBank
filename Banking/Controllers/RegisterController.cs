using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Banking.Controllers
{
    public class RegisterController : Controller
    {
        ProjectPayV7Entities1 db = new ProjectPayV7Entities1();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomer(User obj)
        {
          
            if (ModelState.IsValid){ 
            db.Users.Add(obj);
            db.SaveChanges();
            var u_id = (from u in db.Users
                        where u.UserName == obj.UserName
                        select u).SingleOrDefault();
            Session["UserId"] = u_id.UserID;
            return RedirectToAction("RegisterOriginals");
                //return View("RegisterOriginal");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult RegisterOriginals()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterOriginals(Customer ob)
        {
            ob.UserID = Convert.ToSByte(Session["UserId"]);
            db.Customers.Add(ob);
            db.SaveChanges();
            return View();
        }
        public bool UserExist(string UserName)
        {
            var res = (from s in db.Users
                       where s.UserName == UserName
                       select s).SingleOrDefault();
            if (res != null)
                return true;
            else
                return false;
        }
        public JsonResult IsUserExist(string UserName)
        {
            return UserExist(UserName) ?
                Json(true, JsonRequestBehavior.AllowGet)
               : Json(false, JsonRequestBehavior.AllowGet);
        }
    }
 }

