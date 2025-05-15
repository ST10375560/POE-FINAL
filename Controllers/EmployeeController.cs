using AgriEnergyConnectWebApp.Data;
using AgriEnergyConnectWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnectWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly AppDbContext _context;

        // Constructor injecting the database context to enable data access
        // This function was adapted from: https://medium.com/@yayasaafan/mastering-dbcontext-in-entity-framework-core-configuration-lifetime-and-best-practices-e8e89037d34d
        // Author: Yahia Saafan
        // Website name: Medium

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // Displays a dashboard view with a list of all registered farmers
        public IActionResult Dashboard()
        {
            return View(_context.Farmers.ToList());
        }

        // Displays the form for adding a new farmer
        public IActionResult AddFarmer() => View();

        // Handles the submission of the new farmer form
        [HttpPost]
        public IActionResult AddFarmer(Farmer farmer)
        {
            // Add the new farmer to the database
            _context.Farmers.Add(farmer);
            _context.SaveChanges();

            // Redirect back to the dashboard after successful addition
            return RedirectToAction("Dashboard");
        }

        // Displays the products of a specific farmer, with optional filtering by category and date range
        public IActionResult ViewProducts(int farmerId, string category, DateTime? from, DateTime? to)
        {
            // Start query to get products associated with the specified farmer
            var query = _context.Products.Where(p => p.FarmerId == farmerId);

            // Filter by product category if provided
            // This function was adapted from: https://www.geeksforgeeks.org/c-sharp-string-isnullorempty-method/
            // Author: GeeksforGeeks
            // Webite name: GeeksforGeeks

            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);

            
            if (from.HasValue)
            {
                var utcFrom = DateTime.SpecifyKind(from.Value, DateTimeKind.Utc);
                query = query.Where(p => p.ProductionDate >= utcFrom);
            }

            // Filter by end date (production date <= to)
            if (to.HasValue)
            {
                var utcTo = DateTime.SpecifyKind(to.Value, DateTimeKind.Utc);
                query = query.Where(p => p.ProductionDate <= utcTo);
            }

            // Pass the farmerId to the view for context
            ViewBag.FarmerId = farmerId;

            // Return the filtered list of products to the view
            return View(query.ToList());
        }

        // Deletes a farmer and their associated products
        [HttpPost]
        public IActionResult DeleteFarmer(int id)
        {
            // Find the farmer by ID
            //This method was adapted from: https://stackoverflow.com/questions/21187083/from-where-or-firstordefault-in-linq
            // Author: Anonymous
            // Website name: StackOverFlow
            
            var farmer = _context.Farmers.FirstOrDefault(f => f.FarmerId == id);

            if (farmer != null)
            {
                // First delete all products linked to the farmer
                var products = _context.Products.Where(p => p.FarmerId == id).ToList();
                _context.Products.RemoveRange(products);

                // Then remove the farmer
                _context.Farmers.Remove(farmer);
                _context.SaveChanges();
            }

            // Redirect back to the dashboard after deletion
            return RedirectToAction("Dashboard");
        }
    }
}
