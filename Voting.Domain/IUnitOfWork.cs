using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain.QuestionAggregate;
using Voting.Domain.UserAggregate;

namespace Voting.Domain
{
    public interface IUnitOfWork
    {
        IQuestionRepository QuestionRepository { get; }

        IUserRepository UserRepository { get; }

        void Save();

        void Dispose();
    }
}
