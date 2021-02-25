using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            //c Car'a karşılık gelir.
            RuleFor(c => c.DailyPrice).GreaterThan(0);
        }
    }
}
