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

    }
}
