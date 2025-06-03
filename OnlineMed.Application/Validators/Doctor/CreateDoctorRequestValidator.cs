using FluentValidation;
using OnlineMed.Contracts.Requests.Doctor;

namespace OnlineMed.Application.Validators.Doctor;

public sealed class CreateDoctorRequestValidator : AbstractValidator<CreateDoctorRequest>
{
    public CreateDoctorRequestValidator()
    {
        RuleFor(d => d.FullName)
            .NotEmpty()
            .WithMessage("Full name is required.")
            .MaximumLength(ValidationConstants.DefaultStringLength)
            .WithMessage($"Full name must not exceed {ValidationConstants.DefaultStringLength} characters.");

        RuleFor(d => d.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .MaximumLength(ValidationConstants.DefaultStringLength)
            .WithMessage($"Email must not exceed {ValidationConstants.DefaultStringLength} characters.");

        RuleFor(d => d.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^(?:\+998\d{9}|\d{9})$")
            .WithMessage("Telefon raqami formati noto‘g‘ri. +998 bilan yoki 9 ta raqam kiriting.")
            .MaximumLength(ValidationConstants.DefaultStringLength)
            .WithMessage($"Phone number must not exceed {ValidationConstants.DefaultStringLength} characters.");

        RuleFor(d => d.Specialization)
            .NotEmpty()
            .WithMessage("Specialization is required.")
            .MaximumLength(ValidationConstants.MaxStringLength)
            .WithMessage($"Specialization must not exceed {ValidationConstants.MaxStringLength} characters.");

        RuleFor(d => d.ConversationLanguages)
            .NotEmpty()
            .WithMessage("Conversation languages are required.")
            .MaximumLength(ValidationConstants.MaxStringLength)
            .WithMessage($"Conversation languages must not exceed {ValidationConstants.MaxStringLength} characters.");

        RuleFor(d => d.Experience)
            .NotEmpty()
            .WithMessage("Experience is required.")
            .GreaterThan(0)
            .WithMessage("Experience must be greater than 0.");

        RuleFor(d => d.Age)
            .NotEmpty()
            .WithMessage("Age is required.")
            .InclusiveBetween(18, 100)
            .WithMessage("Age must be between 18 and 100.");

        RuleFor(d => d.Price)
            .NotEmpty()
            .WithMessage("PricePerHour is required.");

        RuleFor(d => d.Gender)
            .NotEmpty()
            .WithMessage("Gender is required.");

        RuleFor(d => d.Rating)
            .NotEmpty()
            .WithMessage("Rating is required.")
            .InclusiveBetween(0, 5)
            .WithMessage("Rating must be between 0 and 5.");
    }
}
