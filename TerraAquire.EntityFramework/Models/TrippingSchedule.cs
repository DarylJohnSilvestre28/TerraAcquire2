using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraAcquire.EntityFramework.Models
{
    public class TrippingSchedule
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; } 

        public string AgentName { get; set; } = string.Empty;

        public string ScheduledBy { get; set; } = string.Empty;

        public Guid? CustomerId { get; set; }

        public Guid? AgentId { get; set; }

        public string CustomerName { get; set; } = string.Empty;
    }
}