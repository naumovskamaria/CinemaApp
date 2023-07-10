using Homework.Domain.Models;
using Homework.Domain.Models.Relations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homework.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // THIS CODE IS USED BECAUSE OF AN ERROR WHEN CREATING SCAFFOLDED ITEM :((( :)))
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //}

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TicketInShoppingCart> TicketInShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticket>()
                .Property(el => el.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(el => el.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Order>()
                .Property(el => el.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Movie>()
                .Property(el => el.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Ticket>()
                .HasOne<Movie>(el => el.Movie)
                .WithOne(el => el.Ticket)
                .HasForeignKey<Ticket>(el => el.MovieId);

            builder.Entity<ShoppingCart>()
                 .HasOne<AppUser>(el => el.User)
                 .WithOne(el => el.ShoppingCart)
                 .HasForeignKey<ShoppingCart>(el => el.UserId);

            builder.Entity<ShoppingCart>()
                .HasOne<Order>(el => el.Order)
                .WithOne(el => el.ShoppingCart)
                .HasForeignKey<ShoppingCart>(el => el.OrderId);

            builder.Entity<TicketInShoppingCart>()
                .HasOne(el => el.Ticket)
                .WithMany(el => el.TicketInShoppingCarts)
                .HasForeignKey(el => el.TicketId);

            builder.Entity<TicketInShoppingCart>()
                .HasOne(el => el.ShoppingCart)
                .WithMany(el => el.TicketInShoppingCarts)
                .HasForeignKey(el => el.ShoppingCartId);
        }
    }
}