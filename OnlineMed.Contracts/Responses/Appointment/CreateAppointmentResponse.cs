namespace OnlineMed.Contracts.Responses.Appointment;

public sealed record CreateAppointmentResponse(
    int Id,
    int PatientId,
    string PatientName,
    int DoctorId,
    string DoctorName,
    decimal Price,
    DateTime StartTime,
    DateTime EndTime,
    DateTime CreatedAt);
