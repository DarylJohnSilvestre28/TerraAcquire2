using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

public class CalendarViewModel : PageModel
{
    public int CurrentYear { get; set; }
    public int CurrentMonth { get; set; }
    public string CurrentMonthName { get; set; } = "";

    public List<List<int>> CalendarGrid { get; set; } = new();

    public void OnGet()
    {
        DateTime today = DateTime.Today;
        CurrentYear = today.Year;
        CurrentMonth = today.Month;
        CurrentMonthName = today.ToString("MMMM");

        var firstDay = new DateTime(CurrentYear, CurrentMonth, 1);
        int daysInMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
        int dayOfWeek = (int)firstDay.DayOfWeek;

        List<int> week = new();
        // Fill empty days before first of month
        for (int i = 0; i < dayOfWeek; i++)
        {
            week.Add(0);
        }

        for (int day = 1; day <= daysInMonth; day++)
        {
            week.Add(day);
            if (week.Count == 7)
            {
                CalendarGrid.Add(week);
                week = new List<int>();
            }
        }

        // Fill remaining empty days
        if (week.Count > 0)
        {
            while (week.Count < 7)
            {
                week.Add(0);
            }
            CalendarGrid.Add(week);
        }
    }
}