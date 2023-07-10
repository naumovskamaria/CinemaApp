using Homework.Domain.Models;
using Homework.Domain.Models.Relations;
using Homework.Repository.Interfaces;
using Homework.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Implementations
{
    public class TicketServiceImpl : TicketService
    {
        private readonly TicketRepository _ticketRepository;
        private readonly MovieService _movieService;
        private readonly TicketInShoppingCartService _ticketInShoppingCartService;
        private readonly ShoppingCartService _shoppingCartService;

        public TicketServiceImpl(TicketRepository ticketRepository, MovieService movieService, TicketInShoppingCartService ticketInShoppingCartService, ShoppingCartService shoppingCartService)
        {
            _ticketRepository = ticketRepository;
            _movieService = movieService;
            _ticketInShoppingCartService = ticketInShoppingCartService;
            _shoppingCartService = shoppingCartService;
        }

        public void AddToShoppingCart(Ticket ticket, int quantity, ShoppingCart shoppingCart)
        {
            TicketInShoppingCart ticketInShoppingCart = new TicketInShoppingCart()
            {
                Id = Guid.NewGuid(),
                TicketId = ticket.Id,
                Ticket = ticket,
                ShoppingCartId = shoppingCart.Id,
                ShoppingCart = shoppingCart,
                Quantity = quantity,
                Price = ticket.Price * quantity

            };

            _ticketInShoppingCartService.CreateTicketInShoppingCart(ticketInShoppingCart);
        }

        public void Create(Guid id, int quantity, int price, DateTime validFrom, DateTime validTo)
        {
            Movie movie = _movieService.FindById(id);
            Ticket ticket = new Ticket()
            {
                MovieId = id,
                Movie = movie,
                Quantity = quantity,
                Price = price,
                DateFrom = validFrom,
                DateTo = validTo
            };

            _ticketRepository.CreateTicket(ticket);
        }

        public void Delete(Guid id)
        {
            _ticketRepository.DeleteTicket(FindById(id));
        }

        public List<Ticket> FilterByDate(DateTime date)
        {
            return _ticketRepository.FilterByDate(date);
        }

        public List<Ticket> FindAll()
        {
            return _ticketRepository.FindAll();
        }

        public Ticket FindById(Guid id)
        {
            return _ticketRepository.FindById(id);
        }

        public void Update(Ticket ticket)
        {
            _ticketRepository.UpdateTicket(ticket);
        }
    }
}
