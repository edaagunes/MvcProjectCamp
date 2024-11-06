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
		List<Message> GetListInbox();
		List<Message> GetListSendbox();
		void MessageAdd(Message message);
		Message GetById(int id);
		void DeleteMessages(List<int> messageIds); // Çoklu silme metodu
		List<Message> GetTrashMessages();
		List<Message> GetDraftMessages();
		
	}
}
