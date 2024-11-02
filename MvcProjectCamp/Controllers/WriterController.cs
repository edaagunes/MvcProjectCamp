using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
	public class WriterController : Controller
	{
		WriterManager manager = new WriterManager(new EfWriterDal());
		public ActionResult Index()
		{
			var writerValues = manager.GetList();
			return View(writerValues);
		}

		[HttpGet]
		public ActionResult AddWriter()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddWriter(Writer writer)
		{
			WriterValidator writerValidator = new WriterValidator();
			ValidationResult results = writerValidator.Validate(writer);
			if (results.IsValid)
			{
				manager.WriterAdd(writer);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
	}
}