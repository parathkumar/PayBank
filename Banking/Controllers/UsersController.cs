using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;
namespace Banking.Controllers
{
    public class UsersController : Controller
    {
        ProjectPayV7Entities1 db = new ProjectPayV7Entities1();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(UserLoginVM obj)
        {
            if (ModelState.IsValid)
            {
                var res = (from s in db.Users 
                           where s.UserName == obj.UserName
                           && s.UserPassword == obj.UserPassword
                           select s).SingleOrDefault();
                var t =  res.RoleID;
                String uname = res.UserName;
                Session["Name"] = uname;
                if (res != null)
                  {
                    if (t == 0) { 
                        return RedirectToAction("Index", "Home");
                          }
                else
                      {
                    return RedirectToAction("RegisterCustomer","Register");
                       }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Password...Pls re-type");
                    return View();
                }
            }
                else
              {
                ModelState.AddModelError("", "Invalid Email ID");
              }
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
        
        
   
     
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}