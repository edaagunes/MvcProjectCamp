using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class MessageValidator:AbstractValidator<Message>
	{
		public MessageValidator() {
			RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Maili Boş Geçilemez");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez");
			RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılamaz");
			RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapınız");
			RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen En Fazla 100 Karakter Girişi Yapınız");
		}
	}
}
