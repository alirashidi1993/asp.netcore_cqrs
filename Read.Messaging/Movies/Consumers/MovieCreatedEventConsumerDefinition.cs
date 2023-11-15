using MassTransit;

namespace Read.Messaging.Movies.Consumers
{
    public class MovieCreatedEventConsumerDefinition:ConsumerDefinition<MovieCreatedEventConsumer>
    {
        public MovieCreatedEventConsumerDefinition()
        {
            EndpointName = "movie-created";
            ConcurrentMessageLimit = 4;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<MovieCreatedEventConsumer> consumerConfigurator)
        {
            endpointConfigurator.UseMessageRetry(r => r.Interval(5, 2000));
        }
    }
}
