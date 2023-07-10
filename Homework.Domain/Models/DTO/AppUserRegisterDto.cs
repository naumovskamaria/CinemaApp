using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Domain.Models.DTO
{
    internal class AppUserRegisterDto
    {
        [Required]
        public string FullName { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "The password and confirm password do not match.")]
        public string PasswordConfirmation { get; set; }
    }
}