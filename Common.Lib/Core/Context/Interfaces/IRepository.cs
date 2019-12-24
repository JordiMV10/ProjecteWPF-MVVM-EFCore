using Common.Lib.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Lib.Core.Context.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> QueryAll();

        T Find(Guid id);

        SaveResult<T> Add(T entity);

        SaveResult<T> Update(T entity);

        SaveResult<T> Delete(T entity);
    }
}
