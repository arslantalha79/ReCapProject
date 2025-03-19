using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.Fluent;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfPlateTableExists(car.PlateTable));
            if (result !=null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = BusinessRules.Run(CheckIfMaintenanceTime());
            if (result != null)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.SuccessfulCarListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
            //Select * from Cars where brandId = 5
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsDetailsDtoListed);
        }


        private IResult CheckIfPlateTableExists(string plateTable)
        {
            var result = _carDal.GetAll(car => car.PlateTable == plateTable).Any();

            if (result)
            {
                return new ErrorResult(Messages.PlateTableAlreadyExists);
            }
            return new SuccessResult();
   
        }

        private IResult CheckIfMaintenanceTime()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            return new SuccessResult();
        }

    }
}
