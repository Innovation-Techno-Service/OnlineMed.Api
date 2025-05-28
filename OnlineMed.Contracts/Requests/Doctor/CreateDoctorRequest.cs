using OnlineMed.Contracts.Common;
using OnlineMed.Domain.Enums;

namespace OnlineMed.Contracts.Requests.Doctor;

public sealed record CreateDoctorRequest(
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
    DateTime CreatedAt)
        : AuditInfo(
            CreatedAt: CreatedAt,
            default);
