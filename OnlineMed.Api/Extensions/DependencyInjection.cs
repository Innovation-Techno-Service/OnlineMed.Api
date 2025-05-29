using Microsoft.OpenApi.Models;
using OnlineMed.Api.ExceptionHandlers;
using OnlineMed.Api.Filters;
using System.Reflection;

namespace OnlineMed.Api.Extensions;

internal static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwagger(configuration);
        services.AddErrorHandlers();

        return services;
    }

    private static void AddErrorHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<EntityNotFoundExceptionHandler>();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
    }

    private static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Smart Assistant for Healthcare System",
                Version = "v1",
                Description = "An AI-powered assistant for healthcare professionals, providing real-time support and information.",
                Contact = new OpenApiContact
                {
                    Name = "Support Engineer",
                    Email = "shukhratovich75@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/license/mit/")
                }
            });

            c.OperationFilter<ValidationErrorsOperationFilter>();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        }).AddSwaggerGenNewtonsoftSupport();
    }
}
