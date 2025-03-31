using _2025contosofuckinyay.Data;
using _2025contosofuckinyay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace _2025contosofuckinyay.Controllers
{
    public class StudentsController : Controller
    {
        public readonly SchoolContext _schoolContext;
        public StudentsController()
        {
            
        }
        public StudentsController(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task<IActionResult>Index()
        {
            var result = _schoolContext.Students.ToList();

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstMidName,EnrollmentDate")]Student student)
        {
            
            if (ModelState.IsValid)
            {
                _schoolContext.Students.Add(student);
                await _schoolContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var student = await _schoolContext.Students.FirstOrDefaultAsync(s=>s.Id == ID);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);

        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>DeleteConfirmed(int ID)
        {
            var student = await _schoolContext.Students.FindAsync(ID);
            _schoolContext.Students.Remove(student);
            await _schoolContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult>Details(int ID)
        {

            if (ID == null)
            {
                return NotFound();
            }
            var student = _schoolContext.Students.FirstOrDefault(s => s.Id == ID);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);

            

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var student = _schoolContext.Students.FirstOrDefault(s => s.Id == ID);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            _schoolContext.Students.Update(student);
            await _schoolContext.SaveChangesAsync();
            return RedirectToAction("Index", student);
        }
        public async Task<IActionResult> Clone(int ID)
        {
            var student = _schoolContext.Students.FirstOrDefault(s => s.Id == ID);
            if (student == null)
            {
                return NotFound();
            }


            var CloneStudent = new Student
            {
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,
            };
            _schoolContext.Students.Add(CloneStudent);
            await _schoolContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }









    }
}
