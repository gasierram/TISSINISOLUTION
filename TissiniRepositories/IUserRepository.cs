using System;
using System.Collections.Generic;
using System.Text;
using TissiniModels;

namespace TissiniRepositories
{
    public interface IUserRepository:IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
