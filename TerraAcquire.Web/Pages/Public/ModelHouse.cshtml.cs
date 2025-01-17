using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Public
{
    public class IndexModel : PageModel
    {
        public ModelHouse House { get; set; }

        public void OnGet()
        {
          
            House = new ModelHouse
            {
                Name = "The Grand Mansion",
                SquareFeet = 3500,
                Bedrooms = 5,
                Bathrooms = 4,
                Price = 97000000
            };
        }
    }
}