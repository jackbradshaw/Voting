using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;
using Voting.Domain.UserAggregate;

namespace Voting.Data
{
    public interface IVotingContext : IDisposable
    {
        IDbSet<User> Users { get; }
        IDbSet<Question> Questions { get; }
        IDbSet<Vote> Votes { get; }
        IDbSet<Option> Options { get; }

        int SaveChanges();
    }
}
