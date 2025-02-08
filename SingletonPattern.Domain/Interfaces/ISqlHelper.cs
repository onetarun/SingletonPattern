using Microsoft.Data.SqlClient;
using System.Data;

namespace SingletonPattern.Domain.Interfaces
{
    public interface ISqlHelper
    {
        DataTable ExecuteQuery(string storedProcedure, SqlParameter[] parameters);
        int ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters);
        
    }
}
