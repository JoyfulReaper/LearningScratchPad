using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DapperSlapper.DataAccess
{
    public class SQLServerDataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public SQLServerDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<int> ExecuteRawSQL<T>(string sql, T parameters)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
            var res = await connection.ExecuteAsync(sql, parameters);
            return res;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
            var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return rows;
        }

        public async Task<IEnumerable<T>> QueryRawSQL<T, U>(string sql, U parameters)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
            var res = await connection.QueryAsync<T>(sql, parameters);
            return res;
        }

        public async Task<int> SaveData<T>(string storedProcedure, T parameters)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString("Default"));
            return await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
