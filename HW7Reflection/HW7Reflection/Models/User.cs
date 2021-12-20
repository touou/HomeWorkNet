using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace HW7Reflection.Models
{
    public class User
    {
        [StringLength(15)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        
        [Display(Name ="pass")]
        public string Password { get; set; }
        
        [Display(Name = "Male or Female")]
        public Gender _Gender { get; set; }
    }

    public enum Gender
    {
        Female,
        Male,
    }
}