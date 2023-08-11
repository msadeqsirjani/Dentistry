using Microsoft.AspNetCore.Builder;
using Dentistry.Infra.IoC.Middleware;
using AssemblyReference = Dentistry.Application.AssemblyReference;

namespace Dentistry.Infra.IoC;

public static class DependencyContainer
{
      [Obsolete]
      public static void AddServices(this IServiceCollection services, IConfiguration configuration)
      {
            services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                  options.InvalidModelStateResponseFactory = context =>
                  {
                        var result = context.ModelState.Values.SelectMany(x => x.Errors).First().ErrorMessage;

                        return new BadRequestObjectResult(new Response<string> { Result = false, Message = result });
                  };
            });

            services.AddFluentValidation(options => options.RegisterValidatorsFromAssembly(typeof(AssemblyReference).GetTypeInfo().Assembly));

            services.AddOptions();

            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                  options.UseSqlServer();
            });

            services.AddEndpointsApiExplorer();
      }

      public static void UseApplications(this WebApplication application, IConfiguration configuration)
      {

            application.UseMiddleware<ExceptionHandlerMiddleware>();

            application.UseAuthentication();
            application.UseAuthorization();

            application.Use(async (context, next) =>
            {
                  context.Response.Headers.Add("Permissions-Policy", "camera=(), microphone=()");
                  await next.Invoke();
            });

            var showSwagger = configuration.GetValue<bool>("ShowSwagger");

            if (showSwagger)
            {
                  application.UseSwagger();

                  application.UseSwaggerUI(options =>
                  {
                        options.DocumentTitle = "Rayvarz Dentistry API Documentation";
                        options.RoutePrefix = "docs";
                        var swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
                        options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/docs/swagger.json", "Rayvarz Dentistry API");
                  });
            }

            application.UseCors("CorsPolicy");

            application.MapControllers();
      }
}