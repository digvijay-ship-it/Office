using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Office.DataAccess.Repository.IRepository;

namespace Office.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            _DepartmentRoleRepository = new DepartmentRoleRepository(_db);
            _EmpRepository = new EmpRepository(_db);
            workReportRepository = new WorkReportRepository(_db);
            userRoleRepository = new UserRoleRepository(_db);
        }

        public IDepartmentRoleRepository _DepartmentRoleRepository { get; private set; }
        public IEmpRepository _EmpRepository { get; private set; }
        public IWorkReportRepository workReportRepository { get; private set; }
        public IUserRoleRepository userRoleRepository { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}