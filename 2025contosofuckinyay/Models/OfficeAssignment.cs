using System.ComponentModel.DataAnnotations;

namespace _2025contosofuckinyay.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int Id { get; set; }
        public int InstructorId { get; set; }
        [Display(Name="Office location")]
        [StringLength(50)]
        public string Location { get; set; }
    }
}