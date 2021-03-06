﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand> {
                new Brand{BrandId=1,BrandName="BMW" },
                new Brand{BrandId=2,BrandName="Mercedes" },
                new Brand { BrandId = 3, BrandName = "Hyundai" },
                new Brand { BrandId = 4, BrandName = "Tesla" },
                new Brand { BrandId = 5, BrandName = "Nissan" },
                new Brand { BrandId = 6, BrandName = "Ford" }
          };
        }
        public void Add(Brand brand)
        {
            brand.BrandId = _brands.Last().BrandId + 1;
            _brands.Add(brand);
            Console.WriteLine("{0}markası markalar listesine eklendi.", brand.BrandName );        
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetByBrandId(int BrandId)
        {
           return _brands.Where(c => c.BrandId == BrandId).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
            Console.WriteLine("Güncellenen Marka Bilgileri\n ------");
            Console.WriteLine("{0}-{1}",brandToUpdate.BrandId,brandToUpdate.BrandName)   ;
        }
    }
}
