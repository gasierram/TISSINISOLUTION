using System;
using System.Collections.Generic;
using System.Text;
using TissiniModels;

namespace TissiniRepositories
{
    public interface ISupplierRepository:IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPagedList(int page, int rows);

    }
}
