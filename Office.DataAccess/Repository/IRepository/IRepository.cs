using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Office.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProperties = null);
        void Add(T entity);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter,string? includeProperties=null);
        void Delete(T entity);

    }
}
