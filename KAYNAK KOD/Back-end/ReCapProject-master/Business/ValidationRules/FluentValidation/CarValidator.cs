using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.BrandId).LessThan(5);
            RuleFor(p => p.Model).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.Model).Must(StartWithsB).WithMessage("Ürün B Harfi ile başlamıyor");
        }

        private bool StartWithsB(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}
