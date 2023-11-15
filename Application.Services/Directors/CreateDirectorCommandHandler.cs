using Application.Contracts.Directors;
using Domain.Directors;
using Framework.Core.Persistence;
using Framework.Persistence;
using MediatR;

namespace Application.Services.Directors
{
    public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand>
    {
        private readonly BaseDbContext dbContext;

        public CreateDirectorCommandHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext as BaseDbContext;
        }
        public async Task Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var director = new Director(request.Name, request.Rating);

            dbContext.Set<Director>().Add(director);
        }
    }
}
