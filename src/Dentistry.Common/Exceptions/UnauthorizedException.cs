namespace Dentistry.Common.Exceptions;

public class UnauthorizedException : Exception, IException
{
      public HttpStatusCode HttpStatusCode { get; set; }

      public UnauthorizedException() : base(Statement.UnauthorizedMessage)
      {
            HttpStatusCode = HttpStatusCode.Unauthorized;
      }

      public UnauthorizedException(string message) : base(message)
      {
            HttpStatusCode = HttpStatusCode.Unauthorized;
      }
}