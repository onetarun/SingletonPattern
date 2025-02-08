using Microsoft.Data.SqlClient;
using SingletonPattern.Domain.Entities;
using SingletonPattern.Domain.Interfaces;
using System.Data;

namespace SingletonPattern.Infrastructure.Implementations
{
    public class StateRepository :  IStateRepository
    {
        private readonly ISqlHelper _sqlHelper;

        public StateRepository(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public IEnumerable<State> GetAll()
        {
            var dataTable = _sqlHelper.ExecuteQuery("sp_GetAllStates", null);
            return dataTable.AsEnumerable().Select(row => new State
            {
                Row_Id = row.Field<int>("Row_Id"),
                StateName = row.Field<string>("StateName"),
                CountryId = row.Field<int>("CountryId")
            });
        }

        public State GetById(int id)
        {
            var parameters = new[]
            {
                new SqlParameter("@StateId", id)
            };

            var dataTable = _sqlHelper.ExecuteQuery("sp_GetStateById", parameters);

            return dataTable.AsEnumerable().Select(row => new State
            {
                Row_Id = row.Field<int>("Row_Id"),
                StateName = row.Field<string>("StateName"),
                CountryId = row.Field<int>("CountryId")
            }).FirstOrDefault();
        }

        public int Add(State entity)
        {
            var parameters = new[]
            {
                new SqlParameter("@StateName", entity.StateName),
                new SqlParameter("@CountryId", entity.CountryId)
            };

            return _sqlHelper.ExecuteNonQuery("sp_AddState", parameters);
        }

        public int Update(State entity)
        {
            var parameters = new[]
            {
                new SqlParameter("@StateId", entity.Row_Id),
                new SqlParameter("@StateName", entity.StateName),
                new SqlParameter("@CountryId", entity.CountryId)
            };

            return _sqlHelper.ExecuteNonQuery("sp_UpdateState", parameters);
        }

        public int Delete(int id)
        {
            var parameters = new[]
            {
                new SqlParameter("@StateId", id)
            };

            return _sqlHelper.ExecuteNonQuery("sp_DeleteState", parameters);
        }

       
            public List<State> GetStatesByCountry(int countryId)
        {
            var parameters = new[]
            {
            new SqlParameter("@CountryId", countryId)
        };

            var dataTable = _sqlHelper.ExecuteQuery("GetStatesByCountry", parameters);

            return (from DataRow row in dataTable.Rows
                    select new State
                    {
                        Row_Id = Convert.ToInt32(row["Row_Id"]),
                        StateName = row["StateName"].ToString()
                    }).ToList();
        
    }
    
    }
}
