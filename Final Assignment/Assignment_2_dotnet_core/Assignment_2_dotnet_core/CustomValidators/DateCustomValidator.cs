using System;
using System.ComponentModel.DataAnnotations;


namespace Assignment_2_dotnet_core.CustomValidators
{
    public class DateCustomValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime <= DateTime.Now;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
