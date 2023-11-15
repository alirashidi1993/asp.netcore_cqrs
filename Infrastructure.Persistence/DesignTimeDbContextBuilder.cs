using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence
{
    public class DesignTimeDbContextBuilder : IDesignTimeDbContextFactory<WriteDbContext>
    {
        public WriteDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WriteDbContext>();
            builder.UseSqlServer("server=localhost;database=CQRSDemo;trusted_connection=true;");

            return new WriteDbContext(builder.Options);
        }
    }
}
