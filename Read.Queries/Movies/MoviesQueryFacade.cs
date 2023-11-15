using MongoDB.Driver;
using Read.Context;
using Read.Context.Models;

namespace Read.Queries.Movies
{
    public class MoviesQueryFacade
    {
        private readonly ReadDbContext readDbContext;

        public MoviesQueryFacade(ReadDbContext readDbContext)
        {
            this.readDbContext = readDbContext;
        }

        public List<Movie> GetMovies()
        {
            var movies = readDbContext.Movies.Find(Builders<Movie>.Filter.Empty).ToList();
            return movies;
        }
    }
}
