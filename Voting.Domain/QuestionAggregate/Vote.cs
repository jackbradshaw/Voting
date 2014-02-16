using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.UserAggregate;

namespace Voting.Domain.QuestionAggregate
{
    public class Vote
    {
        #region Properties

        public Guid Id { get; private set; }

        public Guid VoterId { get; private set; }

        public virtual User Voter { get; private set; }        

        public Guid OptionId { get; private set; }

        public virtual Option Option { get; private set; }

        #endregion

        #region Constructor 

        public Vote() { }

        public Vote(User voter, Option option)
        {
            Id = Guid.NewGuid();
            Voter = voter;         
            Option = option;
        }

        #endregion
    }
}
