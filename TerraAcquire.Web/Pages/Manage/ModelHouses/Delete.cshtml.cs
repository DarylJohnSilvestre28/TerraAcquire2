using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TerraAcquire.EntityFramework;
using TerraAcquire.EntityFramework.Models;

namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ModelHouse House { get; set; }

        // GET
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            House = await _context.ModelHouses
                .FirstOrDefaultAsync(m => m.Id == id);

            if (House == null)
            {
                return NotFound();
            }

            return Page();
        }

        // POST
        public async Task<IActionResult> OnPostAsync()
        {
            if (House == null)
                return NotFound();

            var house = await _context.ModelHouses
                .FindAsync(House.Id);

            if (house != null)
            {
                _context.ModelHouses.Remove(house);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}