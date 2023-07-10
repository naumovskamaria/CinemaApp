using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Repository.Interfaces
{
    public interface OrderRepository
    {
        Order CreateOrder();
        Order FindById(Guid id);
    }
}
