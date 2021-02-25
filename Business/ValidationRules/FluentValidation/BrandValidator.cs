﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {


        public BrandValidator()
        {
            // b brand'e karşılık gelir.

            RuleFor(b => b.BrandName.Length).NotEmpty();

            RuleFor(b => b.BrandName.Length).GreaterThanOrEqualTo(2);
        }

    }
}
