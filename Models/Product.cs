using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyConnectWebApp.Models

{

// Represents a product posted by a farmer in the Agri-Energy Connect system.
public class Product
{
// Primary key for the Product entity.
public int Id { get; set; } 

    
    [Required]
    public int FarmerId { get; set; } // Foreign key to Farmer
    
    // Name of the product. Required with a maximum length of 100 characters.
    // This method was adapted from: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/required
    // Author: BillWagner
    // Website name: Microsoft.com

    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    [StringLength(50)]
    public string Category { get; set; }

    [Required(ErrorMessage = "Production date is required.")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime ProductionDate { get; set; }

    // Navigation property to the related Farmer entity.
    // Used to establish the relationship between Product and Farmer.
    [ForeignKey("FarmerId")]
    public Farmer Farmer { get; set; }
}


}

