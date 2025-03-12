using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string PlateTable { get; set; }
        public int ModelYear { get; set; }
        public string Color { get; set; }
        public int VehicleMileage { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}
