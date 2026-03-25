using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TerraAcquire.EntityFramework;
using TerraAcquire.EntityFramework.Models;
namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class DetailsModel : PageModel
    {
        private readonly DefaultDbContext _context;

        public DetailsModel(DefaultDbContext context)
        {
            _context = context;
        }


        public TerraAcquire.EntityFramework.Models.ModelHouse ModelHouse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();
            ModelHouse = await _context.ModelHouses
                .AsNoTracking()
                .FirstOrDefaultAsync(h => h.Id == id && h.IsActive);

            if (ModelHouse == null)
                return NotFound();
            return Page();
        }
    }
}