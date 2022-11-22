using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Office.DataAccess.Repository.IRepository;
using Office.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Office.Controllers;
public class WorkReportController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;


    public WorkReportController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _hostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    //GET
    public IActionResult Upsert(int? id)
    {
        WorkReportVM workreportVM= new()
        {
            WR= new(),
            EmpList= _unitOfWork._EmpRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            })
        };

        if (id == null || id == 0)
        {
            //create product
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CoverTypeList"] = CoverTypeList;
            return View(workreportVM);
        }
        else
        {
            workreportVM.WR= _unitOfWork.workReportRepository.GetFirstOrDefault(u => u.Id == id);
            return View(workreportVM);
            //update product
        }


    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(WorkReportVM obj)
    {

        if (ModelState.IsValid)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (obj.WR.Id == 0)
            {
                _unitOfWork.workReportRepository.Add(obj.WR);
            }
            else
            {
                _unitOfWork.workReportRepository.Update(obj.WR);
            }
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }



    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        var workreportlist = _unitOfWork.workReportRepository.GetAll(includeProperties: "Emp");
        return Json(new { data = workreportlist });
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.workReportRepository.GetFirstOrDefault(u => u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        _unitOfWork.workReportRepository.Delete(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}