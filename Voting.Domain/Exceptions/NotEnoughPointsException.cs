using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Domain.Exceptions
{
    public class NotEnoughPointsException : Exception
    {
        public int UserPoints { get; private set; }

        public int RequiredPoints { get; private set; }

        public NotEnoughPointsException() : base() { }

        public NotEnoughPointsException(int userPoints, int requiredPoints)
        {
            UserPoints = userPoints;
            RequiredPoints = requiredPoints;
        }

        public override string Message
        {
            get
            {
                return String.Format("User has {0} points, they require {1} points.", UserPoints, RequiredPoints);
            }
        }
    }
}
