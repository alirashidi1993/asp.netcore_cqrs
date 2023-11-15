using Framework.Core.Persistence;
using MediatR;

namespace Framework.Persistence
{
    public class UnitOfWorkBehavior<Trequest, TResponse> : IPipelineBehavior<Trequest, TResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(Trequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                var response = await next();
                unitOfWork.Commit();
                return response;
            }
            catch
            {
                throw;
            }
            finally
            {
                unitOfWork.Dispose();
            }
        }
    }
}
