using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
     public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {

            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("Lutfen En az 3 karekter gırısı yapınız");
            RuleFor(x => x.HeadingName).MaximumLength(20).WithMessage("Lutfen En Fazla 20 karekter gırısı yapınız");

        }
    }
}
