using Homework.Domain.Models.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Domain.Models
{
    public class ShoppingCart
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int TotalPrice{ get; set; }
        [Required]
        public AppUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public virtual Order Order { get; set; }
        [Required]
        public Guid OrderId { get; set; }

        public virtual List<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
    }
}
