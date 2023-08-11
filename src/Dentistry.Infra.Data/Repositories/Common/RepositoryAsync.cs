using Microsoft.Data.SqlClient;

namespace Dentistry.Infra.Data.Repositories.Common;

public class RepositoryAsync<TEntity, TId> : Repository<TEntity, TId>, IRepositoryAsync<TEntity, TId>
    where TEntity : BaseEntity<TId>, new() where TId : IComparable
{
      protected RepositoryAsync(ApplicationDbContext context) : base(context)
      {
      }
      public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
          CancellationToken cancellationToken = default)
      {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);
      }

      public async Task<TEntity?> FindAsync(TId id)
      {
            return await DbSet.FindAsync(id);
      }

      public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
      {
            DbSet.AddAsync(entity, cancellationToken);

            return Task.CompletedTask;
      }

      public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
      {
            DbSet.AddRangeAsync(entities, cancellationToken);

            return Task.CompletedTask;
      }

      public Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
      {
            DbSet.RemoveRange(entities);

            return Task.CompletedTask;
      }

      public Task DeleteRangeAsync(IEnumerable<TId> ids, CancellationToken cancellationToken = default)
      {
            return DeleteRangeAsync(x => ids.Contains(x.Id), cancellationToken);
      }

      public async Task DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
      {
            var entities = await Queryable(predicate).ToListAsync();

            DbSet.RemoveRange(entities);
      }

      public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
      {
            return DbSet.AnyAsync(predicate, cancellationToken);
      }

      public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
      {
            return DbSet.CountAsync(predicate, cancellationToken);
      }

      public async Task<TEntity?> ExecuteScalarAsync(string query, CancellationToken cancellationToken = default,
          params SqlParameter[] parameters)
      {
            var connection = Context.Database.GetDbConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            foreach (var parameter in parameters)
                  command.Parameters.Add(parameter);
            if (connection.State.Equals(ConnectionState.Closed))
                  await connection.OpenAsync(cancellationToken);
            return command.ExecuteScalarAsync(cancellationToken) as TEntity;
      }

      public Task ExecuteNonQueryAsync(string query, CancellationToken cancellationToken = default,
          params SqlParameter[] parameters)
      {
            var connection = Context.Database.GetDbConnection();
            using var command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            foreach (var parameter in parameters)
                  command.Parameters.Add(parameter);
            if (connection.State.Equals(ConnectionState.Closed))
                  connection.OpenAsync(cancellationToken);
            return command.ExecuteNonQueryAsync(cancellationToken);
      }

      public async Task<IEnumerable<TEntity>> ExecuteReaderAsync(string query, CancellationToken cancellationToken = default,
          params SqlParameter[] parameters)
      {
            var connection = Context.Database.GetDbConnection();
            await using var command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;
            foreach (var parameter in parameters)
                  command.Parameters.Add(parameter);
            if (connection.State.Equals(ConnectionState.Closed))
                  await connection.OpenAsync(cancellationToken);
            var values = await command.ExecuteReaderAsync(cancellationToken);

            List<TEntity> entities = new();

            while (await values.ReadAsync(cancellationToken))
            {
                  TEntity entity = new();

                  for (var i = 0; i < values.FieldCount; i++)
                  {
                        var type = entity.GetType();
                        var property = type.GetProperty(values.GetName(i));
                        property?.SetValue(entity, values.GetValue(i), null);
                  }

                  entities.Add(entity);
            }

            return entities;
      }

      public T? ExecuteSqlFunction<T>(string functionName, params SqlParameter[] parameters)
      {
            var connectionString = Context.Database.GetConnectionString();
            using (SqlConnection connection = new(connectionString))
            {
                  connection.Open();

                  using (SqlCommand command = new(functionName, connection))
                  {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null)
                        {
                              command.Parameters.AddRange(parameters);
                        }

                        var result = command.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                              return default;

                        return (T)Convert.ChangeType(result, typeof(T));
                  }
            }
      }

      public T? ExecuteSqlFunction2<T>(string functionName, params SqlParameter[] parameters)
      {
            var connectionString = Context.Database.GetConnectionString();

            using SqlConnection connection = new(connectionString);

            connection.Open();

            using SqlCommand command = new($"SELECT {functionName}({string.Join(",", parameters.Select(p => "@" + p.ParameterName))})", connection);

            if (parameters != null && parameters.Length > 0)
            {
                  command.Parameters.AddRange(parameters);
            }

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                  return reader.IsDBNull(0) ? default : reader.GetFieldValue<T>(0);
            }
            else
            {
                  return default;
            }
      }

      public Task SaveChangesAsync(CancellationToken cancellationToken = default)
      {
            return Context.SaveChangesAsync(cancellationToken);
      }

      public ValueTask DisposeAsync()
      {
            return Context.DisposeAsync();
      }
}
