using FluentValidation;
using SingletonPattern.Domain.Entities;

namespace SingletonPattern.Infrastructure.Implementations
{
    public class EmployeeValidator :  AbstractValidator<Employee>
    {
        public EmployeeValidator() { 
        RuleFor(x=>x.EmailAddress).EmailAddress().WithMessage("Invalid Email Address");
        }
       //public EmployeeValidator() {
       //     RuleFor(x => x.PanNumber)
       //       .Cascade(CascadeMode.Stop)
       //       .NotEmpty().WithMessage("PAN Number is required")
       //       .Must(pan => pan != null && pan.Length == 10)
       //           .WithMessage("PAN Number must be 10 characters long")
       //       .Must(pan => pan != null && pan.Substring(0, 5).All(char.IsLetter))
       //           .WithMessage("First 5 characters of PAN Number must be letters")
       //       .Must(pan => pan != null && pan.Substring(5, 4).All(char.IsDigit))
       //           .WithMessage("Characters 6-9 of PAN Number must be numbers")
       //       .Must(pan => pan != null && char.IsLetter(pan[9]))
       //           .WithMessage("Last character of PAN Number must be a letter")
       //       .MustAsync(async (pan, cancellation) =>
       //       {
       //           if (string.IsNullOrEmpty(pan)) return true;
       //           return !await _context.UserDocuments.AnyAsync(x => x.PANNumber == pan.ToUpper());
       //       }).WithMessage("This PAN Number already exists");

        }

    
}
