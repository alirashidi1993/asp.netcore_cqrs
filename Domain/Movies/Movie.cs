using CQRSDemo.Contracts.Events.Movies;
using Framework.Core.Messaging;
using Framework.Domain;

namespace Domain.Movies
{
    public class Movie : BaseEntity
    {
        public Movie(string name, Guid directorId, long boxOffice, bool isAdultMovie, IEventPublisher eventPublisher)
        {
            Name = name;
            DirectorId = directorId;
            BoxOffice = boxOffice;
            IsAdultMovie = isAdultMovie;
            eventPublisher.Publish(new MovieCreatedEvent(Id, name, directorId, boxOffice, isAdultMovie));
        }
        private Movie() { }
        public string Name { get; set; }
        public Guid DirectorId { get; set; }
        public long BoxOffice { get; set; }
        public bool IsAdultMovie { get; set; }

    }
}
