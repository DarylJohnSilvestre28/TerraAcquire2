using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TerraAcquire.EntityFramework;
using TerraAcquire.EntityFramework.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ModelHouse> Houses { get; set; } = new();

        public async Task OnGetAsync()
        {
            Houses = await _context.ModelHouses.ToListAsync();
        }
    }
}