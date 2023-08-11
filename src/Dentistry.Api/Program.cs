public class Program
{
      [Obsolete]
      private static void Main(string[] args)
      {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddServices(builder.Configuration);

            var app = builder.Build();

            app.UseApplications(app.Configuration);

            app.Run();
      }
}