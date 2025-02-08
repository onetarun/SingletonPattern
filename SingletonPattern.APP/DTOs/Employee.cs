using Microsoft.AspNetCore.Mvc;
using SingletonPattern.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SingletonPattern.APP.DTOs
{
    public class EmployeeDTO
    {
        public int? Row_Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        [Remote("IsEmailUnique", "Employee", AdditionalFields = "Row_Id")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid Mobile Number")]
        [Remote("IsMobileUnique", "Employee", AdditionalFields = "Row_Id")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "PAN Number is required")]
        [RegularExpression(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN Number")]
        [Remote("IsPanUnique", "Employee", AdditionalFields = "Row_Id")]
        public string PanNumber { get; set; }

        [Required(ErrorMessage = "Passport Number is required")]
        [Remote("IsPassportUnique", "Employee", AdditionalFields = "Row_Id")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [PastDate(ErrorMessage = "Date of Birth must be in the past")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [PastDate(ErrorMessage = "Date of Joinee must be in the past")]
        public DateTime? DateOfJoinee { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }

        [AllowedExtensions(new[] { ".jpg", ".png" })]
        //[MaxFileSize(200 * 1024)] // 200KB
        public IFormFile ProfileImage { get; set; }

        public string ExistingProfileImage { get; set; }

        [Required]
        public byte Gender { get; set; }

        public bool IsActive { get; set; }
        public List<CountryDTO> Countries { get; set; } = new();
    }

   

    // Custom Validation Attributes
    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            return (DateTime)value <= DateTime.Today;
        }
    }

    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult($"Only {string.Join(", ", _extensions)} files are allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class EmployeeList
    {
        public int row_Id { get; set; }
        public string employeeCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int countryId { get; set; }
        public Country country { get; set; }
        public int stateId { get; set; }
        public State state { get; set; }
        public int cityId { get; set; }
        public City city { get; set; }
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string panNumber { get; set; }
        public string passportNumber { get; set; }
        public string profileImage { get; set; }
        public int gender { get; set; }
        public bool isActive { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime dateOfJoinee { get; set; }
        public DateTime createdDate { get; set; }
        public object updatedDate { get; set; }
        public bool isDeleted { get; set; }
        public object deletedDate { get; set; }
    }

}
