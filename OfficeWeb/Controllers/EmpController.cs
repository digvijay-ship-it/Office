﻿using Microsoft.AspNetCore.Authorization;
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
public class EmpController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _hostEnvironment;


    public EmpController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
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
        EmployeeVM employeeVM = new()
        {
            Employee = new(),
            DepartmentList = _unitOfWork._DepartmentRoleRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }),
            UserRoles = _unitOfWork.userRoleRepository.GetAll().Select(i => new SelectListItem
            {
                Text = i.UserRoleType,
                Value = i.Id.ToString()
            })
        };

        if (id == null || id == 0)
        {
            //create product
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CoverTypeList"] = CoverTypeList;
            return View(employeeVM);
        }
        else
        {
            employeeVM.Employee = _unitOfWork._EmpRepository.GetFirstOrDefault(u => u.Id == id);
            return View(employeeVM);
            //update product
        }


    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(EmployeeVM obj, IFormFile? file)
    {

        if (ModelState.IsValid)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"Image\Employess");
                var extension = Path.GetExtension(file.FileName);

                if (obj.Employee.ImgUrl!= null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, obj.Employee.ImgUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                obj.Employee.ImgUrl= @"\Image\Employess\" + fileName + extension;

            }
            if (obj.Employee.Id == 0)
            {
                _unitOfWork._EmpRepository.Add(obj.Employee);
            }
            else
            {
                _unitOfWork._EmpRepository.Update(obj.Employee);
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
        var EmpPropList = _unitOfWork._EmpRepository.GetAll(includeProperties: "DepartmentRole,UserRole");
        return Json(new { data = EmpPropList});
    }

    //POST
    [HttpDelete]
    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork._EmpRepository.GetFirstOrDefault(u => u.Id == id);
        if (obj == null) 
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImgUrl.TrimStart('\\'));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _unitOfWork._EmpRepository.Delete(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });

    }
    #endregion
}