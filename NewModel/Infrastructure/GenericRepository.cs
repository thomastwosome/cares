using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace NewModel.Infrastructure
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DataContext Cxt;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(DataContext cxt)
        {
            Cxt = cxt;
            DbSet = cxt.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        //public virtual TEntity GetByUserId(object userId)
        //{
        //    TEntity query = DbSet;
        //    query = query.Where()
        //    return DbSet.Where(q=>q.)
        //}

        public virtual bool Insert(TEntity entity)
        {
            var result = Validate(entity);
            if (result)
            {
                DbSet.AddOrUpdate(entity);
            }
            return true;
        }

        //public virtual void Insert(TEntity entity)
        //{
        //    DbSet.Add(entity);
        //}

        public virtual void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Cxt.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual bool Update(TEntity entityToUpdate)
        {
            var result = Validate(entityToUpdate);
            if (result)
            {
                DbSet.Attach(entityToUpdate);
                Cxt.Entry(entityToUpdate).State = EntityState.Modified;
            }
            return result;
        }

        //internal void Insert(ERMHSLev3NPSResViewModel report)
        //{
        //    throw new NotImplementedException();
        //}

        //public virtual void Update(TEntity entityToUpdate)
        //{
        //    DbSet.Attach(entityToUpdate);
        //    Cxt.Entry(entityToUpdate).State = EntityState.Modified;
        //}

        public virtual bool Validate(TEntity entity)
        {
            // TODO: Perform other validation logic here
            // This is for any validation not accomplished
            // using the data annotations on the Product class

            return true;
        }
    }
}
