using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TerraAcquire.EntityFramework;
using TerraAcquire.EntityFramework.Models;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ModelHouse House { get; set; } = new ModelHouse();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    if (errors.Count > 0)
                        Console.WriteLine($"{key}: {string.Join(", ", errors.Select(e => e.ErrorMessage))}");
                }

                TempData["ErrorMessage"] = "Please fill all required fields correctly.";

                return Page();
            }

            House.Id = Guid.NewGuid();

            _context.ModelHouses.Add(House);
            await _context.SaveChangesAsync();


            TempData["SuccessMessage"] = "Model House created successfully!";


            return RedirectToPage("/Manage/ModelHouses/Index");
        }
    }
}