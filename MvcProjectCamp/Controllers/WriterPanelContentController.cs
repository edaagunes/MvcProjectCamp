using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
	public class WriterPanelContentController : Controller
	{
		ContentManager contentManager = new ContentManager(new EfContentDal());
		Context context = new Context();
		public ActionResult MyContent(string p)
		{
			
			p = (string)Session["WriterMail"];
			var writerIdInfo=context.Writers.Where(x=>x.WriterMail==p).Select(y=>y.WriterId).FirstOrDefault();
			var contentValues = contentManager.GetListByWriter(writerIdInfo);
			return View(contentValues);
		}
		[HttpGet]
		public ActionResult AddContent(int id)
		{
			ViewBag.headingId = id;
			return View();
		}
		[HttpPost]
		public ActionResult AddContent(Content content)
		{

			string mail = (string)Session["WriterMail"];
			var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
			content.WriterId = writerIdInfo;
			content.ContentStatus = true;
			content.ContentDate = DateTime.Now;

			contentManager.ContentAdd(content);
			return RedirectToAction("MyContent");
		}
	}
}