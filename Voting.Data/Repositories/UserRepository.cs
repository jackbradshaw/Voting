using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.UserAggregate;

namespace Voting.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IVotingContext votingContext)
        {
            _context = votingContext;
            _rootDbSet = _context.Users;
        }
    }
}
