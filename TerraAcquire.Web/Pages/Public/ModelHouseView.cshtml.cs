using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TerraAcquire.Web.Pages.Public
{
    public class ModelHouse : PageModel
    {
        public List<House> Houses { get; set; }

        public void OnGet()
        {

            Houses = new List<House>
            {
                new House { Name = "Modern Villa", SquareFeet = 2500, Bedrooms = 4, Bathrooms = 3, Price = 500000 },
                new House { Name = "Townhouse", SquareFeet = 1800, Bedrooms = 3, Bathrooms = 2, Price = 350000 },
            };
        }

        public class House
        {
            public string Name { get; set; }
            public int SquareFeet { get; set; }
            public int Bedrooms { get; set; }
            public int Bathrooms { get; set; }
            public decimal Price { get; set; }
        }
    }
}
public class House
{
    public string Name { get; set; }
    public string ImagePath { get; set; } 
}