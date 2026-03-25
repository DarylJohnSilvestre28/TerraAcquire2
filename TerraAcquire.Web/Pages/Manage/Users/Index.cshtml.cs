using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace TerraAquire.Web.Pages.Manage.Users
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IUserService _userService;

        [BindProperty]
        public ViewModel Data { get; set; }
        public Index(ILogger<Index> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;

            Data = Data ?? new ViewModel();
        }

        public void OnGet(int? pageIndex = 1, int? pageSize = 10, string? sortBy = "", string? keyword = "")
        {
            Data.Entity = _userService.Search(pageIndex, pageSize, sortBy, keyword);
        }

        public class ViewModel
        {

            public string? Entity { get; set; }
            public string? Items { get; set; }
        }
    }

    public interface IUserService
    {
        string? Search(int? pageIndex, int? pageSize, string? sortBy, string? keyword);
    }
}
