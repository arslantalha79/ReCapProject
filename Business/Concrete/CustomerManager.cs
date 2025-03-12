using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id));
        }


        public IDataResult<List<Customer>> GetByAge(int age)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.Age == age));
        }

        public IResult Add(Customer customer)
        {
            var result = BusinessRules.Run(CheckIfNationalIdentityExists(customer.NationalIdentity));

            if(result != null)
            {
                return result;
            }

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }


        public IResult CheckIfNationalIdentityExists(string nationalIdentity)
        {
            var result = _customerDal.GetAll(c=> c.NationalIdentity == nationalIdentity).Any();

            if (result)
            {
                return new ErrorResult(Messages.NationalIdentityRegistered);
            }
            return new SuccessResult();
        }
    }
}
