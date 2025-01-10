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


            
        
    }
}
