using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemessiniz!");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş geçemessiniz!");
            RuleFor(x => x.WriterAbout).Matches(@"a").WithMessage("Hakkınızda Kızmında mutlaka 'a' harfi bulunmalıdır.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adını en az 2 karakterli olmalı!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adını en fazla 20 karakterli olmalı!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmı boş geçilemez!");

        }
    }
}
