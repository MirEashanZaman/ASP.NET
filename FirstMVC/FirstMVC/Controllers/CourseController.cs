using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FirstMVC.Controllers
{
    [Route("course")]
    public class CourseController : Controller
    {
        // Accessible at: /courses
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Title = "All Courses";
            return View();
        }
        // Accessible at: /courses/details/5
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            ViewBag.CourseId = id;
            return View();
        }
        // Accessible at: /courses/search?keyword=mvc
        [Route("search")]
        public IActionResult Search(string keyword)
        {
            ViewBag.Keyword = keyword;
            return View();
        }


        [Route("List")]
        public IActionResult List()
        {
            ViewBag.Title = "Course List";
            ViewData["Description"] = "This is the list of courses offered.";
            return View();
        }

        [Route("Detail/{cid:int}")]
        public IActionResult Detail(int cid)
        {
            ViewBag.Message = "This is the detail of course: " + cid;
            return View();
        }

        public IActionResult Check(int id)
        {
            if (id == 1)
            {
                return Json(data: new { id = 1, name = "Eashan", dept = "CSE" });
            }
            else if (id == 2)
            {
                return Redirect(url: "https://www.google.com");
            }
            else if (id == 3)
            {
                return RedirectToAction("Privacy", controllerName: "Home");
            }
            else if (id == 4)
            {
                var cssFile = System.IO.File.ReadAllBytes(path: "wwwroot/css/site.css");
                return File(cssFile, contentType: "text/css", fileDownloadName: "Test.css");
            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult RouteCheck(int p1, int p2)

        {
            return Content(content: "This is the route check for course id: " + p1.ToString() + p2.ToString());
        }

    }

}