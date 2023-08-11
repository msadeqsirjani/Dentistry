using AssemblyReference = Dentistry.Infra.Data.AssemblyReference;

namespace Dentistry.Infra.IoC.Extensions;

public static class RepositoryExtensions
{
      public static IServiceCollection AddRepositories(this IServiceCollection services)
      {
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyReference>()
                .AddClasses(classes => classes.AssignableTo(typeof(ITransient)))
                .AsImplementedInterfaces()
                .AsSelf()
                .WithTransientLifetime());

            return services;
      }
}
