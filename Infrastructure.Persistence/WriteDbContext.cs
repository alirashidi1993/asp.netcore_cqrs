using Framework.Persistence;
using Infrastructure.Persistence.Mappings.Movies;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class WriteDbContext : BaseDbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieMapping).Assembly);
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
        }
    }
}
