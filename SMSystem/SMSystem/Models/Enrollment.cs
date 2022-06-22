﻿using System.ComponentModel.DataAnnotations;

namespace SMSystem.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }

        public Course? Course { get; set; }

        public int StudentId { get; set; }

        public Student? Student { get; set; }


    }
}
