using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.UserAggregate;

namespace Voting.Domain.QuestionAggregate
{

    /// <summary>
    /// A class to encapsulate the options that can be voted for a question.
    /// 
    /// An option has a key (i.e. option 1) and its value.
    /// 
    /// An option is immutable, by virtue of its interface. There is therefore no danger in
    /// exposing this value object to clients external to the Question Aggregate.
    /// </summary>
    public class Option
    {
        public Guid Id { get; private set; }

        public int Key { get; private set; }

        public string Value { get; private set; }

        public virtual IList<Vote> Votes { get; private set; }

        protected Option() { }

        public Option(int key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
            Votes = new List<Vote>();
        }

        public void VoteFor(User voter)
        {
            Vote newVote = new Vote(voter, this);
            Votes.Add(newVote);
        }
    }
}
