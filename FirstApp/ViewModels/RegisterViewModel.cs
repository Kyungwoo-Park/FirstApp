using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "It requires to enter a field.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "It requires to enter a field.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "It requires to enter a field.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "It requires to enter a field.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password does not match the password previously entered.")]
        public string ConfirmPassword { get; set; }
    }
}
