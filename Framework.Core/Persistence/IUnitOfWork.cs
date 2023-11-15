namespace Framework.Core.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}
