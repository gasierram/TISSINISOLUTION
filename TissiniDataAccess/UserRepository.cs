using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using TissiniModels;
using TissiniRepositories;

namespace TissiniDataAccess
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private object parameters;

        public UserRepository(string connectionString):base(connectionString)
        {


        }
        public User ValidateUser(string email, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@email", email);
            parameters.Add("@password", password);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<User>("dbo.ValidateUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
