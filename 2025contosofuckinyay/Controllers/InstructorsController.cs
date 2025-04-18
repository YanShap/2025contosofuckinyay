﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var instructor = _context.Instructors.FirstOrDefault(s => s.Id == ID);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructors.FirstOrDefaultAsync(s => s.Id == ID);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ID)
        {
            var instructor = await _context.Instructors.FindAsync(ID);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var instructor = new Instructor();
            instructor.CourseAssignments = new List<CourseAssignment>();
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,LastName,FirstMidName,HireDate,OfficeAssigment,CourseAssigment,Field")] Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", instructor);
        }
        public async Task<IActionResult> Clone(int ID)
        {
            var instructor = await _context.Instructors.FirstOrDefaultAsync(s => s.Id == ID);
            if (instructor == null)
            {
                return NotFound();
            }


            var cloneInstructor = new Instructor()
            {


            };
            cloneInstructor.LastName = instructor.LastName;
            cloneInstructor.FirstMidName = instructor.FirstMidName;
            cloneInstructor.HireDate = instructor.HireDate;
            cloneInstructor.OfficeAssignment = instructor.OfficeAssignment;
            cloneInstructor.CourseAssignments = instructor.CourseAssignments;
            cloneInstructor.Field = instructor.Field;
            _context.Instructors.Add(cloneInstructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





    }
}
