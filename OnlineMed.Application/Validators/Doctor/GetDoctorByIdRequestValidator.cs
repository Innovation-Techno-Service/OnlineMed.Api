using FluentValidation;
using OnlineMed.Contracts.Requests.Doctor;

namespace OnlineMed.Application.Validators.Doctor;

public sealed class GetDoctorByIdRequestValidator : AbstractValidator<GetDoctorByIdRequest>
{
    public GetDoctorByIdRequestValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .WithMessage("Doctor ID is required.")
            .GreaterThan(0)
            .WithMessage("Doctor ID must be greater than 0.");
    }
}
