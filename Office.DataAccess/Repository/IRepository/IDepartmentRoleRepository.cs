using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.Models;

namespace Office.DataAccess.Repository.IRepository
{
    public interface IDepartmentRoleRepository:IRepository<DepartmentRole>
    {
        void Update(DepartmentRole Obj);
    }
}
