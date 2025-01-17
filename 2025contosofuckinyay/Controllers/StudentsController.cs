using _2025contosofuckinyay.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2025contosofuckinyay.Controllers
{
    public class StudentsController : Controller
    {
        public readonly SchoolContext _schoolContext;
        public StudentsController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task<IActionResult>Index()
        {
            var result = await  _schoolContext.Students.ToListAsync();

            return View(result);
        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        //Clone code block
        public async Task<IActionResult> Clone(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            var ClonedStudent = new Student
            {
                FirstName = student.FirstName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,
            };
            _context.Students.Add(ClonedStudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


            
        
    }
}
