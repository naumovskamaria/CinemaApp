using Homework.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Repository.Interfaces
{
    public interface MovieRepository
    {
        void CreateMovie(Movie movie);
        List<Movie> FindAll();
        Movie FindMovieById(Guid id);
        void UpdateMovie(Movie movie);
    }
}
