using MediatR;

namespace Application.Contracts.Movies
{
    public class CreateMovieCommand : IRequest
    {
        public string Name { get; set; }
        public Guid DirectorId { get; set; }
        public long BoxOffice { get; set; }
        public bool IsAdultMovie { get; set; }
    }
}
