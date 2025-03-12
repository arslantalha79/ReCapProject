using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.Fluent
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator() 
        {
            RuleFor(car => car.ModelYear).GreaterThanOrEqualTo(1950);
            RuleFor(car => car.BrandName).NotEmpty();
            RuleFor(car => car.Price).GreaterThan(0);
            RuleFor(car => car.BrandName).MinimumLength(2);
            RuleFor(car => car.PlateTable).NotEmpty();
        }
    }
}
