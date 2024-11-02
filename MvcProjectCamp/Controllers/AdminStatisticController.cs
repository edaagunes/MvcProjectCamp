using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
	public class AdminStatisticController : Controller
	{
		Context context = new Context();
		public ActionResult Index()
		{
			ViewBag.totalCategory = context.Categories.Count();
			ViewBag.heading = context.Headings.Where(x => x.CategoryId == 9).Count();
			ViewBag.author = context.Writers.Where(x => x.WriterName.Contains("a") || x.WriterName.Contains("A") ||
				x.WriterSurname.Contains("a") || x.WriterSurname.Contains("A")).Count();
			ViewBag.maxCategory = context.Headings.GroupBy(h => h.Category.CategoryName).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
			ViewBag.status = context.Categories.Where(x => x.CategoryStatus == true).Count() - context.Categories.Where(x => x.CategoryStatus == false).Count();
			return View();
		}
	}
}