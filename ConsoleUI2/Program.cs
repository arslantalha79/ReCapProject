using Business1.Abstract;
using DataAccess1.Concrete.InMemory;
using System;

namespace ConsoleUI2
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandName);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
