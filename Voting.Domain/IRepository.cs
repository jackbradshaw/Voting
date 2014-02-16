using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Voting.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);

        List<TEntity> GetAll();

        void Add(TEntity entity);

        List<TEntity> Get(Expression<Func<TEntity, bool>> filter);
    }
}
