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
    public class MovieServiceImpl : MovieService
    {
        private readonly MovieRepository _movieRepository;

        public MovieServiceImpl(MovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void CreateNewMovie(Movie movie)
        {
            _movieRepository.CreateMovie(movie);
        }

        public List<Movie> FindAll()
        {
            return _movieRepository.FindAll();
        }

        public Movie FindById(Guid id)
        {
            return _movieRepository.FindMovieById(id);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }
    }
}
