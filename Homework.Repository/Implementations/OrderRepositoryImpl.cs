using Homework.Domain.Models;
using Homework.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Repository.Implementations
{
    public class OrderRepositoryImpl : OrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> orders;

        public OrderRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            orders = context.Set<Order>();
        }

        public Order CreateOrder()
        {
            Order order = new Order();
            orders.Add(order);
            context.SaveChanges();
            return order;
        }

        public Order FindById(Guid id)
        {
            return orders.SingleOrDefaultAsync(o => o.Id == id).Result;
        }
    }
}
