using Homework.Domain.Models;
using Homework.Repository.Interfaces;
using Homework.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Implementations
{
    public class AppUserServiceImpl : AppUserService
    {
        private readonly AppUserRepository _appUserRepository;
        private readonly ShoppingCartService _shoppingCartService;

        public AppUserServiceImpl(AppUserRepository appUserRepository, ShoppingCartService shoppingCartService)
        {
            _appUserRepository = appUserRepository;
            _shoppingCartService = shoppingCartService;
        }

        public bool CheckIfUserHaveShoppingCart(AppUser user)
        {
            return _shoppingCartService.FindByUserId(user.Id) != null ? false : true;
        }

        public List<AppUser> FindAll()
        {
            return _appUserRepository.FindAll();
        }

        public AppUser FindByEmail(string email)
        {
            return _appUserRepository.FindByEmail(email);
        }
    }
}
