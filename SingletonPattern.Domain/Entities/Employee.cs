namespace SingletonPattern.Domain.Entities
{
    public class Employee
    {
        public int Row_Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string PanNumber { get; set; }
        public string PassportNumber { get; set; }
        public string ProfileImage { get; set; }
        public byte Gender { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfJoinee { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
       // public IFormFile ProfileImageUrl { get; set; }

    }

}
