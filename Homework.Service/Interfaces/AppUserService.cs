using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Interfaces
{
    public interface AppUserService
    {
        AppUser FindByEmail(string email);
        Boolean CheckIfUserHaveShoppingCart(AppUser user);
        List<AppUser> FindAll();
    }
}
