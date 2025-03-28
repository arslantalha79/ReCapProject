﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<List<User>> GetUserById(int userId);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
