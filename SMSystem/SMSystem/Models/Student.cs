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
    
        [EmailAddress]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}", ErrorMessage = "Incorrect Email Format")]

        public string Email { get; set; }

        [Required]

        [MinLength(10, ErrorMessage = "Phone Number must be of 10 digit")]
        [MaxLength(10, ErrorMessage = "Phone Number must be of 10 digit")]
        public string PhoneNo { get; set; }

        [Required]
        public string Address { get; set; }
        public List<Enrollment> Enrollments { get; set; }=new List<Enrollment>();
    }
}
