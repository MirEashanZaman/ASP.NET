using System.ComponentModel.DataAnnotations;
using FirstMVC.Attributes;

namespace FirstMVC.Models
{
    public class Student
    {
        [Required]
        public string Name { get; set; }

        [MaxValue(40)]
        public int Age { get; set; }

        [MaxValue(100, ErrorMessage = "Marks cannot be more than 100.")]
        public int Marks { get; set; }
    }
}