using System.Data.Common;
using System.Data;
using ECommerce.Common.Responses;
using Dapper;

namespace ECommerce.App.Helpers.Interfaces
{
    public interface IDapperRepository : IDisposable
    {
        DbConnection GetDbconnection();
        T GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<int> ExecuteAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        GenericResponse<T> InsertAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        GenericResponse<T> UpdateAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<GenericResponse<T>> GetFullAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        GenericResponse<T> GetOnlyAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        GenericResponse<T> GetOnlyAvatarAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
    }
}
