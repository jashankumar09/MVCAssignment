using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMSystem.Data;
using SMSystem.Models;

namespace SMSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EnrollmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var studentManagementSystemDbContext = _db.Enrollments.Include(e => e.Course).Include(e => e.Student);
            return View(await studentManagementSystemDbContext.ToListAsync());
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_db.Courses, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_db.Students, "Id", "Name");
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,CourseId,StudentId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _db.Add(enrollment);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_db.Courses, "Id", "Name", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_db.Students, "Id", "Name", enrollment.StudentId);
            return View(enrollment);
        }

        // Get
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _db.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_db.Courses, "Id", "Name", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_db.Students, "Id", "Name", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(enrollment);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
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
            ViewData["CourseID"] = new SelectList(_db.Courses, "Id", "Name", enrollment.CourseId);
            ViewData["StudentID"] = new SelectList(_db.Students, "Id", "Name", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Enrollments == null)
            {
                return NotFound();
            }

            var enrollment = await _db.Enrollments
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Enrollments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Enrollments'  is null.");
            }
            var enrollment = await _db.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _db.Enrollments.Remove(enrollment);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return (_db.Enrollments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}