using Homework.Domain.Models;
using Homework.Repository.Interfaces;
using Homework.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Implementations
{
    public class ShoppingCartServiceImpl : ShoppingCartService
    {
        private readonly ShoppingCartRepository _shoppingCartRepository;
        private readonly AppUserRepository _appUserRepository;
        private readonly OrderRepository _orderRepository;

        public ShoppingCartServiceImpl(ShoppingCartRepository shoppingCartRepository, AppUserRepository appUserRepository, OrderRepository orderRepository)
        {
            this._shoppingCartRepository = shoppingCartRepository;
            this._appUserRepository = appUserRepository;
            this._orderRepository = orderRepository;
        }

        public ShoppingCart CreateShoppingCart(string userId, Guid orderId)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                OrderId = orderId,
                Order = _orderRepository.FindById(orderId),
                User = _appUserRepository.FindById(userId)
            };

            return _shoppingCartRepository.CreateShoppingCart(shoppingCart);
        }

        public ShoppingCart FindByUserId(string userId)
        {
            return _shoppingCartRepository.FindByUserId(userId);
        }

        public void UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCart != null)
            {
                _shoppingCartRepository.UpdateShoppingCart(shoppingCart);
            }
        }
    }
}
