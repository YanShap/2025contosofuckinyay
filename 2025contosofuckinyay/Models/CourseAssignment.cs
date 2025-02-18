using System.ComponentModel.DataAnnotations;

namespace _2025contosofuckinyay.Models
{
    public class CourseAssignment
    {
        [Key]
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }


    }
}