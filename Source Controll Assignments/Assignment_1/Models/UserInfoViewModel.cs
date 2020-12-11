using System;
using System.ComponentModel.DataAnnotations;


namespace source_control_assignment1.Models
{
    public class UserInfoViewModel
    {
        [Required(ErrorMessage="Please Enter Your Mail!")]
        [Display(Name="Email")]
        [EmailAddress(ErrorMessage="Please Enter Your Mail!")]
        public string Email {get; set;}

        [Required(ErrorMessage="Please Enter password!")]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string Password {get; set;}

        [Required(ErrorMessage="Please Verify Password!")]
        [Display(Name="Confirm Password")]
        [Compare("Password", ErrorMessage="Confirm Password Doesn't Match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get; set;}

        [Required(ErrorMessage="Please Enter Birth Date!")]
        [CustomDateValidator(ErrorMessage="Birth Date Cannot Be Future Date!")]
        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate {get; set;}

        [Required(ErrorMessage="Please Enter Number!")]
        [Range(0, 100, ErrorMessage="Age Must Be Between 0 and 100")]
        [Display(Name="Favorite Number")]
        public int FavoriteNumber {get; set;}

        [Required(ErrorMessage="Please Enter Name!")]
        [Display(Name="Name")]
        public string Name {get; set;}

        [Required(ErrorMessage="Please Enter FormatedID!")]
        [RegularExpression("^[A-D]{2}[0-9]{3}")]
        [Display(Name="Formated ID")]
        public String FormatedID {get; set;}
    }
}



