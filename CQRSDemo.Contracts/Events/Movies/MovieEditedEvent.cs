namespace CQRSDemo.Contracts.Events.Movies
{
    public class MovieEditedEvent : BaseEvent
    {
        public MovieEditedEvent(
            Guid id,
            string name,
            Guid directorId,
            long boxOffice,
            bool isAdultMovie) : base(nameof(MovieEditedEvent))
        {
            Id = id;
            Name = name;
            DirectorId = directorId;
            BoxOffice = boxOffice;
            IsAdultMovie = isAdultMovie;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid DirectorId { get; }
        public long BoxOffice { get; }
        public bool IsAdultMovie { get; }
        protected override object BuildEventData()
        {
            return new
            {
                Id,
                Name,
                DirectorId,
                BoxOffice,
                IsAdultMovie
            };
        }
    }
}
