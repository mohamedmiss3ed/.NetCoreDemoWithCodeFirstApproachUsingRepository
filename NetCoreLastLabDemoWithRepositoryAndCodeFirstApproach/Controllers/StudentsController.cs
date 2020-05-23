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
    public class StudentsController : Controller
    {
        StudentManger studentManger;
        DepartmentManger departmentManger;
       // StudentManagmentSystemDB _context;
        public StudentsController(Repository<Student> _studentManger,Repository<Department> _departmentManger)
        {
           
            studentManger = (StudentManger)_studentManger;
            departmentManger = (DepartmentManger)_departmentManger;
        }
        

      
        public IActionResult Index()
        {


            // var studentManagmentSystemDB = _context.Students.Include(s => s.Department);
            // return View(await studentManagmentSystemDB.ToListAsync());
            return View( studentManger.GetAllStudent().ToList<Student>());
        }

   
        public  IActionResult Details(int id)
        {


            Student student = studentManger.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(departmentManger.GetAll(), "Id", "Name");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Name,Age,DepartmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                if(studentManger.Add(student))
                  return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(departmentManger.GetAll(), "Id", "Name", student.DepartmentId);
            return View(student);
        }

       
        public  IActionResult Edit(int id)
        {


            Student student = studentManger.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(departmentManger.GetAll(), "Id", "Name", student.DepartmentId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Age,DepartmentId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if(studentManger.Update(student))
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(departmentManger.GetAll(), "Id", "Name", student.DepartmentId);
            return View(student);
        }

      
        public IActionResult Delete(int id)
        {


            Student student = studentManger.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }


            return View(student);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if(studentManger.Remove(id))
                return RedirectToAction(nameof(Index));
            return  RedirectToAction(nameof(Delete),new { id});

        }

      
    }
}
