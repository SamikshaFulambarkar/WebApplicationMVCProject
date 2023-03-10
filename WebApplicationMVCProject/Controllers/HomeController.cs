using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMVCProject.Models;
using WebApplicationMVCProject.Models;

namespace WebApplicationMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["message"] = "This is my first MVC application";
            List<string> colors = new List<string>()
            {
                "Red",
                "Pink",
                "Green",
                "Yellow",
                "Violet",
                "Purple",
                "Black",
                "White"
            };
            ViewData["Colors"]=colors;

            List<Product> list = new List<Product>()
            {
                new Product{Id=1, Name="Pen", Price=20 },
                new Product{Id=2, Name="Pencil", Price=15 },
                new Product{Id=3, Name="NoteBokk", Price=40 },
            };
            ViewData["ProductList"] = list;

            List<EmployeeData> emp_list = new List<EmployeeData>()
            {
                new EmployeeData{Id=101, Name="Swara Shahu", Salary=35000, Dept_Name="HR" },
                new EmployeeData{Id=102, Name="Priya Verma", Salary=28000, Dept_Name="Finance" },
                new EmployeeData{Id=103, Name="Nikita Mane", Salary=38000, Dept_Name="SD" },
                new EmployeeData{Id=104, Name="Neha Bhondwe", Salary=48000, Dept_Name="Sales" },
                new EmployeeData{Id=105, Name="Sonal Sahare", Salary=30000, Dept_Name="RND" },
            };
            ViewData["EmployeeList"] = emp_list;

            List<StudentData> st_list = new List<StudentData>()
            {
                new StudentData{Roll_No=101, Name="Swara Shahu", Class="Class A", Percent="85.20%" },
                new StudentData{Roll_No=102, Name="Priya Verma", Class="Class B", Percent="75.86%" },
                new StudentData{Roll_No=103, Name="Nikita Mane", Class="Class C", Percent="89.20%" },
                new StudentData{Roll_No=104, Name="Neha Bhondwe", Class="Class D", Percent="85.00%" },
                new StudentData{Roll_No=105, Name="Sonal Sahare", Class="Class B", Percent="82.35%" },
            };
            ViewData["StudentList"] = st_list;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}