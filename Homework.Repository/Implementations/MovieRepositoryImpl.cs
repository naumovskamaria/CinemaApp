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
    public class MovieRepositoryImpl : MovieRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Movie> movies;

        public MovieRepositoryImpl(ApplicationDbContext context)
        {
            this.context = context;
            this.movies = context.Set<Movie>();
        }

        public void CreateMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException("Null");
            }
            movies.Add(movie);
            context.SaveChanges();
        }

        public List<Movie> FindAll()
        {
            return movies.ToList();
        }

        public Movie FindMovieById(Guid id)
        {
            return movies.SingleOrDefaultAsync(el => el.Id == id).Result;
        }

        public void UpdateMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException("Null");
            }
            movies.Update(movie);
            context.SaveChanges();
        }
    }
}
