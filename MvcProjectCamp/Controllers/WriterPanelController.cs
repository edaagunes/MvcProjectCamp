using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjectCamp.Controllers
{
	public class WriterPanelController : Controller
	{
		HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
		WriterManager writerManager = new WriterManager(new EfWriterDal());
		WriterValidator writerValidator = new WriterValidator();

		Context context = new Context();

		[HttpGet]
		public ActionResult WriterProfile(int id=0)
		{
			string p = (string)Session["WriterMail"];
			id = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
			var writerValue=writerManager.GetById(id);
			return View(writerValue);
		}

		[HttpPost]
		public ActionResult WriterProfile(Writer writer)
		{
			ValidationResult results = writerValidator.Validate(writer);
			if (results.IsValid)
			{
				writerManager.WriterUpdate(writer);
				return RedirectToAction("AllHeading","WriterPanel");
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

		public ActionResult MyHeading(string p)
		{

			p = (string)Session["WriterMail"];
			var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
			var values = headingManager.GetListByWriter(writerIdInfo);
			return View(values);
		}
		[HttpGet]
		public ActionResult NewHeading()
		{
			List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryId.ToString()
												  }).ToList();
			ViewBag.valueCategory = valueCategory;
			return View();
		}
		[HttpPost]
		public ActionResult NewHeading(Heading heading)
		{
			string writerMailInfo = (string)Session["WriterMail"];
			var writerIdInfo = context.Writers.Where(x => x.WriterMail == writerMailInfo).Select(y => y.WriterId).FirstOrDefault();

			heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			heading.WriterId = writerIdInfo;
			heading.HeadingStatus = true;
			headingManager.HeadingAdd(heading);
			return RedirectToAction("MyHeading");
		}

		[HttpGet]
		public ActionResult EditHeading(int id)
		{

			List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryId.ToString()
												  }).ToList();
			ViewBag.valueCategory = valueCategory;
			var headingValue = headingManager.GetById(id);
			return View(headingValue);
		}
		[HttpPost]
		public ActionResult EditHeading(Heading heading)
		{
			headingManager.HeadingUpdate(heading);
			return RedirectToAction("MyHeading");
		}
		public ActionResult DeleteHeading(int id)
		{
			var headingValue = headingManager.GetById(id);
			headingValue.HeadingStatus = false;
			headingManager.HeadingDelete(headingValue);
			return RedirectToAction("MyHeading");
		}

		public ActionResult AllHeading(int page=1)
		{
			var headings = headingManager.GetList().ToPagedList(page,8);
			return View(headings);
		}


	}
}