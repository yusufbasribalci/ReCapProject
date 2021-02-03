using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color> {
                new Color{ColorId=1,ColorName="Red"},
                new Color{ColorId=2,ColorName="Blue"},
        };
        }
        public void Add(Color color)
        {
            color.ColorId = _colors.Last().ColorId + 1;
            _colors.Add(color);
            Console.WriteLine("{0} renkleri listesine eklendi.", color.ColorName);
        }

        public void Delete(Color color)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            _colors.Remove(colorToDelete);
            Console.WriteLine("{0} rengi listeden silindi",color.ColorName);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetByColorId(int ColorId)
        {
            return _colors.OrderByDescending(c => c.ColorId).ToList();
        }

        public void Update(Color color)
        {
            Color carToUpdate = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            carToUpdate.ColorName = color.ColorName;
            carToUpdate.ColorId = color.ColorId;
            
            Console.WriteLine("Güncellenen renk bilgileri\n---------------------------");
            Console.WriteLine("{0} renk bilgisi listeye eklendi\n", carToUpdate.ColorName);

        }
    }
}
