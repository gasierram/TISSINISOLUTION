using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TissiniModels;
using TissiniRepositories;

namespace TissiniDataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Supplier> SupplierPagedList(int page, int rows)
        {
            var parameteres = new DynamicParameters();
            parameteres.Add("@page", page);
            parameteres.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Supplier>("dbo.SupplierPagedList", parameteres, commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
