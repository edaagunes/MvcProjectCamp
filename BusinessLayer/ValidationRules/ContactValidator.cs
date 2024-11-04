using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator:AbstractValidator<Contact>
	{
		public ContactValidator() {
			RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı Boş Geçilemez!");
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Bırakılamaz!");
			RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapınız!");
			RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen  En Az 3 Karakter Girişi Yapınız!");
			RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Girişi Yapınız!");
		}
	}
}
