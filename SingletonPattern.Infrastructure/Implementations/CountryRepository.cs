using Microsoft.Data.SqlClient;
using SingletonPattern.Domain.Entities;
using SingletonPattern.Domain.Interfaces;
using System.Data;

namespace SingletonPattern.Infrastructure.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ISqlHelper _sqlHelper;

        public CountryRepository(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public IEnumerable<Country> GetAll()
        {
            var dataTable = _sqlHelper.ExecuteQuery("sp_GetAllCountries", null);
            return dataTable.AsEnumerable().Select(row => new Country
            {
                Row_Id = row.Field<int>("Row_Id"),
                CountryName = row.Field<string>("CountryName")
            });
        }

        public Country GetById(int id)
        {
            var parameters = new[] { new SqlParameter("@CountryId", id) };
            var dataTable = _sqlHelper.ExecuteQuery("sp_GetCountryById", parameters);
            return dataTable.AsEnumerable().Select(row => new Country
            {
                Row_Id = row.Field<int>("Row_Id"),
                CountryName = row.Field<string>("CountryName")
            }).FirstOrDefault();
        }

        public int Add(Country entity)
        {
            var parameters = new[] { new SqlParameter("@CountryName", entity.CountryName) };
            return _sqlHelper.ExecuteNonQuery("sp_AddCountry", parameters);
        }

        public int Update(Country entity)
        {
            var parameters = new[]
            {
                new SqlParameter("@CountryId", entity.Row_Id),
                new SqlParameter("@CountryName", entity.CountryName)
            };
            return _sqlHelper.ExecuteNonQuery("sp_UpdateCountry", parameters);
        }

        public int Delete(int id)
        {
            var parameters = new[] { new SqlParameter("@CountryId", id) };
            return _sqlHelper.ExecuteNonQuery("sp_DeleteCountry", parameters);
        }
    }
}
