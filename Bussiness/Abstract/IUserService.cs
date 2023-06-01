using System;
using Core.Entities.Concrete;

namespace Bussiness.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);

        void Add(User user);

        User GetByMail(string email);
    }
}

