using Microsoft.AspNetCore.Mvc;
using LabTask51726.Models;

namespace LabTask51726.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (string.IsNullOrWhiteSpace(model.ProductName) ||
                model.ProductName.Length < 2 || model.ProductName.Length > 50)
            {
                ModelState.AddModelError("ProductName", "Product Name must be between 2 and 50 characters");
            }

            if (model.Price < 1 || model.Price > 100000)
            {
                ModelState.AddModelError("Price", "Price value must be between 1 and 100000");
            }

            if (model.StockQuantity < 0 || model.StockQuantity > 1000)
            {
                ModelState.AddModelError("StockQuantity", "Stock Quantity must be between 0 and 1000");
            }

            return View(model);
        }
    }
}