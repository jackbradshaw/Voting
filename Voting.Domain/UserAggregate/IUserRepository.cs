using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Domain.UserAggregate
{
    public interface IUserRepository
    {
        User GetByUsername(string username);

        void Add(User user);
    }
}
