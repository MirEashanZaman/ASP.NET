using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers
{
    public class ViewExampleController : Controller
    {
        public IActionResult Index(int p1, int p2)
        {
            ViewBag.Start = p1;
            ViewBag.End = p2;
            return View(5);
        }

        public IActionResult ChechData (int id)
        {
            switch (id)
                            {
                case 1:
                    return View(5);
                case 2:
                    return View(5.5);
                case 3:
                    return View("Eshan");
                case 4:
                    return View(new { Name ="Eshan", Id=5 });
            }
            return View();
        }
    }
}
