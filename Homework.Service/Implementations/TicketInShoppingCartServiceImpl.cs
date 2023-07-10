using Homework.Domain.Models.Relations;
using Homework.Repository.Interfaces;
using Homework.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Implementations
{
    public class TicketInShoppingCartServiceImpl : TicketInShoppingCartService
    {
        private readonly TicketInShoppingCartRepository _ticketInShoppingCartRepository;

        public TicketInShoppingCartServiceImpl(TicketInShoppingCartRepository ticketInShoppingCartRepository)
        {
            this._ticketInShoppingCartRepository = ticketInShoppingCartRepository;
        }

        public void CreateTicketInShoppingCart(TicketInShoppingCart ticketInShoppingCart)
        {
            _ticketInShoppingCartRepository.CreateItem(ticketInShoppingCart);
        }

        public List<TicketInShoppingCart> FindTicketsInShoppingCart(Guid id)
        {
            return _ticketInShoppingCartRepository.FindAllByShoppingCartId(id);
        }
    }
}
