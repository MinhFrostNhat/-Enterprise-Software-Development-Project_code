using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESD_Project.Common;
using ESD_Project.Models;

namespace ESD_Project.Controllers
{
    public class UsersController : Controller
    {
        private ESD_BbModel db = new ESD_BbModel();

        // GET: Users
        public ActionResult Index()
        {
            var user = db.User.Include(u => u.GroupMember).Include(u => u.Major);
            return View(user.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(db.GroupMember, "GroupId", "Name");
            ViewBag.MajorId = new SelectList(db.Major, "MajorId", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,Email,Username,Password,Phone,Address,DateOfBirth,GroupId,MajorId")] User user)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.User.FirstOrDefault(s => s.Email == user.Email);
                var checkUsername = db.User.FirstOrDefault(s => s.Username == user.Username);
                if (checkEmail != null)
                {
                    ModelState.AddModelError("", "Email already exists");
                }
                else if(checkUsername != null) 
                {
                    ModelState.AddModelError("", "Username already exists");
                }
                else
                {
                    user.Password = Encryptor.GetMD5(user.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.User.Add(user);
                    var result = db.SaveChanges();
                    if (result > 0)
                    {
                        ViewBag.Success = "Create Successfully!";
                    }
                    else {
                        ModelState.AddModelError("","Create unsuccessfully! Please try again.");
                    }
                }
            }

            ViewBag.GroupId = new SelectList(db.GroupMember, "GroupId", "Name", user.GroupId);
            ViewBag.MajorId = new SelectList(db.Major, "MajorId", "Name", user.MajorId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(db.GroupMember, "GroupId", "Name", user.GroupId);
            ViewBag.MajorId = new SelectList(db.Major, "MajorId", "Name", user.MajorId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Email,Username,Password,Phone,Address,DateOfBirth,GroupId,MajorId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.GroupMember, "GroupId", "Name", user.GroupId);
            ViewBag.MajorId = new SelectList(db.Major, "MajorId", "Name", user.MajorId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
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
    }
}
