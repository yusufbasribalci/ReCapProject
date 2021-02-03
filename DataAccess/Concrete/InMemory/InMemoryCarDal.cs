using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal 
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=45000,ModelYear="1970",Description="Temiz kullanılmış"},
                new Car{CarId=2,BrandId=1,ColorId=4,DailyPrice=65000,ModelYear="2013",Description="15.000 km de"},
                new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=67890,ModelYear="2018",Description="Öğretmenden satılık"},
                new Car{CarId=4,BrandId=2,ColorId=3,DailyPrice=54678,ModelYear="2006",Description="Aile arabası"},
                new Car{CarId=5,BrandId=4,ColorId=1,DailyPrice=234000,ModelYear="2017",Description="Temiz kullanılmış",},
                new Car{CarId=6,BrandId=4,ColorId=3,DailyPrice=123890,ModelYear="2009",Description="Temiz kullanılmış"},
                new Car{CarId=7,BrandId=2,ColorId=2,DailyPrice=345750,ModelYear="2020",Description="Temiz kullanılmış"}
        };
    }   
            public void Add(Car car)
        {
            car.CarId = _cars.Last().CarId + 1;
            
        //{0} ve {1}  ile car.ModelYear ve car.DailyPrice veri çekilebiliyor.
        // yada Console.WriteLine( car.ModelYear + " model araba "+ car.DailyPrice +" Tl fiyatı ile eklendi");

       
            _cars.Add(car);
            Console.WriteLine("{0} model araba {1} Tl fiyatı ile eklendi", car.ModelYear, car.DailyPrice);

        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
            // carToDelete.ModelYear da yazılabilir car.ModelYear fakat takma ad olduğu için carToDelete hangi işlemden geldiğini daha kolay anlaşılıyor.
            Console.WriteLine("{0} model araba {1} TL fiyatı ile silindi.", carToDelete.ModelYear, carToDelete.DailyPrice);
        }
        public List<Car> GetAll()
        {
              return _cars;
        }

        public List<Car> GetByBrandId(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<Car> GetByCarId(int CarId)
        {
            return _cars.Where(c => c.CarId == CarId).ToList();
        }

        public List<Car> GetByModelYear(string ModelYear)
        {
            return _cars.Where(c => c.ModelYear == ModelYear).ToList();
        }

        public List<Car> GetByPrice(int DailyPrice)
        {
            return _cars.Where(c => c.DailyPrice == DailyPrice).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            // \n enter işlemine denk geliyor bir alt satıra gecmek için
            Console.WriteLine("Güncellene araç bilgileri\n---------------- ");
            Console.WriteLine("{0}. {1} model {2} TL-->Açıklaması:{3}\n", carToUpdate.CarId, carToUpdate.ModelYear, carToUpdate.DailyPrice, carToUpdate.Description);
        }


    }
}
