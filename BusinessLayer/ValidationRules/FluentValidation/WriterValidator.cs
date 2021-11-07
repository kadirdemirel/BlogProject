using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("İsim en az 2 karakter olmalıdır");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("İsim en fazla 50 karakter olmalıdır");
            //RuleFor(x => x).Custom((x, context) =>
            //{
            //    if (x.Password != x.RepeatPassword)
            //    {
            //        context.AddFailure(nameof(x.Password), "Şifreler aynı değil");
            //    }
            //});


            RuleFor(x => x.Password).Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])").WithMessage("En az 1 küçük, 1 büyük harf ve 1 sayı bulunmalıdır");


        }
    }
}
