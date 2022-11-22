using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Office.DataAccess.Repository.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Office.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.Employees.Include(u => u.DepartmentRole);
            //_db.WorkReports.Include(u => u.Emp);
            _dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> quary = _dbSet;
            if(includeProperties != null)
            {
                foreach(var includeProp in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    quary = quary.Include(includeProp);
                }
            }
            return quary.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
    }
}
