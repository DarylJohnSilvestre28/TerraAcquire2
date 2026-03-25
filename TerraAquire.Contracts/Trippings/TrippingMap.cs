using AutoMapper;
using TerraAcquire.EntityFramework.Models;

namespace TerraAcquire.Contracts.Trippings
{
    public class TrippingMap : Profile
    {
        public TrippingMap()
        {
            // Map from entity to DTO
            CreateMap<TrippingSchedule, TrippingDto>();

            // Map from DTO to entity
            CreateMap<TrippingDto, TrippingSchedule>();
        }
    }
}
