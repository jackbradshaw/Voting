using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.Exceptions;
using Voting.Domain.UserAggregate;

namespace Voting.Domain.QuestionAggregate
{
    public class Question
    {
        #region Properties

        public static int REWARD_FOR_VOTING = 1;

        public static int PRICE_FOR_ASKING = 5;

        public Guid Id { get; private set; }

        public string Text { get; private set; }        
       
        public User Asker {get; private set; }

        public virtual List<Option> Options { get; private set; }

        public IEnumerable<Guid> Voted
        {
            get 
            {
                return Options.SelectMany(option => option.Votes.Select(vote => vote.VoterId));
            }
        }
        
        #endregion

        #region Constructors

        //Protected Default Constructor - Required By Entity Framework 
        protected Question() { }

        public Question(string text, List<string> options, User asker)
        {
            Id = Guid.NewGuid();

            Text = text;

            Options = new List<Option>();
            if (options == null || options.Count <= 0 || options.Count > 4) throw new Exception(); //TODO exception

            for (int i = 0; i < options.Count; i++)
            {
                Options.Add(new Option(i, options[i]));
            }           
          
            Asker = asker;

            //Charge user for asking a question:
            if (!asker.ChargePoints(PRICE_FOR_ASKING))
            {
                throw new NotEnoughPointsException(asker.Points, PRICE_FOR_ASKING);
            }
        }
        
        #endregion

        #region Public Methods        

        public void Vote(User voter, int option)
        {
            // 1. Check if user has not already voted
            if (Voted.Contains(voter.Id))
            {
                throw new AlreadyVotedException();
            }
           
            // 2. Register Vote:
            var chosenOption = Options.Where(opt => opt.Key == option).Single();

            chosenOption.VoteFor(voter);

            // 3. Reward Voter for voting:
            voter.GivePoints(REWARD_FOR_VOTING);
        }

        #endregion
    }
}
