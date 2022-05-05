﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<Customer> GetCustomer(int customerId)
        {
            var getCustomer = new SuccessDataResult<Customer>(_customerDal.Get(c=>c.UserId == customerId));
            return getCustomer;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var getAll = new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            return getAll;
        }

        public IDataResult<List<CustomerDetailsDto>> GetCustomerDetails()
        {
            var getCustomerDetails = new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.GetCustomerDetails());
            return getCustomerDetails;
            
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
