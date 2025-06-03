using FluentValidation;
using OnlineMed.Contracts.Requests.Doctor;

namespace OnlineMed.Application.Validators.Patient;

public sealed class GetPatientByIdRequestValidator : AbstractValidator<GetDoctorByIdRequest>
{
    public GetPatientByIdRequestValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .WithMessage("Patient ID is required.")
            .GreaterThan(0)
            .WithMessage("Patient ID must be greater than 0.");
    }
}
