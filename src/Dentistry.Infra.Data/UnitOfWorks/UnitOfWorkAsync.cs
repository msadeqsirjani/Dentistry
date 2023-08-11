namespace Dentistry.Infra.Data.UnitOfWorks;

public class UnitOfWorkAsync : UnitOfWork, IUnitOfWorkAsync
{
      public UnitOfWorkAsync(ApplicationDbContext context) : base(context)
      {
      }

      public ValueTask DisposeAsync()
      {
            return Context.DisposeAsync();
      }

      public Task SaveChangesAsync(CancellationToken cancellationToken = default)
      {
            return Context.SaveChangesAsync(cancellationToken);
      }

      public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
      {
            return Context.Database.BeginTransactionAsync(cancellationToken);
      }

      public Task CommitTransactionAsync(CancellationToken cancellationToken = default)
      {
            return Context.Database.CommitTransactionAsync(cancellationToken);
      }

      public Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
      {
            return Context.Database.RollbackTransactionAsync(cancellationToken);
      }
}
