using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Models;

namespace NetCoreLastLabDemoWithRepositoryAndCodeFirstApproach.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly StudentManagmentSystemDB _context;

        public StudentCoursesController(StudentManagmentSystemDB context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            var studentManagmentSystemDB = _context.StudentCourses.Include(s => s.Course).Include(s=>s.Student);
            return View(await studentManagmentSystemDB.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId,Degree")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", studentCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", studentCourse.StudentId);
            return View(studentCourse);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", studentCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", studentCourse.StudentId);
            return View(studentCourse);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,CourseId,Degree")] StudentCourse studentCourse)
        {
            if (id != studentCourse.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseExists(studentCourse.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", studentCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", studentCourse.StudentId);
            return View(studentCourse);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses
                .Include(s => s.Course.Name)
                .Include(s => s.Student.Name)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourse = await _context.StudentCourses.FindAsync(id);
            _context.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
            return _context.StudentCourses.Any(e => e.CourseId == id);
        }
    }
}
