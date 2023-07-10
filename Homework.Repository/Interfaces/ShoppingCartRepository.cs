using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Repository.Interfaces
{
    public interface ShoppingCartRepository
    {
        List<TicketInShoppingCartRepository> FindAll(Guid id);
        void AddToShoppingCart(ShoppingCart shoppingCart, Ticket ticket, int quantity);
        ShoppingCart CreateShoppingCart(ShoppingCart shoppingCart);
        ShoppingCart FindByUserId(string userId);
        void UpdateShoppingCart (ShoppingCart shoppingCart);
    }
}
