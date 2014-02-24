using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;
using Voting.Domain.UserAggregate;

namespace Voting.Data.Configurations
{
    class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {           
            this.HasMany(question => question.Options).WithRequired();
        }
    }

    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
           
        }
    }

    class VoteConfiguration : EntityTypeConfiguration<Vote>
    {
        public VoteConfiguration()
        {
            this.HasKey(vote => new { vote.VoterId, vote.OptionId });

            this.HasRequired(vote => vote.Option).WithMany(option => option.Votes).HasForeignKey(vote => vote.OptionId);

            this.HasRequired(vote => vote.Voter).WithMany().HasForeignKey(vote => vote.VoterId);       
        }
    }
}
