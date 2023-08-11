namespace Dentistry.Domain.Repositories.Common;

public interface IRepositoryAsync<TEntity, in TId> : ITransient, IRepository<TEntity, TId> where TEntity : BaseEntity<TId> where TId : IComparable
{
      Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
      Task<TEntity?> FindAsync(TId id);
      Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
      Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
      Task DeleteRangeAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default);
      Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
      Task DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
      Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
      Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
      Task<TEntity?> ExecuteScalarAsync(string query, CancellationToken cancellationToken = default, params SqlParameter[] parameters);
      Task ExecuteNonQueryAsync(string query, CancellationToken cancellationToken = default, params SqlParameter[] parameters);
      Task<IEnumerable<TEntity>> ExecuteReaderAsync(string query, CancellationToken cancellationToken = default, params SqlParameter[] parameters);
      Task SaveChangesAsync(CancellationToken cancellationToken = default);
}