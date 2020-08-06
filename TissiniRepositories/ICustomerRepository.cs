using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TissiniModels;

namespace TissiniRepositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        IEnumerable<Customer> CustomerPagedList(int page, int rows);
    }
}
