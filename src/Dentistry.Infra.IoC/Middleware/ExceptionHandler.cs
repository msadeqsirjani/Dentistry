namespace Dentistry.Infra.IoC.Middleware;

public class ExceptionHandlerMiddleware
{
      private readonly RequestDelegate _next;
      private readonly IWebHostEnvironment _environment;

      public ExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment environment)
      {
            _next = next;
            _environment = environment;
      }

      public async Task Invoke(HttpContext context)
      {
            try
            {
                  await _next(context);
            }
            catch (Exception exception)
            {
                  await HandleExceptionAsync(context, exception);
            }
      }

      private Task HandleExceptionAsync(HttpContext context, Exception exception)
      {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            switch (exception)
            {
                  case IException exceptionValue:
                        {
                              context.Response.StatusCode = (int)exceptionValue.HttpStatusCode;
                              return context.Response.WriteAsync(JsonConvert.SerializeObject(new Response<IException>
                              {
                                    Message = exceptionValue.Message,
                                    Result = false
                              }).ToLower());
                        }
                  default:
                        return context.Response.WriteAsync(_environment.IsDevelopment()
                            ? JsonConvert.SerializeObject(new Response<Exception> { Value = exception, Result = false, Message = exception.Message }).ToLower()
                            : JsonConvert.SerializeObject(new Response() { Message = Statement.FailureMessage , Result = false }).ToLower());
            }
      }
}
