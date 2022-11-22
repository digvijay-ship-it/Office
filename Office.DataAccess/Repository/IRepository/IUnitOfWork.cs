using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IDepartmentRoleRepository _DepartmentRoleRepository { get; }
        IEmpRepository _EmpRepository { get; }
        IWorkReportRepository workReportRepository { get; }
        void Save();
    }
}
