using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Domain.QuestionAggregate
{
    public interface IQuestionRepository
    {
        Question GetById(Guid id);

        void Add(Question question);

        List<Question> GetAll();
    }
}
