using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Service.Interfaces
{
    public interface MovieService
    {
        List<Movie> FindAll();
        Movie FindById(Guid id);
        void CreateNewMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}
