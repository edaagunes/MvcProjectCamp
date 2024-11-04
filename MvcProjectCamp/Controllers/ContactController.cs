using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
	public class ContactController : Controller
	{
		ContactManager manager = new ContactManager(new EfContactDal());
		ContactValidator validationRules = new ContactValidator();
		public ActionResult Index()
		{
			var contactValues = manager.GetList();
			return View(contactValues);
		}

		public PartialViewResult MessageMenuPartial()
		{
			return PartialView();
		}

		public ActionResult GetContactDetails(int id)
		{
			var contactValues= manager.GetById(id);
			return View(contactValues);
		}
	}
}