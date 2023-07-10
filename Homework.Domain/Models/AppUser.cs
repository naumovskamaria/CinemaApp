using Homework.Domain.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Domain.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public UserRole Role { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
