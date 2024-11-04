﻿using BusinessLayer.Concrete;
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
		public ActionResult NewMessage()
		{
			return View();
		}

		[HttpPost]
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
	}
}