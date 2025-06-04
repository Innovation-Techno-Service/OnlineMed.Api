using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineMed.Application.Interfaces;
using OnlineMed.Application.Services;
using System.Reflection;

namespace OnlineMed.Application.Extensions;

public static class DependencyInjection
{
    private static Assembly CurrentAssembly => Assembly.GetExecutingAssembly();

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(CurrentAssembly);

        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IAppointmentService, AppointmentService>();

        return services;
    }
}