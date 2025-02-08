using Microsoft.Data.SqlClient;
using SingletonPattern.Domain.Entities;
using SingletonPattern.Domain.Interfaces;
using System.Data;

namespace SingletonPattern.Infrastructure.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlHelper _sqlHelper;

        public EmployeeRepository(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public void AddEmployee(Employee employee)
        {
           
            var parameters = new[]
            {
            new SqlParameter("@EmployeeCode", "002"),
            new SqlParameter("@FirstName", employee.FirstName),
            new SqlParameter("@LastName", employee.LastName),
            new SqlParameter("@CountryId", (object)employee.CountryId ?? DBNull.Value),
            new SqlParameter("@StateId", (object)employee.StateId ?? DBNull.Value),
            new SqlParameter("@CityId", (object)employee.CityId ?? DBNull.Value),
            new SqlParameter("@EmailAddress", employee.EmailAddress),
            new SqlParameter("@MobileNumber", employee.MobileNumber),
            new SqlParameter("@PanNumber", employee.PanNumber),
            new SqlParameter("@PassportNumber", employee.PassportNumber),
            new SqlParameter("@ProfileImage", (object)employee.ProfileImage ?? DBNull.Value),
            new SqlParameter("@Gender", employee.Gender),
            new SqlParameter("@IsActive", employee.IsActive),
            new SqlParameter("@DateOfBirth", employee.DateOfBirth),
            new SqlParameter("@DateOfJoinee", (object)employee.DateOfJoinee ?? DBNull.Value),
            new SqlParameter("@CreatedDate", employee.CreatedDate)
        };
            _sqlHelper.ExecuteQuery("AddEmployee", parameters);
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            try
            {
                var dt = _sqlHelper.ExecuteQuery("GetAllEmployees", null);

                foreach (DataRow row in dt.Rows)
                {
                    employees.Add(new Employee
                    {
                        Row_Id = Convert.ToInt32(row["EmployeeId"]),
                        EmployeeCode = row["EmployeeCode"].ToString(),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        CountryId = row["CountryId"] != DBNull.Value ? Convert.ToInt32(row["CountryId"]) : (int?)null,
                        StateId = row["StateId"] != DBNull.Value ? Convert.ToInt32(row["StateId"]) : (int?)null,
                        CityId = row["CityId"] != DBNull.Value ? Convert.ToInt32(row["CityId"]) : (int?)null,
                        EmailAddress = row["EmailAddress"].ToString(),
                        MobileNumber = row["MobileNumber"].ToString(),
                        PanNumber = row["PanNumber"].ToString(),
                        PassportNumber = row["PassportNumber"].ToString(),
                        ProfileImage = row["ProfileImage"].ToString(),
                        Gender = (byte)(row["Gender"] != DBNull.Value ? Convert.ToByte(row["Gender"]) : (byte?)null),
                        IsActive = Convert.ToBoolean(row["IsActive"]),
                        DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                        DateOfJoinee = row["DateOfJoinee"] != DBNull.Value ? Convert.ToDateTime(row["DateOfJoinee"]) : (DateTime?)null,
                        CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                        UpdatedDate = row["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDate"]) : (DateTime?)null,
                        IsDeleted = Convert.ToBoolean(row["IsDeleted"]),
                        DeletedDate = row["DeletedDate"] != DBNull.Value ? Convert.ToDateTime(row["DeletedDate"]) : (DateTime?)null,
                        Country = row["CountryName"] != DBNull.Value
                    ? new Country
                    {
                        Row_Id = Convert.ToInt32(row["Row_Id"]),
                        CountryName = row["CountryName"].ToString()
                    }
                    : null,
                        State = row["StateName"] != DBNull.Value
                    ? new State
                    {
                        Row_Id = Convert.ToInt32(row["Row_Id"]),
                        StateName = row["StateName"].ToString()
                    }
                    : null,
                        City = row["CityName"] != DBNull.Value
                    ? new City
                    {
                        Row_Id = Convert.ToInt32(row["Row_Id"]),
                        CityName = row["CityName"].ToString()
                    }
                    : null






                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching employees", ex);
            }

            return employees;
        }
    }
}
