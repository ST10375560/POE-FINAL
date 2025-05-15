using AgriEnergyConnectWebApp.Models;

namespace AgriEnergyConnectWebApp.Models
{

    // Represents a farmer in the Agri-Energy Connect system.
    // A farmer can register, log in, and list multiple products.
    public class Farmer
    {
        // Unique identifier for the farmer (Primary Key).
        // This method was adapted from: https://www.w3schools.com/cs/cs_properties.php
        // Author: Anonymous
        // Website name: www.w3schools.com
        public int FarmerId { get; set; }
        // Full name of the farmer.
        public string FullName { get; set; }
        // Email address of the farmer (used for contact or authentication).
        public string Email { get; set; }
        // Hashed password used for authentication.
        public string PasswordHash { get; set; }
        // Navigation property representing the list of products owned by the farmer.
        // Establishes a one-to-many relationship with the Product entity.
        public ICollection<Product> Products { get; set; }
    }
}
