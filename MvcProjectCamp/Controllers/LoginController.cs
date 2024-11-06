using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(Admin admin)
		{
			Context c = new Context();
			var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
			if (adminUserInfo != null)
			{
				FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
				Session["AdminUserName"]= adminUserInfo.AdminUserName;
				return RedirectToAction("Index", "AdminCategory");
			}
			else
			{
				return RedirectToAction("Index");
			}
		
		}
	}
}