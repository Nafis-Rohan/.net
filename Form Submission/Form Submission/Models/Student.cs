using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form_Submission.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$")]
        public string Id { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Za-z ]+$")]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^\S+$")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}@aiub\.edu$", ErrorMessage = "Email must be in format xx-xxxxx-x@aiub.edu")]
        [EmailValidation]
        public string Email { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Address { get; set; }

        [Required]
        [DobValidation(18)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Profession { get; set; }

        [Required]
        public string[] Hobbies { get; set; }
    }
}