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
	public class HeadingController : Controller
	{
		HeadingManager manager = new HeadingManager(new EfHeadingDal());
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
		WriterManager writerManager = new WriterManager(new EfWriterDal());
		public ActionResult Index()
		{
			var headingValues = manager.GetList();
			return View(headingValues);
		}

		public ActionResult HeadingReport()
		{
			var headingValues = manager.GetList();
			return View(headingValues);
		}

		[HttpGet]
		public ActionResult AddHeading()
		{
			List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryId.ToString()
												  }).ToList();

			List<SelectListItem> valueWriter = (from x in writerManager.GetList()
												  select new SelectListItem
												  {
													  Text = x.WriterName+" "+x.WriterSurname,
													  Value = x.WriterId.ToString()
												  }).ToList();
			ViewBag.valueCategory=valueCategory;
			ViewBag.valueWriter=valueWriter;
			return View();
		}
		[HttpPost]
		public ActionResult AddHeading(Heading heading)
		{
			heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			manager.HeadingAdd(heading);
			return RedirectToAction("Index");
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
			var headingValue =manager.GetById(id);
			return View(headingValue);
		}
		[HttpPost]
		public ActionResult EditHeading(Heading heading)
		{
			manager.HeadingUpdate(heading);
			return RedirectToAction("Index");
		}

		public ActionResult DeleteHeading(int id)
		{
			var headingValue=manager.GetById(id);
			if (headingValue.HeadingStatus == true)
			{
				headingValue.HeadingStatus = false;
				manager.HeadingDelete(headingValue);
			}
			else
			{
				headingValue.HeadingStatus = true;
				manager.HeadingDelete(headingValue);
			}
			return RedirectToAction("Index");
		}
	}
}