
namespace Dentistry.Infra.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
      #region Constructor

      protected readonly ApplicationDbContext Context;

      public UnitOfWork(ApplicationDbContext context)
      {
            Context = context;
      }

      #endregion

      public void Dispose()
      {
            Context.Dispose();
      }

      public void SaveChanges()
      {
            Context.SaveChanges();
      }

      public void BeginTransaction()
      {
            Context.Database.BeginTransaction();
      }

      public void CommitTransaction()
      {
            Context.Database.CommitTransaction();
      }

      public void RollbackTransaction()
      {
            Context.Database.RollbackTransaction();
      }
}
