using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraAcquire.Contracts.ModelHouses
{
    public class UpdateDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }
        public Guid? UserId { get; set; }
        public string? Content { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; } 
    }
}
