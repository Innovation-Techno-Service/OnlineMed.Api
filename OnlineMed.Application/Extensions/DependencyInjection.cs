using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineMed.Application.Interfaces;
using OnlineMed.Application.Services;
using System.Reflection;

namespace OnlineMed.Application.Extensions;

public static class DependencyInjection
{
    private static Assembly CurrentAssembly => Assembly.GetExecutingAssembly();

    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(CurrentAssembly);

        services.AddScoped<IDoctorService, DoctorService>();

        return services;
    }
}
