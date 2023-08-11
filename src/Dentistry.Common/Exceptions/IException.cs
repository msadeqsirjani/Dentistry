namespace Dentistry.Common.Exceptions;

public interface IException
{
      public HttpStatusCode HttpStatusCode { get; }
      public string Message { get; }
}
