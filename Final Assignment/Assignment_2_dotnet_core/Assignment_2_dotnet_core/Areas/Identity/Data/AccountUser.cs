using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Assignment_2_dotnet_core.CustomValidators;


namespace Assignment_2_dotnet_core.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AccountUser class
    public class AccountUser : IdentityUser
    {
        [Required(ErrorMessage = "Please Enter Name!")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
