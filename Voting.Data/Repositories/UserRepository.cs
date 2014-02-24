using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.UserAggregate;

namespace Voting.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private VotingContext _context;

        public UserRepository(VotingContext votingContext)
        {
            _context = votingContext;           
        }
        
        public User GetByUsername(string username)
        {
            return _context.Set<User>().Where(u => u.Name == username).SingleOrDefault();
        }

        public void Add(User user)
        {
            _context.Set<User>().Add(user);
        }
    }
}
