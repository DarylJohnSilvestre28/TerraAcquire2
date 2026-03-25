using Microsoft.EntityFrameworkCore;
using TerraAcquire.Contracts.ModelHouses;
using TerraAcquire.EntityFramework;
using TerraAcquire.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerraAcquire.Services.ModelHouses
{
    public class ModelHouseService : IModelHouseService
    {
        private readonly ApplicationDbContext _context;

        public ModelHouseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ModelHouseDto> GetAll()
        {
            return _context.ModelHouses
                .Where(h => h.IsActive) // optional but recommended
                .Select(h => new ModelHouseDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Price = h.Price,
                    Bedrooms = h.Bedrooms,
                    Bathrooms = h.Bathrooms,
                    Floors = h.Floors,
                    SquareFeet = h.SquareFeet,
                    Description = h.Description
                })
                .ToList();
        }

        public ModelHouseDto? GetById(Guid id)
        {
            return _context.ModelHouses
                .Where(h => h.Id == id)
                .Select(h => new ModelHouseDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Price = h.Price
                })
                .FirstOrDefault();
        }

        public async Task<ModelHouseDto> CreateAsync(CreateDto dto)
        {
            var entity = new ModelHouse
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Location = dto.Location,
                Price = dto.Price,
                IsActive = true
            };

            _context.ModelHouses.Add(entity);
            await _context.SaveChangesAsync();

            return new ModelHouseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location,
                Price = entity.Price
            };
        }

        public async Task<ModelHouseDto> UpdateAsync(UpdateDto dto)
        {
            var entity = await _context.ModelHouses
                .FirstOrDefaultAsync(h => h.Id == dto.Id);

            if (entity == null)
                throw new Exception("Model house not found");

            entity.Name = dto.Name;
            entity.Location = dto.Location;
            entity.Price = dto.Price;

            await _context.SaveChangesAsync();

            return new ModelHouseDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location,
                Price = entity.Price
            };
        }

        public async Task<bool> DeleteAsync(ActivationDto dto)
        {
            var entity = await _context.ModelHouses
                .FirstOrDefaultAsync(h => h.Id == dto.Id);

            if (entity == null)
                return false;

            entity.IsActive = false;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RestoreAsync(ActivationDto dto)
        {
            var entity = await _context.ModelHouses
                .FirstOrDefaultAsync(h => h.Id == dto.Id);

            if (entity == null)
                return false;

            entity.IsActive = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task AddAsync(ModelHouseDto dto)
        {
            var entity = new ModelHouse
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Location = dto.Location,
                Price = dto.Price,
                IsActive = true
            };

            _context.ModelHouses.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}