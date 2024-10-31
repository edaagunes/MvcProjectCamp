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
	public class CategoryController : Controller
	{
		CategoryManager manager = new CategoryManager(new EfCategoryDal());

		public ActionResult GetCategoryList()
		{
			var categoryValues = manager.GetList();
			return View(categoryValues);
		}

		[HttpGet]
		public ActionResult AddCategory()
		{
			return View();
		}


		[HttpPost]
		public ActionResult AddCategory(Category category)
		{
			//manager.CategoryAdd(category);
			CategoryValidator categoryValidator = new CategoryValidator();
			ValidationResult results=categoryValidator.Validate(category);
			if (results.IsValid)
			{
				manager.CategoryAdd(category);
				return RedirectToAction("GetCategoryList");
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