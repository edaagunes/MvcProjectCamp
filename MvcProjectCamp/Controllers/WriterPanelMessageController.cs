using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
		MessageManager manager = new MessageManager(new EfMessageDal());
		MessageValidator validationRules = new MessageValidator();

		public ActionResult Inbox()
		{
			string p = (string)Session["WriterMail"];
			var messageList = manager.GetListInbox(p);
			ViewBag.unreadMessage = messageList.Where(x => x.IsRead == false).Count();
			return View(messageList);
		}

		public PartialViewResult MessageMenuPartial()
		{
			string p = (string)Session["WriterMail"];
			ViewBag.inboxMessageCount = manager.GetListInbox(p).Count;
			ViewBag.sendMessageCount = manager.GetListSendbox(p).Count;
			ViewBag.trashMessages = manager.GetTrashMessages(p).Count();
			ViewBag.draftMessageCount = manager.GetDraftMessages(p).Count();
			return PartialView();
		}

		public ActionResult Sendbox()
		{
			string p = (string)Session["WriterMail"];
			var messageList = manager.GetListSendbox(p);
			return View(messageList);
		}

		public ActionResult GetInboxMessageDetails(int id)
		{
			// Mesajı veritabanından al
			var values = manager.GetById(id);

			// Eğer mesaj okunmamışsa, okundu olarak işaretle
			if (values != null && !values.IsRead)
			{
				values.IsRead = true;  // Mesaj okundu olarak işaretlendi
				manager.MessageUpdate(values);  // Güncellenmiş mesajı kaydet
			}

			return View(values);  // Mesajın detaylarını görüntüle
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
			string p = (string)Session["WriterMail"];
			ValidationResult results = validationRules.Validate(message);
			if (results.IsValid)
			{
				message.SenderMail = p;
				message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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
		public ActionResult DeleteMessages(List<int> messageIds, string redirectView)
		{
			string p = (string)Session["WriterMail"];

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
			string p = (string)Session["WriterMail"];
			var values = manager.GetTrashMessages(p).ToList();
			return View(values);
		}

		[HttpGet]
		public ActionResult DraftList()
		{
			string p = (string)Session["WriterMail"];
			var draftMessages = manager.GetDraftMessages(p);
			return View(draftMessages);
		}
		[ValidateInput(false)]
		public ActionResult DraftDetail(int id)
		{
			var values = manager.GetById(id);
			return View(values);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult SaveDraft(Message message)
		{
			string p = (string)Session["WriterMail"];
			message.SenderMail = p;
			message.MessageDate = DateTime.Now;
			message.IsDraft = true;
			manager.MessageAdd(message);
			return RedirectToAction("DraftList");
			//return Json(new { success = true });
		}

		public ActionResult ToggleReadStatus(int id)
		{
			manager.ToggleReadStatus(id);  // Mesajın okundu/okunmadı durumunu değiştir

			return RedirectToAction("Inbox");  // Inbox sayfasına yönlendir
		}
	}
}