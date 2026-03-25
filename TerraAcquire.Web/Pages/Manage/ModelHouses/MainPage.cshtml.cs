using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TerraAcquire.EntityFramework;
using TerraAcquire.EntityFramework.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class MainPageModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MainPageModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TrippingSchedule> Schedules { get; set; }

        [BindProperty]
        public TrippingSchedule Tripping { get; set; }

        public void OnGet()
        {
            Schedules = _context.TrippingSchedules.ToList();
        }

        // ✅ FIXED: use ONLY DateTime
        public JsonResult OnGetGetTrippings()
        {
            var trips = _context.TrippingSchedules.Select(t => new
            {
                title = t.AgentName,
                start = t.DateTime,
                scheduled_by = t.ScheduledBy
            }).ToList();

            return new JsonResult(trips);
        }

        // ✅ FIXED SAVE METHOD
        public IActionResult OnPostSaveTripping()
        {
            try
            {
                if (Tripping == null ||
                    string.IsNullOrWhiteSpace(Tripping.AgentName) ||
                    Tripping.DateTime == default)
                {
                    return new JsonResult(new
                    {
                        success = false,
                        message = "Please fill all required fields."
                    });
                }

                var trip = new TrippingSchedule
                {
                    AgentName = Tripping.AgentName,
                    CustomerName = Tripping.CustomerName ?? Tripping.AgentName,
                    DateTime = Tripping.DateTime,
                    ScheduledBy = User.Identity?.Name ?? "Unknown"
                };

                _context.TrippingSchedules.Add(trip);
                _context.SaveChanges();

                return new JsonResult(new { success = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    success = false,
                    message = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}