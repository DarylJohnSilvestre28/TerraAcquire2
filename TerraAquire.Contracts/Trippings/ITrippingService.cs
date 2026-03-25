using TerraAcquire.Contracts.Trippings;
using System.Collections.Generic;

namespace TerraAcquire.Contracts.Trippings
{
    public interface ITrippingService
    {
        void SaveTripping(TrippingDto tripping);
        List<TrippingDto> GetAllTrippings();
        List<TrippingDto> GetTrippingsByCustomer(Guid customerId);
        List<TrippingDto> GetTrippingsByAgent(Guid agentId);
    }
}