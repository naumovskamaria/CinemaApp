using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Interfaces
{
    public interface ShoppingCartService
    {
        ShoppingCart CreateShoppingCart(string userId, Guid orderId);
        ShoppingCart FindByUserId(string userId);
        void UpdateShoppingCart(ShoppingCart shoppingCart);
    }
}
