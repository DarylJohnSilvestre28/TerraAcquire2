using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TerraAcquire.Web.Pages.Customer
{
    public class CustomerSignupModel : PageModel
    {
        [BindProperty]
        public CustomerInputModel Customer { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            return RedirectToPage("SignupSuccess");
        }

        public class CustomerInputModel
        {
            [Required]
            [Display(Name = "Full Name")]
            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [MinLength(6)]
            public string Password { get; set; }
        }
    }
}
