using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSlapper.DataAccess
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters);

        Task<int> SaveData<T>(string storedProcedure, T parameters);

        Task<IEnumerable<T>> QueryRawSQL<T, U>(string sql, U parameters);

        Task<int> ExecuteRawSQL<T>(string sql, T parameters);
    }
}
