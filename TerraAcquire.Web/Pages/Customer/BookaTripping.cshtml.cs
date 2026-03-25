using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class BookaTrippingModel : PageModel
{
    [BindProperty]
    public TrippingBookingDto Trip { get; set; } = new();

    public List<SelectListItem> DestinationList { get; set; } = new();

    public bool IsSuccess { get; set; }

    public void OnGet()
    {
        LoadDestinationList();
    }

    public IActionResult OnPost()
    {
        LoadDestinationList();

        if (!ModelState.IsValid)
        {
            return Page();
        }

        // TODO: Save to DB or send email
        Console.WriteLine($"Tripping Booked by: {Trip.FullName}, Destination: {Trip.DestinationId}, Date: {Trip.TripDate}, Time: {Trip.TripTime}");

        IsSuccess = true;
        ModelState.Clear();
        Trip = new TrippingBookingDto(); // reset form

        return Page();
    }

    private void LoadDestinationList()
    {
        DestinationList = new List<SelectListItem>
        {
                new SelectListItem { Text = "Camella", Value = "Camella" },
                new SelectListItem { Text = "Lincoln heights", Value = "Lincoln heights" },
                new SelectListItem { Text = "Lincoln heights", Value = "Lincoln heights" },
                new SelectListItem { Text = "Beverly heights", Value = "Beverly heights" },
                new SelectListItem { Text = "Lumina homes", Value = "Lumina homes" }
        };
    }
}