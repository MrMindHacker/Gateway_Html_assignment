using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Assignment_2_dotnet_core.CustomValidators;

namespace Assignment_2_dotnet_core.Models
{
    public class Employee
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

        [ImageCustomValidator(new string[] { ".jpg", ".png", ".png" })]
        [Required(ErrorMessage = "Please Enter Profile Pic!")]
        [Display(Name = "Profile Pic")]
        public string ProfilePicture { get; set; }

        public Employee()
        {
            BirthDate = DateTime.UtcNow.Date;
            FavoriteNumber = 0;
            FormatedID = null;
            MobilePhone = null;
            ProfilePicture = null;
        }

        public Employee(int id, string name, DateTime birthDate, int favoriteNumber, string formatedID, string mobilePhone, string profilePicture)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BirthDate = birthDate;
            FavoriteNumber = favoriteNumber;
            FormatedID = formatedID ?? throw new ArgumentNullException(nameof(formatedID));
            MobilePhone = mobilePhone ?? throw new ArgumentNullException(nameof(mobilePhone));
            ProfilePicture = profilePicture;
        }
    }
}
