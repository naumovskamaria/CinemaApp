using Homework.Domain.Models.Relations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Domain.Models
{
    public class Ticket
    {
        [Required]
        public Guid Id { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        public Guid MovieId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
         [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        public virtual ICollection<TicketInShoppingCart>? TicketInShoppingCarts { get; set; }
    }
}
