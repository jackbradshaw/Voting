using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Domain;
using Voting.Domain.QuestionAggregate;
using Voting.Domain.UserAggregate;

namespace Voting.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IVotingContext _content;

        public UnitOfWork(IVotingContext context, IQuestionRepository questionRepository, IUserRepository userRepository)
        {
            _content = context;
            QuestionRepository = questionRepository;
            UserRepository = userRepository;
        }

        public IQuestionRepository QuestionRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public void Save()
        {
            _content.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _content.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
