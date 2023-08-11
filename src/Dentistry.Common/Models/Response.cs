namespace Dentistry.Common.Models;

public class Response
{
      public bool? Result { get; set; }
      public string? Message { get; set; }
}
public class Response<T> : Response
{
      public T? Value { get; set; }
}
