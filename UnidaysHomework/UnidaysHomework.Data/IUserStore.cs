using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidaysHomework.Data
{
    public interface IUserStore
    {
        int Create(string emailAddress, string passwordHash);
        bool UserExists(string emailAddress);
    }

    public class UserStore : IUserStore
    {
        public int Create(string emailAddress, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
