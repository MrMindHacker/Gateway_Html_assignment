using System;
using System.ComponentModel.DataAnnotations;

namespace source_control_assignment1.Models
{
    public class CustomDateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}