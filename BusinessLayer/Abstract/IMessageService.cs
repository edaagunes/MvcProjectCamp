using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IMessageService
	{
		List<Message> GetListInbox(string p);
		List<Message> GetListSendbox(string p);
		void MessageAdd(Message message);
		void MessageUpdate(Message message);
		Message GetById(int id);
		void DeleteMessages(List<int> messageIds); // Çoklu silme metodu
		List<Message> GetTrashMessages(string p);
		List<Message> GetDraftMessages(string p);
		void ToggleReadStatus(int messageId);


	}
}
