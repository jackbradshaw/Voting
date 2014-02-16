using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;

namespace Voting.Data.Configurations
{
    public class VoteConfiguration : EntityTypeConfiguration<Vote>
    {
        public VoteConfiguration()
        {
            #region Associations

            this.HasRequired(vote => vote.Option).WithMany(option => option.Votes).HasForeignKey(vote => vote.OptionId);

            this.HasRequired(vote => vote.Voter).WithMany().HasForeignKey(vote => vote.VoterId).WillCascadeOnDelete(false);

            #endregion
        }
    }
}
