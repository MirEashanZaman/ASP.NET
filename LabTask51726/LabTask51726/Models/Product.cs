using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LabTask51726.Models
{
    public class Product
    {
        [Required]
        [StringLength(50, MinimumLength =2)]
        public string ProductName { get; set; }
        [Required]
        [Range(1, 100000)]
        public double Price { get; set; }
        [Required]
        [Range(0, 1000)]
        public int StockQuantity { get; set; }
    }
}

