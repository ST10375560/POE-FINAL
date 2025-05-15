using AgriEnergyConnectWebApp.Data;
using AgriEnergyConnectWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgriEnergyConnectWebApp.Controllers
{
    public class FarmerController : Controller
    {
        // Constructor injecting the database context to enable data access
        // This function was adapted from: https://medium.com/@yayasaafan/mastering-dbcontext-in-entity-framework-core-configuration-lifetime-and-best-practices-e8e89037d34d
        // Author: Yahia Saafan
        // Website name: Medium

        private readonly AppDbContext _context;

        public FarmerController(AppDbContext context)
        {
            _context = context;
        }

        // Displays the logged-in farmer's product list
        public IActionResult Index()
        {
            // Get the currently logged-in farmer's ID from session
            var farmerId = HttpContext.Session.GetInt32("FarmerId");

            // If no farmer is logged in, redirect to login page
            if (farmerId == null) return RedirectToAction("Login", "Account");

            // Retrieve products belonging to the farmer
            var products = _context.Products
                .Where(p => p.FarmerId == farmerId)
                .ToList();

            // Pass the products to the view
            return View(products);
        }

        // Displays the form to add a new product
        public IActionResult AddProduct() => View();

        // Handles the submission of the Add Product form
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            // Get the logged-in farmer's ID from session
            var farmerId = HttpContext.Session.GetInt32("FarmerId");
            if (farmerId == null) return RedirectToAction("Login", "Account");

            // Associate the product with the current farmer
            product.FarmerId = farmerId.Value;

            // Ensure ProductionDate is explicitly marked as UTC
            if (product.ProductionDate.Kind == DateTimeKind.Unspecified)
            {
                product.ProductionDate = DateTime.SpecifyKind(product.ProductionDate, DateTimeKind.Utc);
            }

            // Add the new product to the database
            _context.Products.Add(product);
            _context.SaveChanges();

            // Redirect to the product listing after successful addition
            return RedirectToAction("Index");
        }

        // Handles the deletion of a product
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            // Find the product by ID
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            // Get the current farmer's ID from session
            var farmerId = HttpContext.Session.GetInt32("FarmerId");

            // Only allow deletion if the product belongs to the current farmer
            if (farmerId == null || product.FarmerId != farmerId.Value)
            {
                return Unauthorized();
            }

            // Remove the product from the database
            _context.Products.Remove(product);
            _context.SaveChanges();

            // Redirect back to the product list
            // This method was adapted from: https://stackoverflow.com/questions/1257482/redirecttoaction-with-parameter
            // Author: Anonymous
            // Website name: StackOverFlow
            return RedirectToAction("Index");
        }
    }
}
