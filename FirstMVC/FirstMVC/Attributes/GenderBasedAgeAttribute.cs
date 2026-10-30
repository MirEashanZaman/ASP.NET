using FirstMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstMVC.Attributes
{
    public class GenderBasedAgeAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if(value is DateTime dob) { 
            var age = (DateTime.Now - dob).TotalDays / 365;
                var modelData = (StudentModel)context.ObjectInstance;

                if (modelData.Gender== "Male" && age < 21)
                {
                    return new ValidationResult("Male students must be at least 21 years old.");
                }

                if (modelData.Gender == "Female" && age < 18)
                {
                    return new ValidationResult("Female students must be at least 18 years old.");
                }
            }
            else
            {
                return new ValidationResult("Invalid date of birth.");
            }
            return ValidationResult.Success;
        }
    }
}
