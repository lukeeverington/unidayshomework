using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniDaysHomework.Services
{
    public interface IUserService
    {
        CreateUserResult Create(CreateUserParameters parameters);
    }
}
