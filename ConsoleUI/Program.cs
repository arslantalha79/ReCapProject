using System;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace MyWebsiteTrial
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            if (result.IsSuccess == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "/" + car.BrandName);
                }
              
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}