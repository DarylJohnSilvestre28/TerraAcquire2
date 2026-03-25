using TerraAcquire.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TerraAcquire.Contracts.ModelHouses
{
    public class CreateDto
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public Guid? UserId { get; set; }
        public string? Content { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
