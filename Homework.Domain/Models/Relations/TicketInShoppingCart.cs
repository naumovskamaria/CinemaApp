using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Domain.Models.Relations
{
    public class TicketInShoppingCart
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        [Required]
        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
