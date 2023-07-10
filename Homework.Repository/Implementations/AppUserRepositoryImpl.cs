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
    public class AppUserRepositoryImpl : AppUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<AppUser> users;

        public AppUserRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            this.users = context.Set<AppUser>();
        }

        public void CreateNewUser(AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Null");
            }
            this.users.Add(user);
            this.context.SaveChanges();
        }

        public void EditUser(string id)
        {
            AppUser user = this.FindById(id);
            if (user == null)
            {
                throw new ArgumentNullException("Null");
            }
            this.users.Update(user);
            this.context.SaveChanges();
        }

        public AppUser FindByEmail(string email)
        {
            return users.SingleOrDefault(el => el.Email == email);
        }

        public AppUser FindById(string id)
        {
            return users.SingleOrDefaultAsync(el => el.Id == id).Result;
        }

        public List<AppUser> FindAll()
        {
            return this.users.ToList();
        }
    }
}
