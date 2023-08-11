namespace Dentistry.Domain.UnitOfWorks;

public interface IUnitOfWorkAsync : ITransient, IUnitOfWork, IAsyncDisposable
{
      Task SaveChangesAsync(CancellationToken cancellationToken = default);
      Task BeginTransactionAsync(CancellationToken cancellationToken = default);
      Task CommitTransactionAsync(CancellationToken cancellationToken = default);
      Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
