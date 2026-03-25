using AutoMapper;
using TerraAcquire.EntityFramework.Models;


namespace TerraAcquire.Contracts.Users
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
