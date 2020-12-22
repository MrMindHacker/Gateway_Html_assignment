using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Assignment_2_dotnet_core.CustomValidators;
using Assignment_2_dotnet_core.Models;

namespace Assignment_2_dotnet_core.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Birth Date!")]
        [DateCustomValidator(ErrorMessage = "Birth Date Cannot Be Future Date!")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please Enter Favorite Number!")]
        [Range(0, 100, ErrorMessage = "Favorite Number Must Be Between 0 and 100")]
        [Display(Name = "Favorite Number")]
        public int FavoriteNumber { get; set; }

        [Required(ErrorMessage = "Please Enter ID!")]
        [RegularExpression("^[A-D]{2}[0-9]{3}", ErrorMessage = "Regular Expression Doesn't Match, format is \"AA000\"")]
        [Display(Name = "Formated ID")]
        public String FormatedID { get; set; }

        [Required(ErrorMessage = "Please Enter Phone No.!")]
        [Display(Name = "Phone No.")]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "Please Enter Profile Pic!")]
        [Display(Name = "Profile Pic")]
        [ImageCustomValidator(new string[] { ".jpg", ".png", ".png" })]
        public IFormFile ProfilePicture { get; set; }

        /*public EmployeeViewModel(Employee model)
        {
            Id = model.Id;
            Name = model.Name;
            BirthDate = model.BirthDate;
            FavoriteNumber = model.FavoriteNumber;
            FormatedID = model.FormatedID;
            MobilePhone = model.MobilePhone;
            ProfilePicture = new IFormFile();

        }*/
    }
}
