using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataAccess.Repository.IRepository;
using Office.Models;

namespace Office.DataAccess.Repository
{
    public class DepartmentRoleRepository : Repository<DepartmentRole>, IDepartmentRoleRepository
    {
        private ApplicationDbContext _db;
        public DepartmentRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DepartmentRole obj)
        {
            _db.DepartmentRoles.Update(obj);
        }
    }
}
