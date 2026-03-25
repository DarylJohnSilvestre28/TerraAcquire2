using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TerraAcquire.Web.Pages.Manage.ModelHouses
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public string ItemName { get; set; }

        [BindProperty]
        public string ItemDescription { get; set; }


        public static List<Item> Items = new List<Item>();

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                var newItem = new Item
                {
                    Name = ItemName,
                    Description = ItemDescription
                };

                Items.Add(newItem);

                return RedirectToPage("/Index");
            }


            return Page();
        }
    }


    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}   