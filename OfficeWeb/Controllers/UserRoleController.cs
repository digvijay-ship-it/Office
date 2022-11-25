using Microsoft.AspNetCore.Mvc;
using Office.DataAccess;
using Office.DataAccess.Repository;
using Office.DataAccess.Repository.IRepository;
using Office.Models;

namespace Office.Controllers
{
    public class UserRoleController : Controller
    {
        public readonly IUnitOfWork _UnitOfWork;
        public UserRoleController(IUnitOfWork UnitOfWork)
        //                              Getting implementation of DepartmentRoleRepository
        {
            _UnitOfWork = UnitOfWork;
        }

        //-----------------------
        
        public IActionResult Index()
        {
            IEnumerable<UserRole>? UserRolesList = _UnitOfWork.userRoleRepository.GetAll();
            return View(UserRolesList);
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
        public IActionResult Create(UserRole obj)
        {
            if(ModelState.IsValid)
            {
                _UnitOfWork.userRoleRepository.Add(obj);
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
            var UserRoleFromDb = _UnitOfWork.userRoleRepository.GetFirstOrDefault(x => x.Id==id);

            if (UserRoleFromDb == null)
            {
                return NotFound();
            }
            return View(UserRoleFromDb);
        }

        //post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserRole obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.userRoleRepository.Update(obj);
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

            var RoleFromDbFirst = _UnitOfWork.userRoleRepository.GetFirstOrDefault(u => u.Id == id);
            if(RoleFromDbFirst is null)
            {
                return NotFound();
            }
            return View(RoleFromDbFirst);
        }

        //Post delete
        [HttpPost]
        public IActionResult Delete(UserRole obj)
        {
            _UnitOfWork.userRoleRepository.Delete(obj);
            _UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
