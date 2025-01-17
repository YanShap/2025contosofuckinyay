using System.ComponentModel.DataAnnotations;

namespace _2025contosofuckinyay.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; } 
        public DateTime EnrollmentDate { get; set; }
    }
}
