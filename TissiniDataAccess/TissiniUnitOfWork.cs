using System;
using System.Collections.Generic;
using System.Text;
using TissiniRepositories;
using TissiniunitOfWork;

namespace TissiniDataAccess
{
    public class TissiniUnitOfWork : IUnitOfWork
    {
        public TissiniUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
            Supplier = new SupplierRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }

        public IUserRepository User { get; private set; }

        public ISupplierRepository Supplier{ get; private set; }

    }
}
