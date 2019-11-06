using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "It requires to enter a field.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "It requires to enter a field.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
