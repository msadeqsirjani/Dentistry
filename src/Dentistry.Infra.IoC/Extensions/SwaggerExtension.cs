namespace Dentistry.Infra.IoC.Extensions;

public static class SwaggerExtension
{
      public static IServiceCollection AddSwagger(this IServiceCollection services)
      {
            services.AddSwaggerGen(options =>
            {
                  options.SwaggerDoc("docs", new OpenApiInfo
                  {
                        Title = "Dentistry API",
                        Version = "v1"
                  });

                  options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                  {
                        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer xxx'",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer"
                  });

                  options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });

                  const string xmlFile = "Dentistry.xml";
                  var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                  options.IncludeXmlComments(xmlPath);
            });

            return services;
      }
}