using Microsoft.AspNetCore.Mvc;
using SingletonPattern.API.DTOs;
using SingletonPattern.API.Filters;
using SingletonPattern.Domain.Entities;
using SingletonPattern.Domain.Interfaces;

namespace SingletonPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUtilityService _utilityService;
        private string containerName = "employee";

        public EmployeesController(IEmployeeRepository employeeRepository, IUtilityService utilityService)
        {
            _employeeRepository = employeeRepository;
            _utilityService = utilityService;
        }
        [HttpPost]
        [ClientAuthentication]
        public async Task<IActionResult> AddEmployee([FromForm]EmployeeRegisterDTO employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest("Employee object is null.");

                if (!ModelState.IsValid)
                    return BadRequest("Invalid model object.");

                var model =  new Employee
                {
                    FirstName = employee.firstName,
                    LastName = employee.lastName,
                    EmailAddress = employee.emailAddress,
                    MobileNumber = employee.mobileNumber,
                    PanNumber = employee.panNumber,
                    PassportNumber = employee.passportNumber,
                    DateOfBirth = employee.DateOfBirth.Value,
                    DateOfJoinee = employee.DateOfJoinee.Value,
                    CountryId = employee.countryId,
                    StateId = employee.StateId,
                    CityId = employee.CityId,
                    IsActive = employee.IsActive.Value,
                    Gender = employee.Gender.Value              



                };

                if(employee.ProfileImage!=null)
                {
                    model.ProfileImage = await _utilityService.SaveImage(containerName,employee.ProfileImage);
                }

                _employeeRepository.AddEmployee(model);
                //return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Row_Id }, employee);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
