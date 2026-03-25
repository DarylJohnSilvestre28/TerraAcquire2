using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraAcquire.Contracts.ModelHouses
{
    public class ModelHouseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double AreaSquareMeters { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public bool IsActive { get; set; }
        public int Floors { get; set; }
        public double SquareFeet { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}