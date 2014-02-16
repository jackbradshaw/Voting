using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Voting.Domain;
using System.Linq.Expressions;

namespace Voting.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IVotingContext _context;
        protected IDbSet<TEntity> _rootDbSet;

        public TEntity GetById(Guid id)
        {
            return _rootDbSet.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _rootDbSet.ToList();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return _rootDbSet.Where(filter).ToList();
        }

        public void Add(TEntity entity)
        {
            _rootDbSet.Add(entity);
        }
    }
}
