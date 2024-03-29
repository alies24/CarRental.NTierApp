﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new ErrorResult();
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            var getAll = new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            return getAll;
        }

        public IDataResult<Rental> GetRental(int rentalId)
        {
            var getRental = new SuccessDataResult<Rental>(_rentalDal.Get(c => c.RentalId == rentalId));
            return getRental;
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
            var getRentalDetails = new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails());
            return getRentalDetails;
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
           
        }
    }
}
