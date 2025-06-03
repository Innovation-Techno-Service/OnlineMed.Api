using OnlineMed.Contracts.Common;

namespace OnlineMed.Contracts.Requests.Appointment;

public sealed record UpdateAppointmentRequest(
    int Id,
    int PatientId,
    int DoctorId,
    decimal Price,
    DateTime StartTime,
    DateTime EndTime,
    DateTime CreatedAt,
    DateTime UpdatedAt)
        : AuditInfo(
            CreatedAt: CreatedAt,
            LastUpdatedAt: UpdatedAt);
