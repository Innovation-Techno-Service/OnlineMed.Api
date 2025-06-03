namespace OnlineMed.Contracts.Responses.Patient;

public sealed record PatientResponse(
    int Id,
    string FullName,
    string Email,
    string? PhoneNumber,
    DateTime CreatedAt,
    DateTime? LastUpdatedAt);
