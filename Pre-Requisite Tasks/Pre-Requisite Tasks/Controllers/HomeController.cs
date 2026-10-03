using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Pre_Requisite_Task_2.Models;
using System.Diagnostics;

namespace Pre_Requisite_Task_2.Controllers
{
    public class HomeController : Controller
    {
        private const string ConnStr =
            "Server=(localdb)\\ProjectModels;Database=StudentCourseDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StudentForm()
        {
            return View();
        }

        public IActionResult Results()
        {
            string baseSql = @"SELECT s.StudentName, c.CourseName, cts.FinalMark
                               FROM CourseTakenByStudent cts
                               JOIN Student s ON s.StudentId = cts.StudentId
                               JOIN Course c ON c.CourseId = cts.CourseId";

            var all = GetResults(baseSql);

            int lowest;
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT MIN(FinalMark) FROM CourseTakenByStudent", conn);
                lowest = (int)cmd.ExecuteScalar();
            }

            var lowestStudents = GetResults(baseSql +
                " WHERE cts.FinalMark = (SELECT MIN(FinalMark) FROM CourseTakenByStudent)");

            ViewBag.LowestMark = lowest;
            ViewBag.LowestStudents = lowestStudents;
            return View(all);
        }

        public IActionResult StudentInfo()
        {
            Student s = new Student();
            s.ID = 1;
            s.Name = "Eshan";
            s.Department = "CSE";

            ViewBag.Info = s.DisplayInfo();
            return View();
        }

        private List<StudentResult> GetResults(string sql)
        {
            var list = new List<StudentResult>();
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                var reader = new SqlCommand(sql, conn).ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new StudentResult
                    {
                        StudentName = reader.GetString(0),
                        CourseName = reader.GetString(1),
                        FinalMark = reader.GetInt32(2)
                    });
                }
            }
            return list;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}