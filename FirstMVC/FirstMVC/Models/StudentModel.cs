using System.ComponentModel.DataAnnotations;
using FirstMVC.Attributes;

namespace FirstMVC.Models
{
    public class StudentModel
    {
        [Required(ErrorMessage = "Full name is required.")]
        [Display(Name = "Full Name")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Full name must be between 10 and 500 characters.")]
        public string FullName { get; set; }

        [MinValue(18, ErrorMessage = "Age must be at least 18.")]
        [MaxValue(60, ErrorMessage = "Age cannot be greater than 60.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [GenderBasedAge]

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth { get; set; }
    }
}