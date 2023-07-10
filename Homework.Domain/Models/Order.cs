using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Domain.Models
{
    public class Order
    {
        [Required]
        public Guid Id { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
