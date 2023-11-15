using CQRSDemo.Contracts.Events.Movies;
using MassTransit;
using Read.Context;
using Read.Context.Models;

namespace Read.Messaging.Movies.Consumers
{
    public class MovieCreatedEventConsumer : IConsumer<MovieCreatedEvent>
    {
        private readonly ReadDbContext dbContext;

        public MovieCreatedEventConsumer(ReadDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Consume(ConsumeContext<MovieCreatedEvent> context)
        {
            var movie = new Movie
            {
                Id = context.Message.Id,
                BoxOffice = context.Message.BoxOffice,
                IsAdultMovie = context.Message.IsAdultMovie,
                Name = context.Message.Name
            };
            await dbContext.Movies.InsertOneAsync(movie);
        }
    }
}
