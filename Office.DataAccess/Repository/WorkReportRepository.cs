using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Office.DataAccess.Repository.IRepository;
using Office.Models;

namespace Office.DataAccess.Repository
{
    public class WorkReportRepository: Repository<WorkReport>, IWorkReportRepository
    {
        private ApplicationDbContext _db;
        public WorkReportRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(WorkReport obj)
        {
            _db.WorkReports.Update(obj);
        }
    }
}
