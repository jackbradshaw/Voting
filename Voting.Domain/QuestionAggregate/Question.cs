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

        public int State { get; private set; }

        public Guid AskerId { get; private set; }

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

        //Default Constructor - Required By Entity Framework
        public Question() { }

        public Question(string question, List<string> options, User asker)
        {
            Id = Guid.NewGuid();

            Text = question;

            Options = new List<Option>();
            if (options != null)
            {
                //TODO Exception
                if (options.Count > 4) throw new Exception();
                for (int i = 0; i < options.Count; i++)
                {
                    Options.Add(new Option(i, options[i]));
                }
            }

            AskerId = asker.Id;
            Asker = asker;

            //Charge user for asking a question:
            if (!asker.ChargePoints(PRICE_FOR_ASKING))
            {
                throw new NotEnoughPointsException(asker.Points, PRICE_FOR_ASKING);
            }
        }
        
        #endregion

        #region Public Methods

        //public Option AddOption(string value)
        //{
        //    int nextOption = Options.Count() + 1;

        //    //INVARIANT: A question may have at most 4 options.
        //    if (nextOption > 4)
        //        //TODO exception
        //        throw new Exception();

        //    //Create a new Option, with next key:
        //    Option newOption = new Option(nextOption, value);

        //    //Add it to the Question's collection of options:
        //    Options.Add(newOption);

        //    return newOption;           
           
        //}

        //public void AskQuestion(User asker) 
        //{
        //    //Only the user that made the question, may ask it:
        //    if(this.Asker.Id != asker.Id)
        //    {                
        //        throw new Exception();
        //    }            
        //    if(State == (int)QuestionState.Closed)
        //    {
        //        //TODO Exception
        //        throw new Exception();
        //    }
        //    if (State == (int)QuestionState.BeingPrepared)
        //    {          
        //        //Charge user for asking a question:
        //        if (!asker.ChargePoints(PRICE_FOR_ASKING))
        //        {
        //            throw new NotEnoughPointsException(asker.Points, PRICE_FOR_ASKING);
        //        }

        //        State = (int)QuestionState.Asked;
        //    }
        //}

        //public void CloseQuestion()
        //{
        //    State = (int)QuestionState.Closed;
        //}

        public void Vote(User voter, int option)
        {
            // 1. Check if user has not already voted
            if (Voted.Contains(voter.Id))
            {
                throw new AlreadyVotedException();
            }

            //Otherwise, add vote:            
            //TODO check option exists:

            //// 2. Check question has been asked, and is still open:
            //if(State == (int)QuestionState.BeingPrepared)
            //{
            //    //TODO Exception
            //    throw new Exception();
            //}
            //if(State == (int)QuestionState.Closed)
            //{
            //    //TODO Exception
            //    throw new Exception();
            //}

            // 3. Reward Voter for voting:
            voter.GivePoints(REWARD_FOR_VOTING);

            // 4. Register Vote:
            var chosenOption = Options.Where(opt => opt.Key == option).Single();

            chosenOption.VoteFor(voter);
        }

        #endregion
    }
}
