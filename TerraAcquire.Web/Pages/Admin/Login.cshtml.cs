using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAcquire.Web.Pages.Admin
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

            if (Username == "daryljohn" && Password == "iloveyou")
            {
                return RedirectToPage("/Admin/Dashboard");
            }

            ErrorMessage = "Invalid username or password.";
            return Page();
        }
    }
}
