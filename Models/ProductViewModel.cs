using AgriEnergyConnectWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnectWebApp.ViewModels

{
    // ViewModel used for handling product creation/editing in the UI, 
    // including category selection from a dropdown list.
    public class ProductViewModel
    {
        public Product Product { get; set; }
        
        // The selected category value from the dropdown list.
        // This value is bound to the selected item in the CategoryOptions list.

        [Display(Name = "Category")]
        public string SelectedCategory { get; set; }

        // List of predefined product categories to populate the dropdown in the UI.
        // Each category is represented as a SelectListItem with both value and display text.
        // This method was adapted from: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item?view=net-9.0
        // Author: dotnet-bot
        // Website name: Microsoft.com
        public List<SelectListItem> CategoryOptions { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Vegetables", Text = "Vegetables" },
            new SelectListItem { Value = "Fruits", Text = "Fruits" },
            new SelectListItem { Value = "Grains", Text = "Grains" },
            new SelectListItem { Value = "Dairy", Text = "Dairy" },
            new SelectListItem { Value = "Meat", Text = "Meat" }
        };
    }
}
