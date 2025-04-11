using System;
using System.Linq;
using _2025contosofuckinyay.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2025contosofuckinyay.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student {FirstMidName = "Artur", LastName = "Petrovski", EnrollmentDate = DateTime.Parse("2069-04-20")},
                new Student {FirstMidName = "Ruuben", LastName = "Rosin", EnrollmentDate = DateTime.Parse("2009-05-21")},
                new Student {FirstMidName = "Marko", LastName = "Vasiljev", EnrollmentDate = DateTime.Parse("2007-09-25")},
                new Student {FirstMidName = "Allan", LastName = "Lond", EnrollmentDate = DateTime.Parse("2054-12-31")},
                new Student {FirstMidName = "Matis", LastName = "Rannaveer", EnrollmentDate = DateTime.Parse("2007-09-30")}, 
                new Student {FirstMidName = "Souen", LastName = "Paju", EnrollmentDate = DateTime.Parse("2001-03-25")},
                new Student {FirstMidName = "Artjem", LastName = "Skatchkov", EnrollmentDate = DateTime.Parse("2021-05-01")}, 
                new Student {FirstMidName = "Hendry", LastName = "Gutsky", EnrollmentDate = DateTime.Parse("2012-01-23")},
                new Student {FirstMidName = "Timofey", LastName = "Polja", EnrollmentDate = DateTime.Parse("2010-02-07")},
                new Student {FirstMidName = "Aleksander", LastName = "Bogaslov", EnrollmentDate = DateTime.Parse("1999-03-16")},
            };



        }
    }
}
