using System.Collections.Generic;

namespace _2025contosofuckinyay.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int credits { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
