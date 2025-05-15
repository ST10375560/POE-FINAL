namespace AgriEnergyConnectWebApp.Models
{
    // Represents an employee in the Agri-Energy Connect system.
    public class Employee
    {
        // Unique identifier for the employee (Primary Key).
        // This method was adapted from: https://www.w3schools.com/cs/cs_properties.php
        // Author: Anonymous
        // Website name: www.w3schools.com

        public int EmployeeId { get; set; }
        // Full name of the employee.
        public string FullName { get; set; }
        //Employee's email address (used for contact or login).
        public string Email { get; set; }
        // Hashed password used for employee authentication.
        public string PasswordHash { get; set; }
    }

}
