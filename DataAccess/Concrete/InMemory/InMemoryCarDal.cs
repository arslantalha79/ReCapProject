using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car(){ CarId = 1, BrandId = 1, BrandName = "Renault", ModelName = "Megane", PlateTable = "34NY9567", Color = "Titanyum Gri", ModelYear = 2017, Price = 780000, VehicleMileage = 150654, Description = "Aile Arabası"},
                new Car(){ CarId = 2, BrandId = 1, BrandName = "Renault", ModelName = "Talisman", PlateTable = "07AGU047", Color = "Siyah", ModelYear = 2016, Price = 1275000, VehicleMileage = 125000, Description = "Temiz Değişensiz"},
                new Car(){ CarId = 3, BrandId = 2, BrandName = "Ford", ModelName = "Focus", PlateTable = "41TD5832", Color = "Mavi", ModelYear = 2022, Price = 1299000, VehicleMileage = 17000, Description = "Otomatik Titanyum Tertemiz"},
                new Car(){ CarId = 4, BrandId = 3, BrandName = "Peugeot", ModelName = "E-208", PlateTable = "34SPT043", Color = "Sarı", ModelYear = 2024, Price = 1385000, VehicleMileage = 9280, Description = "İncioğlu Spoticar'dan"},
                new Car(){ CarId = 5, BrandId = 4, BrandName = "Toyota", ModelName = "Corolla", PlateTable = "34EAH533", Color = "Beyaz", ModelYear = 2021, Price = 1124000, VehicleMileage = 59781, Description = "2021 Toyota Corolla"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _cars.Where(c => c.BrandId == id).ToList();   
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.BrandName = car.BrandName;
            carToUpdate.Price = car.Price;
            carToUpdate.VehicleMileage = car.VehicleMileage;
            carToUpdate.PlateTable = car.PlateTable;
            carToUpdate.Color = car.Color;
            carToUpdate.ModelName = car.ModelName;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
