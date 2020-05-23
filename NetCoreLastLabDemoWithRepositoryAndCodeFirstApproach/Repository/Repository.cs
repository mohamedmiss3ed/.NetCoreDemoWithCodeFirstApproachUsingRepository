using Microsoft.EntityFrameworkCore;
using NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
         private StudentManagmentSystemDB db;
        private DbSet<TEntity> set;

        public Repository(StudentManagmentSystemDB _db)
        {
            db = _db;
            set = db.Set<TEntity>();
           

            
        }
        public bool Add(TEntity Entity)
        {
            set.Add(Entity);

            return db.SaveChanges() > 0;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return set;
        }

        public TEntity GetById(int id)
        {
            return set.Find(id);
        }

        public bool Remove(int id)
        {
            set.Remove(set.Find(id));

            return db.SaveChanges() > 0;
        }

        public bool Update(TEntity Entity)
        {
            set.Attach(Entity);
            db.Entry(Entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}