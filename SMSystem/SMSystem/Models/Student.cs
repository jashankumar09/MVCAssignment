using System.ComponentModel.DataAnnotations;

namespace SMSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public string Address { get; set; }
        public List<Enrollment> Enrollments { get; set; }=new List<Enrollment>();
    }
}
