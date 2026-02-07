using ExpensesTracker.Infrastructure.Extensions;
using Microsoft.OpenApi.Models;
using ExpensesTracker.Application.Extensions;

namespace ExpensesTracker.Api.Extensions;

public static class PresentationCollectionExtensions
{
    public static void AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => //code to add the JWT authentication in Swagger is constant for all projects
        {
            // Add JWT Bearer definition
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your valid JWT token.\nExample: Bearer eyJhbGciOiJIUzI1NiIs..."
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
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngular", policy =>
            {
                policy.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200");
            });
        });
    }
}
