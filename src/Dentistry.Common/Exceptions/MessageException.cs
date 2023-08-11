namespace Dentistry.Common.Exceptions;

public class MessageException : Exception, IException
{
      public HttpStatusCode HttpStatusCode { get; }

      public MessageException(string message) : base(message)
      {
            HttpStatusCode = HttpStatusCode.BadRequest;
      }
}
