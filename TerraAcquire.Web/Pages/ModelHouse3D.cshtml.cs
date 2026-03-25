using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TerraAcquire.EntityFramework.Models;

namespace TerraAcquire.Web.Pages
{
    public class ModelHousesModel : PageModel
    {
        public List<ModelHouse> Houses { get; set; } = new();

        public void OnGet()
        {
            Houses = new List<ModelHouse>
    {
        new ModelHouse
        {
            Name = "Sunrise Villa",
            Location = "Zambales",
            Price = 150000,
            Bedrooms = 3,
            Bathrooms = 2,
            ImageUrl = "/images/house1.jpg"
        },

        new ModelHouse
        {
            Name = "Lakeside View",
            Location = "Tagaytay",
            Price = 200000,
            Bedrooms = 4,
            Bathrooms = 3,
            ImageUrl = "/images/house2.jpg"
        },

        new ModelHouse
        {
            Name = "Lincoln Heights",
            Location = "San Pablo, Dinalupihan, Bataan",
            Price = 550000,
            Bedrooms = 3,
            Bathrooms = 1,
            ImageUrl = "/images/house3.jpg"
        }
    };
}
    }
}
