using System;
using System.Collections.Generic;
using System.Text;
using TissiniRepositories;

namespace TissiniunitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }

    }
}
