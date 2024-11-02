using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez!");
			RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez!");
			RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Boş Bırakılamaz!");
			RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan Boş Bırakılamaz!");
			RuleFor(x => x.WriterAbout).Must(x => x.Contains("a") || x.Contains("A")).WithMessage("Hakkımda Metninde A-a Harfi Geçmelidir.");
			RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Boş Bırakılamaz!");
			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız!");
			RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Girişi Yapınız!");
		}
	}
}
