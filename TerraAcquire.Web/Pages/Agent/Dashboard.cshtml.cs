using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TerraAcquire.Contracts.Trippings;
using TerraAcquire.Services;

namespace TerraAcquire.Web.Pages.Agent
{
    public class DashboardModel : PageModel
    {
        private readonly ITrippingService _trippingService;

        public DashboardModel(ITrippingService trippingService)
        {
            _trippingService = trippingService;
        }

        [BindProperty]
        public TrippingDto Tripping { get; set; }

        public string UserRole { get; set; }
        public string UserId { get; set; } // current user ID

        public void OnGet()
        {
            // Determine role
            UserRole = User.IsInRole("Admin") ? "Admin" :
                       User.IsInRole("Agent") ? "Agent" : "Customer";

            // Get user ID from claims or identity
            UserId = User.Identity.Name;
        }

        // Save tripping
        public IActionResult OnPostSaveTripping()
        {
            if (Tripping == null || string.IsNullOrEmpty(Tripping.CustomerName))
                return new JsonResult(new { success = false, message = "Model is null" });

            // Convert UserId string to Guid for Customer or Agent
            if (UserRole == "Customer")
            {
                if (Guid.TryParse(UserId, out Guid customerGuid))
                    Tripping.CustomerId = customerGuid;
                else
                    return new JsonResult(new { success = false, message = "Invalid Customer ID" });
            }

            if (UserRole == "Agent")
            {
                if (Guid.TryParse(UserId, out Guid agentGuid))
                    Tripping.AgentId = agentGuid;
            }

            // Save the tripping using service
            _trippingService.SaveTripping(Tripping);

            return new JsonResult(new { success = true, customer = Tripping.CustomerName });
        }

        // Get events for FullCalendar
        public IActionResult OnGetGetTrippings()
        {
            List<TrippingDto> trippings = new();

            if (UserRole == "Admin")
            {
                trippings = _trippingService.GetAllTrippings();
            }
            else if (UserRole == "Agent" && Guid.TryParse(UserId, out Guid agentGuid))
            {
                trippings = _trippingService.GetTrippingsByAgent(agentGuid);
            }
            else if (UserRole == "Customer" && Guid.TryParse(UserId, out Guid customerGuid))
            {
                trippings = _trippingService.GetTrippingsByCustomer(customerGuid);
            }
            else
            {
                // fallback: invalid GUID
                trippings = new List<TrippingDto>();
            }

            var events = trippings.Select(t => new {
                title = t.CustomerName,
                start = t.DateTime?.ToString("yyyy-MM-ddTHH:mm")
            });

            return new JsonResult(events);
        }
    }
}