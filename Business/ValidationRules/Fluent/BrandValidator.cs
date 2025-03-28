﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.Fluent
{
    public class BrandValidator : AbstractValidator<Brand>
    {

        public BrandValidator() 
        {
            RuleFor(brand => brand.BrandName).NotEmpty();
            RuleFor(brand => brand.BrandName).MinimumLength(2);
        }
    }
}
