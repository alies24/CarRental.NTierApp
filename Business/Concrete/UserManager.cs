﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            var getAll = new SuccessDataResult<List<User>>(_userDal.GetAll());
            return getAll;
        }

        public IDataResult<User> GetUser(int userId)
        {
            var getUser = new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
            return getUser;
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
           return new SuccessResult();
        }

    }
}
