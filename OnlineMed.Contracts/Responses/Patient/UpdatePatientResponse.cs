namespace OnlineMed.Contracts.Responses.Patient;

public sealed record UpdatePatientResponse(
    int Id,
    string FullName,
    string Email,
    string? PhoneNumber,
    DateTime CreatedAt,
    DateTime? LastUpdatedAt);
