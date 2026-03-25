using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TerraAcquire.Contracts.ModelHouses;

namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class EditModel : PageModel
    {
        private readonly IModelHouseService _modelHouseService;

        public EditModel(IModelHouseService modelHouseService)
        {
            _modelHouseService = modelHouseService;
        }

        [BindProperty]
        public ModelHouseDto ModelHouse { get; set; } = default!;

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ModelHouse = _modelHouseService.GetById(id.Value);

            if (ModelHouse == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _modelHouseService.UpdateAsync(new UpdateDto
            {
                Id = ModelHouse.Id,
                Name = ModelHouse.Name,
                Location = ModelHouse.Location,
                Price = ModelHouse.Price,
                Bedrooms = ModelHouse.Bedrooms, 
                Bathrooms = ModelHouse.Bathrooms
            });

            return RedirectToPage("Index");
        }
    }
}