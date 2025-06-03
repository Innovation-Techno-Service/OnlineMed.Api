using OnlineMed.Contracts.Common;

namespace OnlineMed.Contracts.Requests.Patient;

public sealed record UpdatePatientRequest(
    int Id,
    string FullName,
    string Email,
    string? PhoneNumber,
    DateTime CreatedAt,
    DateTime UpdatedAt)
        : AuditInfo(
            CreatedAt: CreatedAt,
            LastUpdatedAt: UpdatedAt);
