using AgriEnergyConnectWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnectWebApp.Controllers

{
    // Controller to handle user account related actions, such as login
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor injecting the database context to enable data access
        // This function was adapted from: https://medium.com/@yayasaafan/mastering-dbcontext-in-entity-framework-core-configuration-lifetime-and-best-practices-e8e89037d34d
        // Author: Yahia Saafan
        // Website name: Medium

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        // Displays the login view (login form)
        // This function was adapted from: https://stackoverflow.com/questions/11716362/how-to-show-login-form-on-front-mainform-behind-login-form
        // Author: Anonymous
        // Website name: StackOverFlow

        public IActionResult Login() => View();
        // Handles login form submission with email and password parameters
        [HttpPost]
        public IActionResult Login(string email, string password)

        {   // Check if a farmer exists with the given email and password
            var farmer = _context.Farmers.FirstOrDefault(f => f.Email == email && f.PasswordHash == password);
            if (farmer != null)
            {    
                // If farmer found, store FarmerId in session and redirect to Home page
                HttpContext.Session.SetInt32("FarmerId", farmer.FarmerId);
                return RedirectToAction("Index", "Home");
            }
            
            // If no farmer found, check if an employee exists with the given email and password
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email && e.PasswordHash == password);
            if (employee != null)
            {
                // If employee found, store EmployeeId in session and redirect to Home page
                HttpContext.Session.SetInt32("EmployeeId", employee.EmployeeId);
                return RedirectToAction("Index", "Home");
            }

            // If neither farmer nor employee found, set error message to display in view
            ViewBag.Error = "Invalid login";
            return View();
        }
    }

}
