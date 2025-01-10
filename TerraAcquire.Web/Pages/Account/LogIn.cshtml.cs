using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MedicalTranscriptionSystem.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginViewModel Login { get; set; }

        public bool IsLoggedIn { get; set; }
        public bool IsLoginFailed { get; set; }

        public string UsernameError { get; set; }
        public string PasswordError { get; set; }

        // Simulated list of users for the demo (username/password)
        private static readonly List<User> Users = new List<User>
        {
            new User { Username = "user@example.com", Password = "password123" },
            new User { Username = "admin@example.com", Password = "admin123" }
        };

        public void OnGet()
        {
            Login = new LoginViewModel();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                // Check if the user exists and password matches
                var user = Users.FirstOrDefault(u => u.Username == Login.Username && u.Password == Login.Password);

                if (user != null)
                {
                    IsLoggedIn = true;
                    IsLoginFailed = false;
                    // Simulate successful login behavior (e.g., redirect to another page)
                    return;
                }
                else
                {
                    IsLoginFailed = true;
                    IsLoggedIn = false;
                }
            }
            else
            {
                // Handle validation errors
                UsernameError = "Please enter a valid username or email.";
                PasswordError = "Please enter a valid password.";
            }
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