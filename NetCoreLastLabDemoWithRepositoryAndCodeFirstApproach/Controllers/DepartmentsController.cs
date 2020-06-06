using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models;
using NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Repository;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Controllers
{
    public class DepartmentsController : Controller
    {
        DepartmentManger departmentManger;

        public DepartmentsController(DepartmentManger departmentManger)
        {
           this.departmentManger =departmentManger;
        }

       
        public IActionResult Index()
        {
            return View(departmentManger.GetAll());
        }

      
        public IActionResult Details(int id)
        {
            Department department = departmentManger.GetById(id);
            return View(department);
        }

       
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
              if(departmentManger.Add(department))
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

     
        public IActionResult Edit(int id)
        {


            Department department = departmentManger.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               if(departmentManger.Update(department))
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

      
        public IActionResult Delete(int id)
        {
            Department department = departmentManger.GetById(id);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if(departmentManger.Remove(id))
                 return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Delete), new { id });
        }

      
    }
}
