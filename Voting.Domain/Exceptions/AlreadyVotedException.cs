using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Domain.Exceptions
{
    public class AlreadyVotedException : Exception
    {
        public AlreadyVotedException() : base() { }

        public override string Message
        {
            get
            {
                return String.Format("User has already voted for this question.");
            }
        }
    }
}
