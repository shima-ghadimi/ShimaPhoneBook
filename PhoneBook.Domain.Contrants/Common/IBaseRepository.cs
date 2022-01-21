using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Domain.Contrants.Common
{
    public interface IBaseRepository<TEntity> where TEntity: BaseEntity,new()
    {
        TEntity Add(TEntity entity);
        void Delete(int id);
        IQueryable<TEntity> List();

        TEntity Find(int id);
    }
}
