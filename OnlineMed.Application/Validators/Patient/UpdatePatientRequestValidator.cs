using FluentValidation;
using OnlineMed.Contracts.Requests.Patient;

namespace OnlineMed.Application.Validators.Patient;

public sealed class UpdatePatientRequestValidator : AbstractValidator<UpdatePatientRequest>
{
    public UpdatePatientRequestValidator()
    {
        RuleFor(d => d.Id)
            .NotEmpty()
            .WithMessage("Patient ID is required.")
            .GreaterThan(0)
            .WithMessage("Patient ID must be greater than 0.");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("Full name is required.")
            .MaximumLength(ValidationConstants.DefaultStringLength)
            .WithMessage($"Full name must not exceed {ValidationConstants.DefaultStringLength} characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .MaximumLength(ValidationConstants.DefaultStringLength)
            .WithMessage($"Email must not exceed {ValidationConstants.DefaultStringLength} characters.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^(?:\+998\d{9}|\d{9})$")
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
            .WithMessage("Invalid phone number format.");
    }
}
