using PhoneBook.Domain.Contrants.Common;
using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Infrastucture.DataLayer.Common
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity, new()
    {

        private readonly PhoneBookContext db;
        public BaseRepository(PhoneBookContext db)
        {
            this.db = db;
        }

        public TEntity Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = new TEntity()
            {
                Id = id,
            };
            db.Remove(entity);
            db.SaveChanges();
        }

        public TEntity Find(int id)
        {
           return db.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> List()
        {
           return db.Set<TEntity>().AsQueryable();
        }
    }
}
