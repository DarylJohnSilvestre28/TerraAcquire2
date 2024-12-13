using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TerraAquire.Web.Pages.Manage.IModelHouses
{
    public class Index : PageModel
    {
        public readonly IModelHouseService _modelHouseService;
        private IModelHouseService? modelHouselService;

        public Index(IModelHouseService modelHouseService)
        {
            _modelHouseService = modelHouselService;
        }
        public async Task OnGet(bool? isActive = true, int? pageIndex = 1, int? pageSize = 10, string? keyword = "")
        {
            ModelHouses = await _modelHouseService.Search(isActive, pageIndex, pageSize, keyword);
        }

        public Paged<ModelHouseDto>? HouseModels { get; set; }
        public object ModelHouses { get; private set; }
    }

}