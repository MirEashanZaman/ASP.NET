using FirstMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class MajorController(FirstMvcContext _context) : Controller
    {
        public IActionResult Index()
        {
            var majors = _context.Majors.Where(e => (e.TotalTuitionFee / e.TotalCredit) > 5500).ToList();
            return View(majors);
        }
    }
}
