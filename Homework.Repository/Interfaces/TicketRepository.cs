using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Repository.Interfaces
{
    public interface TicketRepository
    {
        List<Ticket> FindAll();
        List<Ticket> FilterByDate(DateTime date);
        Ticket FindById(Guid id);
        void DecreaseQuantity(int decrement, Guid ticketId);
        void CreateTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}
