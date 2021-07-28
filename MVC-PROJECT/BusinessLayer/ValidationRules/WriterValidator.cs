using EntitiyLayer.Concrete;
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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Bos gecemezsınız");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar SoyAdını Bos gecemezsınız");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Lutfen En az 3 karekter gırısı yapınız");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Lutfen En Fazla 50 karekter gırısı yapınız");

            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Hakkında  Alanını Bos gecemezsınız");



        }



    }
}
