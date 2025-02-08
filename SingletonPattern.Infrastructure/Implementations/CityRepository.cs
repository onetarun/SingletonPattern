using Microsoft.Data.SqlClient;
using SingletonPattern.Domain.Entities;
using SingletonPattern.Domain.Interfaces;
using System.Data;

namespace SingletonPattern.Infrastructure.Implementations
{
    public class CityRepository :  ICityRepository
    {
        private readonly ISqlHelper _sqlHelper;

        public CityRepository(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public IEnumerable<City> GetAll()
        {
            var dataTable = _sqlHelper.ExecuteQuery("sp_GetAllCities", null);
            return dataTable.AsEnumerable().Select(row => new City
            {
                Row_Id = row.Field<int>("Row_Id"),
                CityName = row.Field<string>("CityName"),
                StateId = row.Field<int>("StateId")
            });
        }

        public City GetById(int id)
        {
            var parameters = new[]
            {
                new SqlParameter("@CityId", id)
            };

            var dataTable = _sqlHelper.ExecuteQuery("sp_GetCityById", parameters);

            return dataTable.AsEnumerable().Select(row => new City
            {
                Row_Id = row.Field<int>("Row_Id"),
                CityName = row.Field<string>("CityName"),
                StateId = row.Field<int>("StateId")
            }).FirstOrDefault();
        }

        public int Add(City entity)
        {
            var parameters = new[]
            {
                new SqlParameter("@CityName", entity.CityName),
                new SqlParameter("@StateId", entity.StateId)
            };

            return _sqlHelper.ExecuteNonQuery("sp_AddCity", parameters);
        }

        public int Update(City entity)
        {
            var parameters = new[]
            {
                new SqlParameter("@CityId", entity.Row_Id),
                new SqlParameter("@CityName", entity.CityName),
                new SqlParameter("@StateId", entity.StateId)
            };

            return _sqlHelper.ExecuteNonQuery("sp_UpdateCity", parameters);
        }

        public int Delete(int id)
        {
            var parameters = new[]
            {
                new SqlParameter("@CityId", id)
            };

            return _sqlHelper.ExecuteNonQuery("sp_DeleteCity", parameters);
        }

        public List<City> GetStatesByCountry(int stateId)
        {
            var parameters = new[]
             {
            new SqlParameter("@StateId", stateId)
        };

            var dataTable = _sqlHelper.ExecuteQuery("GetCitiesByState", parameters);

            return (from DataRow row in dataTable.Rows
                    select new City
                    {
                        Row_Id = Convert.ToInt32(row["Row_Id"]),
                        CityName = row["CityName"].ToString()
                    }).ToList();
        }
    }
}
