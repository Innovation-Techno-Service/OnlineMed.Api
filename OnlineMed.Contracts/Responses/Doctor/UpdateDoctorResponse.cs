using OnlineMed.Domain.Enums;

namespace OnlineMed.Contracts.Responses.Doctor;

public sealed record UpdateDoctorResponse(
    int Id,
    string FullName,
    string Email,
    string PhoneNumber,
    string Specialization,
    string ConversationLanguages,
    int Experience,
    int Age,
    decimal Price,
    decimal Rating,
    Gender Gender,
    DateTime CreatedAt,
    DateTime? LastUpdatedAt);
