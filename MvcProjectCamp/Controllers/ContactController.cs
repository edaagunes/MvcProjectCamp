﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
	public class ContactController : Controller
	{
		ContactManager manager = new ContactManager(new EfContactDal());
		MessageManager messageManager = new MessageManager(new EfMessageDal());
		ContactValidator validationRules = new ContactValidator();
		public ActionResult Index()
		{
			var contactValues = manager.GetList();
			return View(contactValues);
		}

		public PartialViewResult MessageMenuPartial(string p)
		{
			ViewBag.messageCount = manager.GetList().Count;
			ViewBag.inboxMessageCount = messageManager.GetListInbox(p).Count;
			ViewBag.sendMessageCount = messageManager.GetListSendbox(p).Count;
			ViewBag.trashMessages = messageManager.GetTrashMessages(p).Count();
			ViewBag.draftMessageCount = messageManager.GetDraftMessages(p).Count();

			return PartialView();
		}

		public ActionResult GetContactDetails(int id)
		{
			var contactValues= manager.GetById(id);
			return View(contactValues);
		}
	}
}