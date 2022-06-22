using System.ComponentModel.DataAnnotations;

namespace SMSystem.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Duration { get; set; }

        public List<Enrollment>Enrollments { get; set; }=new List<Enrollment>();
    }
}
