using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Domain.Exceptions
{
    public class InvalidOptionsException : Exception
    {
        public InvalidOptionsException() : base() { }

        public override string Message
        {
            get
            {
                return String.Format("The options supplied are invalid.");
            }
        }
    }
}
