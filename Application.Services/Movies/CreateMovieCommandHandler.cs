using Application.Contracts.Movies;
using Domain.Movies;
using Framework.Core.Messaging;
using Framework.Core.Persistence;
using Framework.Persistence;
using MediatR;

namespace Application.Services.Movies
{
    public class CreateMovieCommandHandler:IRequestHandler<CreateMovieCommand>
    {
        private readonly BaseDbContext dbContext;
        private readonly IEventPublisher eventPublisher;

        public CreateMovieCommandHandler(IDbContext dbContext,IEventPublisher eventPublisher)
        {
            this.dbContext = dbContext as BaseDbContext;
            this.eventPublisher = eventPublisher;
        }

        public async Task Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = new Movie(request.Name, request.DirectorId, request.BoxOffice, request.IsAdultMovie,eventPublisher);

            dbContext.Set<Movie>().Add(movie);
        }
    }
}
