using LabTask_2_51726_.Data;
using Microsoft.AspNetCore.Mvc;

namespace LabTask51726.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityDbContext _context;

        public StudentController(UniversityDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
    }
}