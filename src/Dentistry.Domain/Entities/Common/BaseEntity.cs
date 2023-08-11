namespace Dentistry.Domain.Entities.Common;

public class BaseEntity<TKey> where TKey : IComparable
{
      public TKey Id { get; set; } = default!;
}

public class BaseEntity : BaseEntity<Guid>
{

}