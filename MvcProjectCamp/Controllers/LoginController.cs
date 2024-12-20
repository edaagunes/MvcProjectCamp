﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		AdminManager adminManager=new AdminManager(new EfAdminDal());
		WriterLoginManager writerLoginManager=new WriterLoginManager(new EfWriterDal());
		AdminLoginManager adminLoginManager=new AdminLoginManager(new EfAdminDal());
		Context context=new Context();

		[HttpGet]
		public ActionResult AdminLogin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AdminLogin(Admin admin)
		{
			//	Context c = new Context();
			//	var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);

			var adminUserInfo = adminLoginManager.GetAdmin(admin.AdminUserName, admin.AdminPassword);

			if (adminUserInfo != null)
			{
				FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
				Session["AdminUserName"]= adminUserInfo.AdminUserName;
				return RedirectToAction("Index", "AdminCategory");
			}
			else
			{
				ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
				return RedirectToAction("Index");
			}
		}

		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("AdminLogin", "Login");
		}

		[HttpGet]
		public ActionResult WriterLogin()
		{
			return View();
		}

		[HttpPost]
		public ActionResult WriterLogin(Writer writer)
		{
			//Context c = new Context();
			//var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
			var writerUserInfo=writerLoginManager.GetWriter(writer.WriterMail, writer.WriterPassword);

			if (writerUserInfo != null)
			{
				FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
				Session["WriterMail"] = writerUserInfo.WriterMail;
				Session["WriterName"] = writerUserInfo.WriterName+" "+writerUserInfo.WriterSurname;
				Session["WriterImage"] = writerUserInfo.WriterImage;
				return RedirectToAction("MyHeading", "WriterPanel");
			}
			else
			{
				ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifreniz Yanlış!";
				return RedirectToAction("WriterLogin");
			}
		}

		[HttpGet]
		public ActionResult WriterLogout()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("WriterLogin", "Login");
		}
	}
}