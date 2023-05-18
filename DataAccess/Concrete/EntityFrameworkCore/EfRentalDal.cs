using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfRentalDal : EfEntityReposBase<Rental, RentalDbContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (RentalDbContext dbContext = new RentalDbContext())
            {
                var join = from c in dbContext.Cars
                           join
                           b in dbContext.Brands on c.BrandId equals b.BrandId
                           join cl in dbContext.Colors on c.ColorId equals cl.ColorId
                           from cu in dbContext.Customers
                           join u in dbContext.Users on
                           cu.UserId equals u.UserId
                           select new RentalDetailsDto
                           {
                               BrandName = b.Name,
                               ColorName = cl.Name,
                               FirstName = u.FirstName,
                               LastName = u.LastName                 

                           };
                return join.ToList();

            }

        }
    }
}
