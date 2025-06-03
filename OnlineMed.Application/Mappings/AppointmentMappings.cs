using OnlineMed.Contracts.Requests.Appointment;
using OnlineMed.Contracts.Requests.Patient;
using OnlineMed.Contracts.Responses.Appointment;
using OnlineMed.Domain.Entities;

namespace OnlineMed.Application.Mappings;

internal static class AppointmentMappings
{
    public static AppointmentResponse ToResponse(this Appointment appointment)
    {
        return new AppointmentResponse(
            Id: appointment.Id,
            PatientId: appointment.PatientId,
            PatientName: appointment.Patient!.FullName,
            DoctorId: appointment.DoctorId,
            DoctorName: appointment.Doctor!.FullName,
            Price: appointment.Price,
            StartTime: appointment.StartTime,
            EndTime: appointment.EndTime,
            CreatedAt: appointment.CreatedAt,
            LastUpdatedAt: appointment.LastUpdatedAt);
    }

    public static Appointment ToEntity(this CreateAppointmentRequest request)
    {
        return new Appointment
        {
            PatientId = request.PatientId,
            DoctorId = request.DoctorId,
            Price = request.Price,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            CreatedAt = request.CreatedAt,
            LastUpdatedAt = default
        };
    }

    public static CreateAppointmentResponse ToCreateAppointmentResponse(this Appointment appointment)
    {
        return new CreateAppointmentResponse(
            Id: appointment.Id,
            PatientId: appointment.PatientId,
            PatientName: appointment.Patient!.FullName,
            DoctorId: appointment.DoctorId,
            DoctorName: appointment.Doctor!.FullName,
            Price: appointment.Price,
            StartTime: appointment.StartTime,
            EndTime: appointment.EndTime,
            CreatedAt: appointment.CreatedAt);
    }

    public static void Update(this Appointment appointment, UpdateAppointmentRequest request)
    {
        appointment.Id = request.Id;
        appointment.PatientId = request.PatientId;
        appointment.DoctorId = request.DoctorId;
        appointment.Price = request.Price;
        appointment.StartTime = request.StartTime;
        appointment.EndTime = request.EndTime;
        appointment.CreatedAt = request.CreatedAt;
        appointment.LastUpdatedAt = request.UpdatedAt;
    }

    public static UpdateAppointmentResponse ToUpdateAppointmentResponse(this Appointment appointment)
    {
        return new UpdateAppointmentResponse(
            Id: appointment.Id,
            PatientId: appointment.PatientId,
            PatientName: appointment.Patient!.FullName,
            DoctorId: appointment.DoctorId,
            DoctorName: appointment.Doctor!.FullName,
            Price: appointment.Price,
            StartTime: appointment.StartTime,
            EndTime: appointment.EndTime,
            CreatedAt: appointment.CreatedAt,
            LastUpdatedAt: appointment.LastUpdatedAt);
    }
}
