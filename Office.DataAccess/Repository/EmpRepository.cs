using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataAccess.Repository.IRepository;
using Office.Models;

namespace Office.DataAccess.Repository
{
    public class EmpRepository : Repository<Emp>, IEmpRepository
    {
        private ApplicationDbContext _db;

        public EmpRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Emp obj)
        {
            var objFromDb = _db.Employees.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.StreetAddress = obj.StreetAddress;
                objFromDb.ZipCode = obj.ZipCode;
                objFromDb.City = obj.City;
                objFromDb.state = obj.state;
                objFromDb.MobileNum = obj.MobileNum;
                objFromDb.UserRoleId = obj.UserRoleId;
                objFromDb.DepartmentRoleId = obj.DepartmentRoleId;
                if (obj.ImgUrl is not null)
                {
                    objFromDb.ImgUrl = obj.ImgUrl;
                }
            }
        }
    }
}
