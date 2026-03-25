using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TerraAcquire.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public required LoginViewModel Login { get; set; }

        public bool IsLoggedIn { get; set; }
        public bool IsLoginFailed { get; set; }

        public string UsernameError { get; set; }
        public string PasswordError { get; set; }

        private static readonly List<User> Users = new List<User>
        {
            new User { Username = "dj", Password = "janjan28" } 
        };

        public void OnGet()
        {
            Login = new LoginViewModel();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = Users.FirstOrDefault(u => u.Username == Login.Username && u.Password == Login.Password);

                if (user != null)
                {
                    IsLoggedIn = true;
                    IsLoginFailed = false;


                    return RedirectToPage("/Manage/ModelHouses/MainPage");
                }
                else
                {
                    IsLoginFailed = true;
                    IsLoggedIn = false;
                }
            }
            else
            {
                UsernameError = "Please enter a valid username or email.";
                PasswordError = "Please enter a valid password.";
            }

            return Page();
        }
    }

    public class LoginViewModel
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}