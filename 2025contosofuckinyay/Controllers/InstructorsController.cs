using _2025contosofuckinyay.Data;
using _2025contosofuckinyay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace _2025contosofuckinyay.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;
        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id,int? courseid)
        {
            var vm = new InstructorIndexData();
            vm.Instructors= await _context.Instructors.AsNoTracking().OrderBy(i=>i.LastName).ToListAsync();
            if(id != null)
            {
                ViewData["InstructorId"] = id.Value;
                Instructor instructor = vm.Instructors.Where(i => i.Id == id.Value).Single();

            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int ID)
        {

            if (ID == null)
            {
                return NotFound();
            }
            var Instructor = _context.Instructors.FirstOrDefault(s => s.Id == ID);
            if (Instructor == null)
            {
                return NotFound();
            }
            return View(Instructor);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var Instructor = await _context.Instructors.FirstOrDefaultAsync(s => s.Id == ID);
            if (Instructor == null)
            {
                return NotFound();
            }
            return View(Instructor);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ID)
        {
            var Instructor = await _context.Instructors.FindAsync(ID);
            _context.Instructors.Remove(Instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
    }
