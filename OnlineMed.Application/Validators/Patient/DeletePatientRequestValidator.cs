using FluentValidation;
using OnlineMed.Contracts.Requests.Patient;

namespace OnlineMed.Application.Validators.Patient;

public sealed class DeletePatientRequestValidator : AbstractValidator<DeletePatientRequest>
{
    public DeletePatientRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Patient ID is required.")
            .GreaterThan(0)
            .WithMessage("Patient ID must be greater than 0.");
    }
}
