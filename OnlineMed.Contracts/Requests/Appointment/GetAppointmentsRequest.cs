namespace OnlineMed.Contracts.Requests.Appointment;

public sealed record GetAppointmentsRequest(
    int? PatientId,
    int? DoctorId,
    decimal? MinPrice,
    decimal? MaxPrice,
    DateTime? StartTime,
    DateTime? EndTime);
    