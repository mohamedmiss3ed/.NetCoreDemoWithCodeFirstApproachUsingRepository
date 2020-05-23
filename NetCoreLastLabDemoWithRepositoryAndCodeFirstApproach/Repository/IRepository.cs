using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        bool Add(TEntity Entity);
        bool Remove(int id);

        bool Update(TEntity Entity);

    }
}
