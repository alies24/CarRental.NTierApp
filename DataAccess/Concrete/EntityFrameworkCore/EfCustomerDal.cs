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
    public class EfCustomerDal:EfEntityReposBase<Customer, RentalDbContext>, ICustomerDal
    {   
        public List<CustomerDetailsDto> GetCustomerDetails()
        {
           
            using(RentalDbContext dbContext = new RentalDbContext())
            {
                var join = from c in dbContext.Customers
                           join u in dbContext.Users on c.UserId equals 
                           u.UserId
                           select new CustomerDetailsDto
                           {
                               Id = c.Id,
                               CompanyName = c.CompanyName,
                               Email = u.Email,
                               FirstName = u.FirstName,
                               LastName = u.LastName

                           };
                return join.ToList();

            }
          
        }
    }
}
