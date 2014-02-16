using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;

namespace Voting.Data.Configurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            #region Associations

            this.HasMany(question => question.Options).WithRequired().HasForeignKey(option => option.QuestionId);

            #endregion
        }
    }
}
