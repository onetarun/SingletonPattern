using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SingletonPattern.APP.DTOs;

namespace SingletonPattern.APP.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmployeesController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("MyAPIClient");
        }

        [HttpGet]
        public async Task<JsonResult> GetAllEmployees()
        {
            var employees = new List<EmployeeList>();
            var response = await _httpClient.GetAsync("api/Employees");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<EmployeeList>>(jsonString);
            }
            else
            {
                ViewBag.Error = "Unable to fetch employees.";
            }
            return Json(new { data = employees });

        }
        public async Task<IActionResult> Index()
        {
       
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            EmployeeDTO employee = new EmployeeDTO();
            employee.Countries =await  GetCountries();

            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Register(EmployeeList model, IFormFile ProfileImage)
        {
           
            using var memoryStream = new MemoryStream();
            await ProfileImage.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            using var formData = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(memoryStream.ToArray());
            formData.Add(fileContent, "profileImage", ProfileImage.FileName);

          
            // formData.Add(new StringContent(model.employeeCode), "EmployeeCode");
            formData.Add(new StringContent(model.firstName), "firstName");
                formData.Add(new StringContent(model.lastName ?? string.Empty), "lastName");
                formData.Add(new StringContent(model.countryId.ToString()), "countryId");
                formData.Add(new StringContent(model.stateId.ToString()), "stateId");
                formData.Add(new StringContent(model.cityId.ToString()), "cityId");
                formData.Add(new StringContent(model.emailAddress), "emailAddress");
                formData.Add(new StringContent(model.mobileNumber), "mobileNumber");
                formData.Add(new StringContent(model.panNumber), "panNumber");
                formData.Add(new StringContent(model.passportNumber), "PassportNumber");
                formData.Add(new StringContent(model.dateOfBirth.ToString()), "dateOfBirth");
                formData.Add(new StringContent(model.dateOfJoinee.ToString()), "dateOfJoinee");
                formData.Add(new StringContent(model.gender.ToString()), "gender");
                formData.Add(new StringContent(model.isActive.ToString()), "isActive");
                // Add file
               
                var response = await _httpClient.PostAsync("api/Employees", formData);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index"); // Redirect to success page
                }
                else
                {
                    // Log error and show error message
                    ModelState.AddModelError("", "Error adding employee.");
                }
            
            
            
            return BadRequest("Error in Code");
        }
        private async Task<List<CountryDTO>> GetCountries()
        {
            var countriesResponse = await _httpClient.GetAsync("api/Country");
            if (countriesResponse.IsSuccessStatusCode)
            {
                var countriesContent = await countriesResponse.Content.ReadAsStringAsync();
                var countries = JsonConvert.DeserializeObject<List<CountryDTO>>(countriesContent);
                return countries;
            }
            return null;
        }
        [HttpGet]
        public async Task<JsonResult> GetStatesByCountry(int countryId)
        {
            var statesResponse = await _httpClient.GetAsync($"api/state/GetStatesByCountry/{countryId}");
            var states = new List<StateDTO>();

            if (statesResponse.IsSuccessStatusCode)
            {
                var statesContent = await statesResponse.Content.ReadAsStringAsync();
                states = JsonConvert.DeserializeObject<List<StateDTO>>(statesContent);
               
            }

            return Json(states);
        }
        [HttpGet]
        public async Task<JsonResult> GetCitiesByState(int stateId)
        {
            var citiesResponse = await _httpClient.GetAsync($"api/city/GetCitiesByState/{stateId}");
            var cities = new List<CityDTO>();

            if (citiesResponse.IsSuccessStatusCode)
            {
                var citiesContent = await citiesResponse.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<CityDTO>>(citiesContent);
            }

            return Json(cities);
        }

    }
}
