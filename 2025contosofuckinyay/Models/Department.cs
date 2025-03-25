using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2025contosofuckinyay.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50,MinimumLength = 3)]
        public string Name { get; set; }
        [Column(TypeName="Money")]
        public string Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime OpeningDate { get; set; }
        public string Address {  get; set; }
        public string OpenTime { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public int? InstructorID { get; set; }
        public byte? RowVersion { get; set; }
        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
        
        

    }
}
