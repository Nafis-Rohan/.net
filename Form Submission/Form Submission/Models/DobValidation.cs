using System;
using System.ComponentModel.DataAnnotations;

namespace Form_Submission.Models
{
    public class DobValidation : ValidationAttribute
    {
        private readonly int _minAge;
        public DobValidation(int minAge)
        {
            _minAge = minAge;
            ErrorMessage = $"Age must be greater than {_minAge}.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                var age = DateTime.Today.Year - date.Year;
                if (date > DateTime.Today.AddYears(-age)) age--;
                return age > _minAge;
            }
            return false;
        }
    }
}