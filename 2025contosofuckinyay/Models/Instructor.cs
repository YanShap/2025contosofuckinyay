using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2025contosofuckinyay.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Last name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last name")]
        [Column("First name")]
        public string FirstMidName { get; set; }
        [Display(Name ="Full name")]
        public string FullName { get { return LastName + "," + FirstMidName; } }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}")]
        [Display(Name="Hired on")]
        public DateTime HireDate { get; set; }
        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }
        public string Field { get; set; }

    }
}
