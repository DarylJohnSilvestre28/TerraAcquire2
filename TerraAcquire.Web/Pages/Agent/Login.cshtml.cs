using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Agent
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (Username == "daryljan" && Password == "csmbataan28")
            {
                return RedirectToPage("/Agent/Dashboard");
            }

            ErrorMessage = "Invalid username or password.";
            return Page();
        }
    }
}
