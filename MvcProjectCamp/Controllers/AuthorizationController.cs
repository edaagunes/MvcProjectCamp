using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
       AdminManager adminManager=new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = adminManager.GetAdminList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AdminAdd(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id) {
            var adminValues=adminManager.GetByIdAdmin(id);
            return View(adminValues);
        }

        [HttpPost]
		public ActionResult EditAdmin(Admin admin)
		{
			adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
		}

        public ActionResult DeleteAdmin(int id) {
            var result = adminManager.GetByIdAdmin(id);
            adminManager.AdminDelete(result);
            return RedirectToAction("Index");
        }
	}
}