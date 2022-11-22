using Microsoft.AspNetCore.Mvc;
using Office.DataAccess;
using Office.DataAccess.Repository;
using Office.DataAccess.Repository.IRepository;
using Office.Models;

namespace Office.Controllers
{
    public class DepartmentRoleController : Controller
    {
        public readonly IUnitOfWork _UnitOfWork;
        public DepartmentRoleController(IUnitOfWork UnitOfWork)
        //                              Getting implementation of DepartmentRoleRepository
        {
            _UnitOfWork = UnitOfWork;
        }

        //-----------------------
        
        public IActionResult Index()
        {
            IEnumerable<DepartmentRole> ObjdepartmentRolesList = _UnitOfWork._DepartmentRoleRepository.GetAll();
            return View(ObjdepartmentRolesList);
        }

        //-----------------------
        //get create
        public IActionResult Create()
        {
            return View();
        }
        //Post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentRole obj)
        {
            if(ModelState.IsValid)
            {
                _UnitOfWork._DepartmentRoleRepository.Add(obj);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //-----------------------
        //get edit
        public IActionResult Edit(int? id)
        {
            if (id == null||id==0)
            {
                return NotFound();
            }
            var DepartmentFromDbFirst = _UnitOfWork._DepartmentRoleRepository.GetFirstOrDefault(x => x.Id==id);

            if (DepartmentFromDbFirst==null)
            {
                return NotFound();
            }
            return View(DepartmentFromDbFirst);
        }

        //post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DepartmentRole obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork._DepartmentRoleRepository.Update(obj);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        //-----------------------
        //Get Delete
        public IActionResult Delete(int? id)
        {
            if (id is null|| id==0)
            {
                return NotFound();
            }

            var DepartmentFromDbFirst = _UnitOfWork._DepartmentRoleRepository.GetFirstOrDefault(u => u.Id == id);
            if(DepartmentFromDbFirst is null)
            {
                return NotFound();
            }
            return View(DepartmentFromDbFirst);
        }

        //Post delete
        [HttpPost]
        public IActionResult Delete(DepartmentRole obj)
        {
            _UnitOfWork._DepartmentRoleRepository.Delete(obj);
            _UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
