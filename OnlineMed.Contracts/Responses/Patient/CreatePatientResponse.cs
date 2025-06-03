namespace OnlineMed.Contracts.Responses.Patient;

public sealed record CreatePatientResponse(
    int Id,
    string FullName,
    string Email,
    string? PhoneNumber,
    DateTime CreatedAt);