using OnlineMed.Contracts.Common;

namespace OnlineMed.Contracts.Requests.Appointment;

public sealed record CreateAppointmentRequest(
    int PatientId,
    int DoctorId,
    decimal Price,
    DateTime StartTime,
    DateTime EndTime,
    DateTime CreatedAt)
        : AuditInfo(
            CreatedAt: CreatedAt,
            default);