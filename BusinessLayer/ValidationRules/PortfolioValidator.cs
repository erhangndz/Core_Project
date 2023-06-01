using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje ismi boş bırakılamaz.");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Görsel alanı boş bırakılamaz.");
            RuleFor(x => x.ImageURL2).NotEmpty().WithMessage("Görsel 2 alanı boş bırakılamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş bırakılamaz.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer alanı boş bırakılamaz.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje ismi en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Proje ismi en fazla 40 karakterden oluşmalıdır.");
        }
    }
}
