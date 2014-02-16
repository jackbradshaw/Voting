using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;

namespace Voting.Data.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(IVotingContext votingContext)
        {
            _context = votingContext;
            _rootDbSet = _context.Questions;
        }
    }
}
