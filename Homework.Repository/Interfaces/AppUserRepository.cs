using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Repository.Interfaces
{
    public interface AppUserRepository
    {
        List<AppUser> FindAll();
        AppUser FindById(string id);
        void CreateNewUser(AppUser user);
        void EditUser(string id);
        AppUser FindByEmail(string email);
    }
}
