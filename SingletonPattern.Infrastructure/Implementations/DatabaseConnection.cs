using Microsoft.Data.SqlClient;
using SingletonPattern.Domain.Interfaces;

namespace SingletonPattern.Infrastructure.Implementations
{

    public class DatabaseConnection : IDatabaseConnection
        {
            private static DatabaseConnection _instance;
            private static readonly object LockObject = new object();
            private readonly string _connectionString;

            private DatabaseConnection(string connectionString)
            {
                _connectionString = connectionString;
            }

            public static DatabaseConnection GetInstance(string connectionString)
            {
                lock (LockObject)
                {
                    if (_instance == null)
                        _instance = new DatabaseConnection(connectionString);
                    return _instance;
                }
            }

            public SqlConnection GetConnection()
            {
                return new SqlConnection(_connectionString);
            }
        }
    
}
