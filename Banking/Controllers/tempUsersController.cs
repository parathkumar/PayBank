using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Banking;
using Banking.Models;

namespace Banking.Controllers
{
    public class tempUsersController : Controller
    {
        private ProjectPayV7Entities db = new ProjectPayV7Entities();

        // GET: tempUsers
        public ActionResult Index()
        {
            return View(db.tempUsers.ToList());
        }

        // GET: tempUsers/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tempUser tempUser = db.tempUsers.Find(id);
            if (tempUser == null)
            {
                return HttpNotFound();
            }
            return View(tempUser);
        }

        // GET: tempUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tempUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,UserPassword,UserTransactionPassword,RoleID")] tempUser tempUser)
        {
            if (ModelState.IsValid)
            {
                db.tempUsers.Add(tempUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tempUser);
        }

        // GET: tempUsers/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tempUser tempUser = db.tempUsers.Find(id);
            if (tempUser == null)
            {
                return HttpNotFound();
            }
            return View(tempUser);
        }

        // POST: tempUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,UserPassword,UserTransactionPassword,RoleID")] tempUser tempUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempUser);
        }

        // GET: tempUsers/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tempUser tempUser = db.tempUsers.Find(id);
            if (tempUser == null)
            {
                return HttpNotFound();
            }
            return View(tempUser);
        }

        // POST: tempUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tempUser tempUser = db.tempUsers.Find(id);
            db.tempUsers.Remove(tempUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult RegisterCustomr()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomr(User obj)
        {
            db.Users.Add(obj);
            db.SaveChanges();
            var u_id = (from u in db.Users
                        where u.UserName == obj.UserName
                        select u).SingleOrDefault();
            Session["UserId"] = u_id.UserID;
            return RedirectToAction("RegisterOriginal");
            //return View("RegisterOriginal");
        }





    }
}
