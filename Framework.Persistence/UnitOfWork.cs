using Framework.Core.Persistence;

namespace Framework.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext dbContext;
        public UnitOfWork(IDbContext dbContext)
        {
            this.dbContext = dbContext as BaseDbContext;
        }


        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext?.Dispose();
        }


    }
}
