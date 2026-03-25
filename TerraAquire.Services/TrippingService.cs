using TerraAcquire.Contracts.Trippings;
using TerraAcquire.EntityFramework;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TerraAcquire.EntityFramework.Models;

namespace TerraAcquire.Services
{
    public class TrippingService : ITrippingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TrippingService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void SaveTripping(TrippingDto tripping)
        {
            var entity = _mapper.Map<TrippingSchedule>(tripping);
            _context.TrippingSchedules.Add(entity);
            _context.SaveChanges();
        }

        public List<TrippingDto> GetAllTrippings()
        {
            return _context.TrippingSchedules
                .Select(t => _mapper.Map<TrippingDto>(t))
                .ToList();
        }

        public List<TrippingDto> GetTrippingsByCustomer(Guid customerId)
        {
            return _context.TrippingSchedules
                .Where(t => t.CustomerId == customerId)
                .Select(t => _mapper.Map<TrippingDto>(t))
                .ToList();
        }

        public List<TrippingDto> GetTrippingsByAgent(Guid agentId)
        {
            return _context.TrippingSchedules
                .Where(t => t.AgentId == agentId)
                .Select(t => _mapper.Map<TrippingDto>(t))
                .ToList();
        }
    }
}