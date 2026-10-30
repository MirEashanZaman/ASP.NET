using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstMVC.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Registration()
        {
            this.LoadSupportingData();
            return View(new StudentModel());
        }

        [HttpPost]
        public IActionResult Registration(StudentModel model)
        {
            this.LoadSupportingData();

            if (model.FullName == "Eshan")
            {
                ModelState.AddModelError("FullName", "Eshan is not allowed to register.");
            }
            if (model.FullName == "Eshan" && model.Age == 25)
            {
                ModelState.AddModelError("", "Eshan can not be 25 years old.");
            }

            if (ModelState.IsValid==false)
            {
                return View(model);
            }
            else
            {
                return View("RegistrationSuccess", model);
            }

            ViewBag.Message = "Registration successful for " + model.FullName;
            return View(model);
        }

        private void LoadSupportingData()
        {
            var genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem() { Text = "Male", Value = "Male" });
            genderList.Add(new SelectListItem() { Text = "Female", Value = "Female" });
            ViewBag.GenderList = genderList;
        }
    }
}