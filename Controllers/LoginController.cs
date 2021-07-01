using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ESD_Project.Common;
using ESD_Project.Models;
using BotDetect.Web.Mvc;

namespace ESD_Project.Controllers
{

    public class LoginController : Controller
    {
        private ESD_BbModel db = new ESD_BbModel();

        public ActionResult Login()
        {
            return View();
        }

        public User GetByID(string username) 
        {
            return db.User.SingleOrDefault(x => x.Username == username);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            string userInput = HttpContext.Request.Form["CaptchaCode"];
            var f_password = Encryptor.GetMD5(password);
            var acc = db.User.Where(s => s.Username.Equals(username) && s.Password.Equals(f_password)).ToList();
            if (username != null && password != null)
            {
                if (acc.Count() > 0)
                {
                    MvcCaptcha mvcCaptcha = new MvcCaptcha("LoginCaptcha");
                    if (mvcCaptcha.Validate(userInput))
                    {
                        //Add Session
                        var user = GetByID(username);
                        var userSession = new UserLogin();
                        userSession.ID = user.UserId;
                        userSession.Username = user.Username;
                        Session.Add(CommonConstants.USER_SESSION, userSession);

                        var roleAdmin = db.User.Where(s => s.GroupId.Equals("Admin")).ToList();
                        var roleManager = db.User.Where(s => s.GroupId.Equals("Manager")).ToList();
                        var roleCoordinator = db.User.Where(s => s.GroupId.Equals("Coordinator")).ToList();
                        var roleStudent = db.User.Where(s => s.GroupId.Equals("Student")).ToList();

                        // Authorize the "Admin" right
                        if (roleAdmin.Count() > 0)
                        {
                            // direct to admin page if authorize successfully
                            return RedirectToAction("AdminPage", "Dashboard");

                        }

                        // Authorize the "Manager" right
                        else if (roleManager.Count() > 0)
                        {
                            // direct to Marketing Manager page if authorize successfully
                            return RedirectToAction("ManagerPage", "Dashboard");
                        }

                        // Authorize the "Coordinator" right
                        else if (roleCoordinator.Count() > 0)
                        {
                            // direct to Marketing Coordinator page if authorize successfully
                            return RedirectToAction("CoordinatorPage", "Dashboard");
                        }

                        // Authorize the "Student" right
                        else if (roleStudent.Count() > 0)
                        {
                            // direct to Student page if authorize successfully
                            return RedirectToAction("StudentPage", "Dashboard");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Your account have not the right to login. Please try againt with another account");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Wrong Captcha!");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Your Username or Password is incorrect. Please try again!");
                }
            }
            else 
            {
                ModelState.AddModelError("", "Username and Password cannot be blank.");
            }
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            //Session[CommonConstants.USER_SESSION] = null; 
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}