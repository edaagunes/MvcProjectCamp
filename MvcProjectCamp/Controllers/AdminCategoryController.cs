using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
	public class AdminCategoryController : Controller
	{
		CategoryManager manager = new CategoryManager(new EfCategoryDal());
		HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
		public ActionResult Index()
		{
			var categoryValues = manager.GetList();
			return View(categoryValues);
		}
		public ActionResult HeadingByCategory(int id)
		{
			var headings = headingManager.GetListByCategory(id);
			return View(headings);
		}



		[HttpGet]
		public ActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddCategory(Category category)
		{
			CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult results = categoryValidator.Validate(category);
			if (results.IsValid)
			{
				manager.CategoryAdd(category);
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

		public ActionResult DeleteCategory(int id)
		{
			var categoryValue=manager.GetById(id);
			manager.CategoryDelete(categoryValue);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult EditCategory(int id)
		{
			var categoryValue=manager.GetById(id);
			return View(categoryValue);
		}

		[HttpPost]
		public ActionResult EditCategory(Category category)
		{
			manager.CategoryUpdate(category);
			return RedirectToAction("Index");
		}
	}
}