using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
		HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
		ContentManager contentManager = new ContentManager(new EfContentDal());

		public ActionResult Index()
		{
			return View();
		}
		public JsonResult HeadingCountByCategory()
		{
			var data = headingManager.GetHeadingCountByCategory();
			return Json(data, JsonRequestBehavior.AllowGet);  // Veriyi JSON olarak döner
		}
		public JsonResult ContentCountByHeading()
		{
			var headingContentCounts = contentManager.GetContentCountByHeading();
			return Json(headingContentCounts, JsonRequestBehavior.AllowGet);
		}
	}
}