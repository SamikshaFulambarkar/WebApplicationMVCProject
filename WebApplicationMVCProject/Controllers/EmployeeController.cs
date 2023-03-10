using Microsoft.AspNetCore.Mvc;
using WebApplicationMVCProject.Models;

namespace WebApplicationMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        EmployeeDAL db;

        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new EmployeeDAL(configuration);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]

        public IActionResult AddEmployee(Employee emp)
        {
            try
            {
                int result=db.AddEmployee(emp);
                if(result==1)
                {
                    ViewBag.message = "Employee record added";
                }
                else
                {
                    ViewBag.message = "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return View(emp);
        }
        public IActionResult EditEmployee(int id) 
        {
            var emp=db.GetEmployeeById(id);
            return View(emp);
        }
        public IActionResult EditEmployee(Employee emp)
        {
            try
            {
                int result = db.UpdateEmployee(emp);
                if (result == 1)
                {
                    return RedirectToAction(nameof(EmployeeList));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                
            }
            return View(emp);
        }
        public IActionResult DeleteEmployee(int id)
        {
            var emp = db.GetEmployeeById(id);
            return View(emp);
        }
        [HttpPost]
        [ActionName("DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = db.DeleteEmployee(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(EmployeeList));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {

            }
            return View(id);
        }
        public IActionResult EmployeeDetails(int id)
        {
            var emp = db.GetEmployeeById(id);
            return View(emp);
        }
    }
}
