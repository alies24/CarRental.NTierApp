using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityReposBase<Car, RentalDbContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (RentalDbContext dbContext = new RentalDbContext())
            {
                var join = from c in dbContext.Cars
                           join b in dbContext.Brands on
                           c.BrandId equals b.BrandId
                           join ca in dbContext.Colors on c.ColorId equals ca.ColorId
                           select new CarDetailsDto
                           {
                               CarId = c.CarId,
                               BrandName = b.Name,
                               ColorName = ca.Name,
                               ModelYear = c.ModelYear,
                               Description = c.Description,
                               DailyPrice = c.DailyPrice

                           };
                return join.ToList();
            }
      
        }
    }
}
