using System;
using System.ComponentModel.DataAnnotations;

namespace Form_Submission.Models
{
    public class EmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Step 1: Cast the object to Student
            Student obj = validationContext.ObjectInstance as Student;

            // Step 2: Check for null
            if (obj == null)
            {
                return new ValidationResult("Invalid object.");
            }

            // Step 3: Convert the email value to string
            string email = value != null ? value.ToString() : null;

            if (string.IsNullOrEmpty(email))
            {
                return new ValidationResult("Email is required.");
            }

            string[] parts = email.Split('@');

            if (parts.Length != 2)
            {
                return new ValidationResult("Email format is invalid.");
            }

            string emailPrefix = parts[0];

            // Step 6: Compare prefix with ID
            if (emailPrefix == obj.Id)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Email prefix must match your ID.");
            }
        }
    }
}
