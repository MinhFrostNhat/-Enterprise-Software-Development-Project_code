using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESD_Project.Models;
using System.Web.Security;

namespace ESD_Project.Controllers
{
    public class DashboardController : BaseController
    {
        private ESD_BbModel db = new ESD_BbModel();
        // Administrator Page
        public ActionResult AdminPage()
        {
                return View();
        }
        // Marketing Manager Page
        public ActionResult ManagerPage()
        {
                return View();
        }

        // Marketing Coordinator Page
        public ActionResult CoordinatorPage()
        {
                return View();
        }

        // Student Page
        public ActionResult StudentPage()
        {
                return View();
        }
    }
}