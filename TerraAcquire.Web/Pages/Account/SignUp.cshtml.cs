using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TerraAcquire.Web.Pages.Account
{
    public class SignUp : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Full Name")]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: Save user to DB or call service

            return RedirectToPage("/Account/Login");
        }
    }
}