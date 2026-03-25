using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerraAcquire.Contracts.Users
{
    public interface IUserService : IService
    {
        List<UserDto>? GetUsers();

        UserDto? GetUserByEmail(string? emailAddress = null);
    }
}
