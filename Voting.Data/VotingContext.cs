using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Data.Configurations;
using Voting.Domain.QuestionAggregate;
using Voting.Domain.UserAggregate;

namespace Voting.Data
{
    public class VotingContext : DbContext, IVotingContext
    {
        public VotingContext()
            : base("VotingData")
        { }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Question> Questions { get; set; }
        public IDbSet<Vote> Votes { get;  set; }
        public IDbSet<Option> Options { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new VoteConfiguration());
        }
    }
}
