using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TissiniModels;
using TissiniRepositories;

namespace TissiniDataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<Customer> CustomerPagedList(int page, int rows)
        {
            var parameteres = new DynamicParameters();
            parameteres.Add("@page", page);
            parameteres.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Customer>("dbo.CustomerPagedList", parameteres, commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
