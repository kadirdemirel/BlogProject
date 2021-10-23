using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("En az 3 karakter girilmeli");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("En fazla 150 karakter girilmeli");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Boş geçilemez");
            RuleFor(x => x.BlogContent).MinimumLength(3).WithMessage("En az 3 karakter girilmeli");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Boş geçilemez");



        }
    }
}
