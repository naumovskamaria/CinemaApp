using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Interfaces
{
    public interface TicketService
    {
        List<Ticket> FindAll();
        Ticket FindById(Guid id);
        void Create(Guid id, int quantity, int price, DateTime validFrom, DateTime validTo);
        void Update(Ticket ticket);
        void Delete(Guid id);
        void AddToShoppingCart(Ticket ticket, int quantity, ShoppingCart shoppingCart);
        List<Ticket> FilterByDate(DateTime date);
    }
}
