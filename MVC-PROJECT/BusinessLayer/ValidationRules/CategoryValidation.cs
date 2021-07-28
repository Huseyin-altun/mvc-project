using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Bos gecemezsınız");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Acıklamasını Bos gecemezsınız");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lutfen En az 3 karekter gırısı yapınız");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lutfen En Fazla 20 karekter gırısı yapınız");

        }
    }
}
