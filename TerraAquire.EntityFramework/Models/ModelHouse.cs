using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraAcquire.EntityFramework.Models
{
    public class ModelHouse
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }
        public string? Features { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Range(0, double.MaxValue, ErrorMessage = "Price must be 0 or higher")]
        public decimal Price { get; set; }

        public string? Content { get; set; }
        public string? ARmodel { get; set; }

        public bool IsActive { get; set; } = true;

        public int Rooms { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Bathrooms { get; set; }

        [Range(0, int.MaxValue)]
        public int Bedrooms { get; set; }

        public int Floors { get; set; }

        public double SquareFeet { get; set; }

        [NotMapped]
        public string? ImageUrl { get; set; }

    }
}