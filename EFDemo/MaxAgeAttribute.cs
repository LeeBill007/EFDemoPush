using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class MaxAgeAttribute : ValidationAttribute
    {
        public int Age { get; set; }

        public MaxAgeAttribute(int age)
        {
            this.Age = age;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int maxAge = Convert.ToInt32(value);
            if (this.Age > maxAge) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
}