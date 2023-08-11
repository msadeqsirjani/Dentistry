namespace Dentistry.Domain.Repositories.Common;

public interface IRepository<TEntity, in TId> : ITransient, IDisposable where TEntity : BaseEntity<TId> where TId : IComparable
{
      IQueryable<TEntity> Queryable(bool enableTracking = true);
      IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate, bool enableTracking = true);
      TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
      TEntity? Find(TId id);
      void Add(TEntity entity);
      void AddRange(IEnumerable<TEntity> entities);
      void Update(TEntity entity);
      void UpdateRange(IEnumerable<TEntity> entities);
      void Attach(TEntity entity);
      void AttachRange(IEnumerable<TEntity> entities);
      void Delete(TEntity entity);
      void DeleteRange(IEnumerable<TId> ids);
      void DeleteRange(Expression<Func<TEntity, bool>> predicate);
      bool Exists(Expression<Func<TEntity, bool>> predicate);
      int Count(Expression<Func<TEntity, bool>> predicate);
      TEntity? ExecuteScalar(string query, params DbParameter[] parameters);
      void ExecuteNonQuery(string query, params DbParameter[] parameters);
      IEnumerable<TEntity> ExecuteReader(string query, params DbParameter[] parameters);
      void SaveChanges();
}