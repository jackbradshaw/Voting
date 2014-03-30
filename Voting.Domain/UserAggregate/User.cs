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

        protected User() { }

        public User(string name)
        {
            Id = Guid.NewGuid();
            Points = 5;
            Name = name;
        }

        #endregion

        #region Public Methods

        public void AwardPoints(int numberOfPoints)
        {
            if (numberOfPoints < 0) throw new ArgumentException("Number of Points cannot be negative.");

            Points += numberOfPoints;
        }

        public bool ChargePoints(int numberOfPoints)
        {           
            if (numberOfPoints < 0) throw new ArgumentException("Number of Points cannot be negative.");

            //Make sure the User has enough points to spend:
            if (Points < numberOfPoints) return false;

            Points -= numberOfPoints;
            return true;
        }

        #endregion
    }
}
