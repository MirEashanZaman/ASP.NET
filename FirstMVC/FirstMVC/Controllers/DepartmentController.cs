using FirstMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class DepartmentController(FirstMvcContext _context) : Controller
    {
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }
    }
}
