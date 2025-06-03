using FluentValidation;
using OnlineMed.Contracts.Requests.Appointment;

namespace OnlineMed.Application.Validators.Appointment;

public sealed class CreateAppointmentRequestValidator : AbstractValidator<CreateAppointmentRequest>
{
    public CreateAppointmentRequestValidator()
    {
       RuleFor(x => x.PatientId)
            .GreaterThan(0)
            .WithMessage("Patient ID must be greater than 0.");

        RuleFor(x => x.DoctorId)
            .GreaterThan(0)
            .WithMessage("Doctor ID must be greater than 0.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price must be a non-negative value.");

        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime)
            .WithMessage("StartTime must be before EndTime.");

        RuleFor(x => x.CreatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("CreatedAt cannot be in the future.");
    }
}