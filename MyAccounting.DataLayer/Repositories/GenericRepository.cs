using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAccounting.DataLayer.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private MyAccounting_DBEntities _db;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(MyAccounting_DBEntities db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity,bool>> where=null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (where!=null)
            {
               query = query.Where(where);
            }

            return query.ToList();
        }

        public virtual IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> query = _dbSet;

            return query.Where(where).ToList();
        }

        public virtual bool Add(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
