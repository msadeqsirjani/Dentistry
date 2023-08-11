namespace Dentistry.Infra.IoC.Extensions;

public static class ServiceExtension
{
      public static IServiceCollection AddServices(this IServiceCollection services)
      {
            services.Scan(scan => scan
                .FromAssemblyOf<Application.AssemblyReference>()
                .AddClasses(classes => classes.AssignableTo(typeof(ITransient)))
                .AsImplementedInterfaces()
                .AsSelf()
                .WithTransientLifetime());

            return services;
      }
}
