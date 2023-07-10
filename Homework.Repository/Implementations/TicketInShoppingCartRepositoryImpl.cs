using Homework.Domain.Models.Relations;
using Homework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Repository.Implementations
{
    public class TicketInShoppingCartRepositoryImpl : TicketInShoppingCartRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<TicketInShoppingCart> items;

        public TicketInShoppingCartRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            this.items = context.Set<TicketInShoppingCart>();
        }

        public void CreateItem(TicketInShoppingCart ticketInShoppingCart)
        {
            if (ticketInShoppingCart == null)
            {
                throw new ArgumentNullException("Null");
            }
            items.Add(ticketInShoppingCart);
            context.SaveChanges();
        }

        public List<TicketInShoppingCart> FindAllByShoppingCartId(Guid id)
        {
            return items.ToList().FindAll(o => o.ShoppingCartId == id);
        }
    }
}
