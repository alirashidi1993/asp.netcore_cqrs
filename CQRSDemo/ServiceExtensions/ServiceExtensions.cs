using Application.Contracts.Movies;
using Application.Services.Movies;
using EventStore.Client;
using Framework.Core.EventStore;
using Framework.Core.Messaging;
using Framework.Core.Persistence;
using Framework.Messaging;
using Framework.Persistence;
using Infrastructure.Persistence;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Read.Context;
using Read.Messaging.Movies.Consumers;

namespace CQRSDemo.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void RegisterAppServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEventPublisher, EventPublisher>();
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(typeof(CreateMovieCommandHandler).Assembly);
                conf.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>), ServiceLifetime.Scoped);
            });

            services.AddMassTransit(conf =>
            {
                conf.AddConsumer<MovieCreatedEventConsumer>();
                conf.UsingRabbitMq((context, rabbitConf) =>
                {
                    rabbitConf.Host("localhost", login =>
                    {
                        login.Username("guest");
                        login.Password("guest");
                    });
                    rabbitConf.ConfigureEndpoints(context);
                    rabbitConf.AutoStart = true;
                    rabbitConf.UseMessageRetry(r => r.Interval(10, TimeSpan.FromSeconds(10)));

                });
                conf.AddEntityFrameworkOutbox<WriteDbContext>(outboxConf =>
                {
                    outboxConf.QueryMessageLimit = 1;
                    outboxConf.QueryDelay=TimeSpan.FromSeconds(5);
                    outboxConf.UseBusOutbox();
                    outboxConf.UseSqlServer();
                });

            });

            var connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<IDbContext, WriteDbContext>(conf =>
            {
                conf.UseSqlServer(connectionString);
            });

            var mongoConnectionString = configuration.GetConnectionString("MongoDb");
            services.AddSingleton(provider => new ReadDbContext(mongoConnectionString));

            var eventStoreConnectionString = configuration.GetConnectionString("EventStore");

            services.AddEventStoreClient(eventStoreConnectionString);
        }
    }
}
