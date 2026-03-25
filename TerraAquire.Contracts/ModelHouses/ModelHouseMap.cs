using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraAcquire.Contracts.ModelHouses;
using TerraAcquire.EntityFramework.Models;



namespace TerraAquire.Contracts.ModelHouses
{

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ModelHouse, ModelHouseDto>();
            CreateMap<ModelHouseDto, ModelHouse>();
        }
    }
}
