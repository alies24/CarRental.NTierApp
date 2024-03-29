﻿using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBusinessModelRepository<T>
        where T: class, new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> Get(int id);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
