using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class FeaturePageModel : PageModel
    {
        // Property to hold feature description
        public string FeatureDescription { get; set; } = "This is an example of a feature page.";

        // Property to hold user input
        public string UserInput { get; set; }

        // Handle GET requests
        public void OnGet()
        {
            // You can add any logic to handle the GET request here
        }

        // Handle POST requests
        public void OnPost()
        {
            // Retrieve user input from the form
            UserInput = Request.Form["userInput"];
        }
    }
}
