using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            var getAll = _brandDal.GetAll();
            return getAll;
        }

        public Brand GetBrand(int brandId)
        {
            var getBrand = _brandDal.Get(b => b.BrandId == brandId);
            return getBrand;
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
