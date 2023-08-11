namespace Dentistry.Common.Exceptions;

public class ForbiddenException : Exception, IException
{
      public HttpStatusCode HttpStatusCode { get; }
      public ForbiddenException() : base(Statement.ForbiddenMessage)
      {
            HttpStatusCode = HttpStatusCode.Forbidden;
      }

      public ForbiddenException(string message) : base(message)
      {
            HttpStatusCode = HttpStatusCode.Forbidden;
      }
}