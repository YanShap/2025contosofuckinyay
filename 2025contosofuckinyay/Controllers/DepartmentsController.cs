using System.Linq;
using System.Threading.Tasks;
using _2025contosofuckinyay.Data;
using _2025contosofuckinyay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;

namespace _2025contosofuckinyay.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;
        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(s => s.Administrator);
            return View(await schoolContext.ToListAsync());

        }
        [HttpGet]
        public IActionResult Create() 
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName");
            return View(); 
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Budget,OpeningDate,Address,OpenTime,Description,ShortName,InstructorID,RowVersion,Administrator")]Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName");
            return View(department);


        }
        [HttpGet]
        public async Task<IActionResult> Details(int ID)
        {

            if (ID == null)
            {
                return NotFound();
            }
            var department = _context.Departments.FirstOrDefault(s => s.Id == ID);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        public async Task<IActionResult> Delete(int ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FirstOrDefaultAsync(s => s.Id == ID);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ID)
        {
            var department = await _context.Departments.FindAsync(ID);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var Departments = await _context.Departments.FirstOrDefaultAsync(s => s.Id == ID);
            if (Departments == null)
            {
                return NotFound();
            }
            return View(Departments);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Budget,OpeningDate,Address,OpenTime,Description,ShortName,InstructorID,RowVersion,Administrator")] Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", department);
        }
        [HttpGet]
        public async Task<IActionResult> BaseOn(int ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var Departments = await _context.Departments.FirstOrDefaultAsync(s => s.Id == ID);
            if (Departments == null)
            {
                return NotFound();
            }
            return View(Departments);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BaseOn([Bind("Id,Name,Budget,OpeningDate,Address,OpenTime,Description,ShortName,InstructorID,Administrator")] Department department, string action)
        {
            if (action  == "Make") 
            {

                var newDepartment = new Department
                {
                    Name = department.Name,
                    Budget = department.Budget,
                    OpeningDate = department.OpeningDate,
                    Address = department.Address,
                    OpenTime = department.OpenTime,
                    Description = department.Description,
                    ShortName = department.ShortName,
                    InstructorID = department.InstructorID,
                    Administrator = department.Administrator
                };
                department.Id = 0;
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else if (action == "MakeAndDeleteOld")
            {
                
                var newDepartment = new Department
                {
                    Name = department.Name,
                    Budget = department.Budget,
                    OpeningDate = department.OpeningDate,
                    Address = department.Address,
                    OpenTime = department.OpenTime,
                    Description = department.Description,
                    ShortName = department.ShortName,
                    InstructorID = department.InstructorID,
                    Administrator = department.Administrator
                };

                _context.Departments.Add(newDepartment);
                var oldDepartment = await _context.Departments.FindAsync(department.Id);
                if (oldDepartment != null)
                {
                    _context.Departments.Remove(oldDepartment);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(department);
        }
    }
}
