using Microsoft.Data.SqlClient;

namespace SingletonPattern.Domain.Interfaces
{
    public interface IDatabaseConnection
    {
        SqlConnection GetConnection();
    }
}
