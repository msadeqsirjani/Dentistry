namespace Dentistry.Infra.Data.Configuration.Common;

public class EntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity<TId> where TId : IComparable
{
      public virtual void Configure(EntityTypeBuilder<TEntity> builder)
      {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
      }
}
