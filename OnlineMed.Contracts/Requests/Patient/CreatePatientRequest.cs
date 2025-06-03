using OnlineMed.Contracts.Common;

namespace OnlineMed.Contracts.Requests.Patient;

public sealed record CreatePatientRequest(
    string FullName,
    string Email,
    string? PhoneNumber,
    DateTime CreatedAt)
        :AuditInfo(
            CreatedAt: CreatedAt,
            default);
