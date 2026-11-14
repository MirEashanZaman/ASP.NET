using FirstMVC.Data;
using FirstMVC.Data.Entities;
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

        public IActionResult Delete (int did)
        {
            var department = _context.Departments.Find(did);
            if (department == null)
            {
                TempData["ErrorMessage"] = "Department not found.";
            }
            else
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Department deleted successfully.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Department());
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid==false)
            {
                return View(department);
            }

            _context.Departments.Add(department);
            _context.SaveChanges();
            TempData["Success"] = "Department created successfully.";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int did)
        {
            var department = _context.Departments.Find(did);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid == false)
            {
                return View(department);
            }

            _context.Departments.Update(department);
            _context.SaveChanges();
            TempData["Success"] = "Department updated successfully.";

            return RedirectToAction("Index");
        }
    }
}
