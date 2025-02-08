using Microsoft.Data.SqlClient;
using SingletonPattern.Domain.Interfaces;
using System.Data;

namespace SingletonPattern.Infrastructure.Implementations
{
    public class SqlHelper : ISqlHelper
    {
        private readonly IDatabaseConnection _databaseConnection;

        public SqlHelper(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public DataTable ExecuteQuery(string storedProcedure, SqlParameter[] parameters)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    var dataTable = new DataTable();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
        }

        public int ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters)
        {
            using (var connection = _databaseConnection.GetConnection())
            {
                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

       
    }
}
