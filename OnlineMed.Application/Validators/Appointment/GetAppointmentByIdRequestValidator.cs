using FluentValidation;
using OnlineMed.Contracts.Requests.Appointment;

namespace OnlineMed.Application.Validators.Appointment;

public sealed class GetAppointmentByIdRequestValidator : AbstractValidator<GetAppointmentByIdRequest>
{
    public GetAppointmentByIdRequestValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty()
            .WithMessage("Appointment ID is required.")
            .GreaterThan(0)
            .WithMessage("Appointment ID must be greater than 0.");
    }
}
