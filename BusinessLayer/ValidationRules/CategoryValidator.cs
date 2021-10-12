using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismini boş geçemessiniz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemessiniz!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori ismi en az 3 karakterli olmalı!");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori ismi en fazla 20 karakterli olmalı!");
        }
    }
}
