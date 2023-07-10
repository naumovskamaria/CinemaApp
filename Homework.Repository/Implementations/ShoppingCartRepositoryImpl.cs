using Homework.Domain.Models;
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
    public class ShoppingCartRepositoryImpl : ShoppingCartRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ShoppingCart> shoppingCarts;
        private DbSet<TicketInShoppingCart> ticketInShoppingCarts;

        public ShoppingCartRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            this.shoppingCarts = context.Set<ShoppingCart>();
            this.ticketInShoppingCarts = context.Set<TicketInShoppingCart>();
        }

        public void AddToShoppingCart(ShoppingCart shoppingCart, Ticket ticket, int quantity)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart CreateShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException("Null");
            }
            shoppingCarts.Add(shoppingCart);
            context.SaveChanges();
            return shoppingCart;
        }

        public List<TicketInShoppingCartRepository> FindAll(Guid id)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart FindByUserId(string userId)
        {
            return shoppingCarts.SingleOrDefault(o => o.UserId == userId);
        }

        public void UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException("Null");
            }
            shoppingCarts.Update(shoppingCart);
            context.SaveChanges();
        }
    }
}
