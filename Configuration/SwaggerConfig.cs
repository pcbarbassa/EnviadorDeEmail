using Microsoft.OpenApi.Models;

namespace PCB.EnviadorDeEmail.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AdicionarSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API de Envio de Emails ",                    
                    Contact = new OpenApiContact() { Name = "Paulo Barbassa", Email = "paulobarbassa@live.com" },
                    License = new OpenApiLicense() { Name = "Licença Opensource MIT", Url = new Uri("https://opensource.org/licences/MIT") }
                });

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Scheme = "Authorization",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            return services;
        }
    }
}
