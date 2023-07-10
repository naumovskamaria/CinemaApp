using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homework.Domain.Models;
using Homework.Repository;
using Homework.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace Homework.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly TicketService _ticketService;
        private readonly MovieService _movieService;
        private readonly ShoppingCartService _shoppingCartService;
        private readonly OrderService _orderService;
        private readonly AppUserService _appUserService;

        public TicketsController(ApplicationDbContext context, TicketService ticketService, MovieService movieService, ShoppingCartService shoppingCartService, OrderService orderService, AppUserService appUserService)
        {
            _context = context;
            _ticketService = ticketService;
            _movieService = movieService;
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
            _appUserService = appUserService;
        }



        // GET: Tickets
        public IActionResult Index(DateTime date)
        {
            ViewData["movies"] = new SelectList(this._movieService.FindAll());
            if (date.Year == 1)
            {
                return View(this._ticketService.FindAll());
            }
            else
            {
                return View(this._ticketService.FilterByDate(date));
            }
        }

        // GET: Tickets/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = this._ticketService.FindById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["movies"] = new SelectList(this._movieService.FindAll());

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_movieService.FindAll(), "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create([Bind("Id,MovieId,Quantity,Price,DateFrom,DateTo")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Id = Guid.NewGuid();
                _ticketService.Create(ticket.Id, ticket.Quantity, ticket.Price, ticket.DateFrom, ticket.DateTo);
                return RedirectToAction(nameof(Index));
            }

            ViewData["MovieId"] = new SelectList(_movieService.FindAll(), "Id", "Name", ticket.MovieId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = this._ticketService.FindById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["movieId"] = new SelectList(this._movieService.FindAll(), "id", "name", ticket.MovieId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(Guid id, [Bind("Id,MovieId,Quantity,Price,DateFrom,DateTo")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketService.Update(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_ticketService.FindById(ticket.Id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_movieService.FindAll(), "Id", "Name", ticket.MovieId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.FindById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["movies"] = new SelectList(_movieService.FindAll());
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tickets'  is null.");
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
          return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}