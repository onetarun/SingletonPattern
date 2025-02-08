namespace SingletonPattern.API.DTOs

{
    public class EmployeeRegisterDTO
    {
       
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int countryId { get; set; }
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string panNumber { get; set; }
        public string passportNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoinee { get; set; }
        public int? StateId { get; set; }       
        public int? CityId { get; set; }
        public byte? Gender { get; set; }
        public bool? IsActive { get; set; }
        public IFormFile? ProfileImage { get; set; }

    }
}
