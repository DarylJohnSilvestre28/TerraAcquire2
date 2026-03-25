using System;
using System.Collections.Generic;
using TerraAcquire.Contracts.ModelHouses;


namespace TerraAcquire.Contracts.ModelHouses
{
    public interface IModelHouseService : IService
    {
        IEnumerable<ModelHouseDto> GetAll();
        ModelHouseDto? GetById(Guid id);

        Task<ModelHouseDto> CreateAsync(CreateDto dto);
        Task<ModelHouseDto> UpdateAsync(UpdateDto dto);
        Task<bool> DeleteAsync(ActivationDto dto);
        Task<bool> RestoreAsync(ActivationDto dto);
        Task AddAsync(ModelHouseDto dto);
    }
}
