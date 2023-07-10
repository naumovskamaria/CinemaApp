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
    public class TicketRepositoryImpl : TicketRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Ticket> tickets;
        private readonly MovieRepository movieRepository;

        public TicketRepositoryImpl(ApplicationDbContext context, MovieRepository movieRepository)
        {
            this.context = context;
            this.tickets = context.Set<Ticket>();
            this.movieRepository = movieRepository;
        }

        public List<Ticket> FindAll()
        {
            return tickets.ToList();
        }

        public List<Ticket> FilterByDate(DateTime date)
        {
            return tickets.Where(o => o.DateFrom <= date && date <= o.DateTo).ToList();
        }

        public Ticket FindById(Guid id)
        {
            return tickets.SingleOrDefault(o => o.Id == id);
        }

        public void DecreaseQuantity(int decrement, Guid ticketId)
        {
            Ticket ticket = FindById(ticketId);
            ticket.Quantity -= decrement;
            tickets.Update(ticket);
            context.SaveChanges();
        }

        public void CreateTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("Null");
            }
            tickets.Add(ticket);
            context.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("Null");
            }
            ticket.Movie = movieRepository.FindMovieById(ticket.MovieId);
            tickets.Update(ticket);
            context.SaveChanges();
        }

        public void DeleteTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("Null");
            }
            tickets.Remove(ticket);
            context.SaveChanges();
        }
    }
}
