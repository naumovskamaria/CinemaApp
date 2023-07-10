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
    public class OrderServiceImpl : OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderServiceImpl(OrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public Order CreateOrder()
        {
            return _orderRepository.CreateOrder();
        }
    }
}
