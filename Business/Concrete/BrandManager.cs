using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.Fluent;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal) 
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            IResult result = BusinessRules.Run(CheckIfBrandNameAlreadyExistsCorrect(brand.BrandName));
            if (result != null)
            {
                return result;
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }


        private IResult CheckIfBrandNameAlreadyExistsCorrect(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BrandExists);
            }
            return new SuccessResult();
        }
    }
}
