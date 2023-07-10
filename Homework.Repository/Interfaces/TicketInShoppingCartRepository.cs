using Homework.Domain.Models.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Repository.Interfaces
{
    public interface TicketInShoppingCartRepository
    {
        void CreateItem(TicketInShoppingCart ticketInShoppingCart);
        List<TicketInShoppingCart> FindAllByShoppingCartId(Guid id);
    }
}
