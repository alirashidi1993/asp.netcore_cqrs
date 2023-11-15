using Framework.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Framework.Persistence
{
    public class BaseDbContext : DbContext,IDbContext
    {
        public BaseDbContext(DbContextOptions options):base(options)
        {
            
        }
        
    }
}