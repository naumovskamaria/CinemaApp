using Homework.Domain.Models.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Interfaces
{
    public interface TicketInShoppingCartService
    {
        void CreateTicketInShoppingCart(TicketInShoppingCart ticketInShoppingCart);
        List<TicketInShoppingCart> FindTicketsInShoppingCart(Guid id);
    }
}
