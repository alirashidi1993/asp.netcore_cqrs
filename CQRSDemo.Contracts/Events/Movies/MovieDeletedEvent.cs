namespace CQRSDemo.Contracts.Events.Movies
{
    public class MovieDeletedEvent : BaseEvent
    {
        public MovieDeletedEvent(Guid movieId) : base(nameof(MovieDeletedEvent))
        {
            Id = movieId;
        }
        public Guid Id { get; }

        protected override object BuildEventData()
        {
            return new
            {
                Id
            };
        }
    }
}
