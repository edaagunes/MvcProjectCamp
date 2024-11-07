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
    public class WriterPanelMessageController : Controller
    {
		MessageManager manager = new MessageManager(new EfMessageDal());
		MessageValidator validationRules = new MessageValidator();

		public ActionResult Inbox()
		{
			var messageList = manager.GetListInbox();
			ViewBag.unreadMessage = messageList.Where(x => x.IsRead == false).Count();
			return View(messageList);
		}

		public PartialViewResult MessageMenuPartial()
		{
			return PartialView();
		}

		public ActionResult Sendbox()
		{
			var messageList = manager.GetListSendbox();
			return View(messageList);
		}
	}
}