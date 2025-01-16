using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourAppNamespace.Models;
using YourAppNamespace.Data; // Assuming you have a DbContext or a data source


namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class UpdateModel : PageModel
    {
        private readonly YourDbContext _context;

        public UpdateModel(YourDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; } // Replace 'Item' with the appropriate model class

        public IActionResult OnGet(int id)
        {
            // Fetch the item to update based on the ID (could be from a database)
            Item = _context.Items.Find(id); // Replace with your data source
            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the item in your data source
            _context.Items.Update(Item); // Replace with the correct data update logic
            _context.SaveChanges();

            return RedirectToPage("/Success"); // Redirect to a success page or elsewhere
        }
    }
}
