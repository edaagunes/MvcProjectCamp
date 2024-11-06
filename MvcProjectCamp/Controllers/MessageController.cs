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
	public class MessageController : Controller
	{
		MessageManager manager = new MessageManager(new EfMessageDal());
		MessageValidator validationRules = new MessageValidator();
		[Authorize]
		public ActionResult Inbox()
		{
			var messageList = manager.GetListInbox();
			return View(messageList);
		}

		public ActionResult Sendbox()
		{
			var messageList = manager.GetListSendbox();
			return View(messageList);
		}
		public ActionResult GetInboxMessageDetails(int id)
		{
			var values = manager.GetById(id);
			return View(values);
		}
		public ActionResult GetSendboxMessageDetails(int id)
		{
			var values = manager.GetById(id);
			return View(values);
		}

		[HttpGet]
		[ValidateInput(false)]
		public ActionResult NewMessage()
		{
			return View();
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult NewMessage(Message message)
		{
			ValidationResult results = validationRules.Validate(message);
			if (results.IsValid)
			{
				message.MessageDate=DateTime.Parse(DateTime.Now.ToShortDateString());
				manager.MessageAdd(message);
				return RedirectToAction("Sendbox");
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


		[HttpPost]
		public ActionResult DeleteMessages(List<int> messageIds,string redirectView)
		{
			manager.DeleteMessages(messageIds);
			// Silme işleminden sonra hangi sayfaya dönüleceğine karar ver
			if (redirectView == "Inbox")
			{
				return RedirectToAction("Inbox");
			}
			else if (redirectView == "Sendbox")
			{
				return RedirectToAction("Sendbox");
			}
			else
			{
				return RedirectToAction("TrashMessages"); // Varsayılan olarak Çöp Kutusuna git
			}
		}

		public ActionResult TrashMessages()
		{
			var values = manager.GetTrashMessages().ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult DraftList()
		{
			var draftMessages=manager.GetDraftMessages();
			return View(draftMessages);
		}
		[ValidateInput(false)]
		public ActionResult DraftDetail(int id)
		{
			var values=manager.GetById(id);
			return View(values);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult SaveDraft(Message message)
		{
			message.MessageDate = DateTime.Now;
			message.IsDraft = true;
			manager.MessageAdd(message);
			return RedirectToAction("DraftList");
			//return Json(new { success = true });
		}
	}
}