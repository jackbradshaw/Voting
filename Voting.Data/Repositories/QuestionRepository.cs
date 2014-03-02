using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;
using System.Data.Entity;

namespace Voting.Data.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private VotingContext _context;

        public QuestionRepository(VotingContext votingContext)
        {
            _context = votingContext;            
        }
        
        public Question GetById(Guid id)
        {
            return _context.Questions
                .Include(q => q.Options.Select(o => o.Votes))
                .Where(q => q.Id == id)
                .SingleOrDefault();
        }

        public void Add(Question question)
        {
            _context.Questions.Add(question);
        }

        public List<Question> GetAll()
        {
            return _context.Questions.ToList();
        }
    }
}
