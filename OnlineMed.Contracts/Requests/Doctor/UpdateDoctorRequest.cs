using OnlineMed.Contracts.Common;
using OnlineMed.Domain.Enums;

namespace OnlineMed.Contracts.Requests.Doctor;

public sealed record UpdateDoctorRequest(
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
    DateTime UpdatedAt)
        : AuditInfo(
            CreatedAt: CreatedAt,
            LastUpdatedAt: UpdatedAt);
