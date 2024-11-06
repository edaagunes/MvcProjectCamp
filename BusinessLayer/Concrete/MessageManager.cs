using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MessageManager : IMessageService
	{
		IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public Message GetById(int id)
		{
			return _messageDal.Get(x => x.MessageId == id);
		}

		public List<Message> GetListInbox()
		{
			return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com" && x.IsDeleted==false);
		}

		public List<Message> GetListSendbox()
		{
			return _messageDal.List(x => x.SenderMail == "admin@gmail.com" && x.IsDeleted == false);
		}

		public void MessageAdd(Message message)
		{
			_messageDal.Insert(message);
		}

		public void MessageUpdate(Message message)
		{
			_messageDal.Update(message);
		}

		// Çoklu silme işlemi
		public void DeleteMessages(List<int> messageIds)
		{
			foreach (var id in messageIds)
			{
				var message = _messageDal.Get(x => x.MessageId == id);
				if (message != null)
				{
					message.IsDeleted = true; 
					_messageDal.Update(message);
				}
			}
		}
		public List<Message> GetTrashMessages()
		{
			return _messageDal.List(x => x.IsDeleted == true);
		}
	

		public List<Message> GetDraftMessages()
		{
			return _messageDal.List(x=>x.IsDraft == true);
		}

		public void ToggleReadStatus(int messageId)
		{
			var message = _messageDal.Get(x => x.MessageId == messageId);
			if (message != null)
			{
				message.IsRead = !message.IsRead;  // Mevcut durumu tersine çevirir
				_messageDal.Update(message);  // Güncellenmiş mesajı kaydeder
			}
		}
	}
}
