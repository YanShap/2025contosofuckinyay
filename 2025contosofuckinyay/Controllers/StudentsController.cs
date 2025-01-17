﻿using _2025contosofuckinyay.Data;
using _2025contosofuckinyay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2025contosofuckinyay.Controllers
{
    public class StudentsController : Controller
    {
        public readonly SchoolContext _context;
        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>Index()
        {
            return View(await  _context.Students.ToListAsync());
 
        }

        /*
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null) 
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["currentFilter"] = searchString;
            var students = from student in _context.Students
                           select student;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(student => 
                student.LastName.Contains(searchString) || 
                student.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(student => student.LastName);
                    break;
                case "firstname_desc":
                    students = students.OrderByDescending(student => student.FirstMidName);
                    break;
                case "Date":
                    students = students.OrderByDescending(student => student.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(student => student.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(student => student.LastName);
                    break;
            }
            int pageSize = 3;
            return View(await _context.Students.ToListAsync());
        }
        */

        //createget, haarab vaatest andmed, mida create meetod vajab.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //create meetod, sisestab andmebaasi uue õpilase. insert new student into database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
