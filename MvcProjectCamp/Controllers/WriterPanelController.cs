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
    public class WriterPanelController : Controller
    {
		HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
		CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
		public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {         
            var values = headingManager.GetListByWriter();
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
			heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			heading.WriterId = 6;
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
	}
}