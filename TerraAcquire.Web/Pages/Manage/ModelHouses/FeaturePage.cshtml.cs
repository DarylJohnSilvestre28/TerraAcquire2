using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class FeaturePageModel : PageModel
    {

        public string FeatureDescription { get; set; } = "This is an example of a feature page.";


        public string UserInput { get; set; }


        public void OnGet()
        {

        }


        public void OnPost()
        {

            UserInput = Request.Form["userInput"];
        }
    }
}
