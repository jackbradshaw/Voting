using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voting.Data.Repositories;
using Voting.Domain;
using Voting.Domain.QuestionAggregate;
using Voting.Domain.UserAggregate;

namespace Voting.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private VotingContext _context;

        public UnitOfWork()
        {
            _context = new VotingContext();
            QuestionRepository = new QuestionRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public IQuestionRepository QuestionRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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
