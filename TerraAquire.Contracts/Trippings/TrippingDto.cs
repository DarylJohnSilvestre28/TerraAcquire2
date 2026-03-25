using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraAcquire.Contracts.Trippings
{
    public class TrippingDto
    {
        public Guid? Id { get; set; }
        public Guid? AgentId { get; set; }
        public string AgentName { get; set; }
        public Guid? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? DateTime { get; set; }
    }
}