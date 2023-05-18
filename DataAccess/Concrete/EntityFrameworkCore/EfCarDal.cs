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
        public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentalDbContext dbContext = new RentalDbContext())
            {
                var join = from c in filter == null ? dbContext.Cars : dbContext.Cars.Where(filter)
                           join b in dbContext.Brands on
                           c.BrandId equals b.BrandId
                           join ca in dbContext.Colors on c.ColorId equals ca.ColorId
                           select new CarDetailsDto
                           {
                               CarId = c.CarId,
                               BrandId = b.BrandId,
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

