using DataAccess1.Abstract;
using Entities1.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess1.Concrete.InMemory
{
    public class InMemoryCarDal: ICarDal
    {
        List<Car> cars;
        private List<Car> _cars;

        public InMemoryCarDal()
        {

            _cars = new List<Car>
            {
                new Car{CarId = 1, BrandId = 1, BrandName = "Renault Megane", ColorId = 23, ModelYear = 2008, DailyPrice = 120,Description = "Yakıt Cimrisi"},
                new Car{CarId = 2, BrandId = 1, BrandName = "Mercedes Vito", ColorId = 14, ModelYear = 2005, DailyPrice = 160,Description = "Geniş Araç" },
                new Car{CarId = 3, BrandId = 2, BrandName = "Peugeot 3008", ColorId = 9, ModelYear = 2017, DailyPrice = 150,Description = "SUV"},
                new Car{CarId = 4, BrandId = 3, BrandName = "Toyota Corolla ", ColorId = 1, ModelYear = 2020, DailyPrice = 200,Description = "Elektrikli"},
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            foreach (var c in _cars)
            {
                if (car.CarId == c.CarId)
                {
                    carToDelete = c;
                }

            }

            carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);


        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.BrandName = car.BrandName;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }
    }
}
