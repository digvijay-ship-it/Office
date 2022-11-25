using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataAccess.Repository.IRepository;
using Office.Models;

namespace Office.DataAccess.Repository
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private ApplicationDbContext _db;
        public UserRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserRole obj)
        {
            _db.UserRole.Update(obj);
        }
    }
}
