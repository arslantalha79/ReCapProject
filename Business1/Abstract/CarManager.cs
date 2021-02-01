using DataAccess1.Abstract;
using Entities1.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business1.Abstract
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal productDal)
        {
            _carDal = productDal;
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        List<CarManager> ICarService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
