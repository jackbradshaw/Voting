using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Domain.UserAggregate
{
    public class User
    {
        #region Properties

        public Guid Id { get; private set; }

        public int Points { get; private set; }

        public string Name {get; private set;}

        #endregion

        #region Constructors

        public User() { }

        public User(string name)
        {
            Id = Guid.NewGuid();
            Points = 5;
            Name = name;
        }

        #endregion

        #region Public Methods

        public void GivePoints(int numberOfPoints)
        {
            Points += numberOfPoints;
        }

        public bool ChargePoints(int numberOfPoints)
        {
            //Make sure the User has enough points to spend:
            if (Points < numberOfPoints) return false;

            Points -= numberOfPoints;
            return true;
        }

        #endregion
    }
}
