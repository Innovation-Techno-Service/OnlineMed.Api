using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace OnlineMed.Api.Filters;

public class ValidationErrorsOperationFilter(IServiceScopeFactory scopeFactory) : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var bodyParam = context.MethodInfo
            .GetParameters()
            .FirstOrDefault(p => p.GetCustomAttribute<FromBodyAttribute>() != null);
        var bodyType = bodyParam?.ParameterType;
        if (bodyType is null)
        {
            return;
        }

        var validatorServiceType = typeof(IValidator<>).MakeGenericType(bodyType);

        using var scope = scopeFactory.CreateScope();
        if (scope.ServiceProvider.GetService(validatorServiceType) is not IValidator)
        {
            return;
        }

        operation.Responses["400"] = new OpenApiResponse
        {
            Description = "Validation errors",
            Content =
            {
                ["application/json"] = new OpenApiMediaType
                {
                    Schema = context.SchemaGenerator.GenerateSchema(
                        typeof(ValidationProblemDetails),
                        context.SchemaRepository)
                }
            }
        };

        if (operation.Responses["400"].Content.ContainsKey("application/problem+json"))
        {
            operation.Responses["400"].Content["application/problem+json"].Examples =
                new Dictionary<string, OpenApiExample>
                {
                    {
                        "SampleValidationError", new OpenApiExample
                        {
                            Summary = "Missing or invalid fields",
                            Value = new OpenApiObject
                            {
                                ["Message"] = new OpenApiString("Validation failed for one or more fields.")
                            }
                        }
                    }
                };
        }

    }
}
