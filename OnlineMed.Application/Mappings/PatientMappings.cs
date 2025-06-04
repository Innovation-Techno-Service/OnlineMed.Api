using OnlineMed.Contracts.Requests.Patient;
using OnlineMed.Contracts.Responses.Doctor;
using OnlineMed.Contracts.Responses.Patient;
using OnlineMed.Domain.Entities;

namespace OnlineMed.Application.Mappings;

internal static class PatientMappings
{
    public static Patient ToEntity(this CreatePatientRequest request)
    {
        return new Patient
        {
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            CreatedAt = request.CreatedAt,
            LastUpdatedAt = default
        };
    }

    public static PatientResponse ToResponse(this Patient patient)
    {
        return new PatientResponse(
            Id: patient.Id,
            FullName: patient.FullName,
            Email: patient.Email,
            PhoneNumber: patient.PhoneNumber,
            CreatedAt: patient.CreatedAt,
            LastUpdatedAt: patient.LastUpdatedAt);
    }

    public static CreatePatientResponse ToCreatePatientResponse(this Patient patient)
    {
        return new CreatePatientResponse(
            Id: patient.Id,
            FullName: patient.FullName,
            Email: patient.Email,
            PhoneNumber: patient.PhoneNumber,
            CreatedAt: patient.CreatedAt);
    }

    public static void Update(this Patient patient, UpdatePatientRequest request)
    {
        patient.Id = request.Id;
        patient.FullName = request.FullName;
        patient.Email = request.Email;
        patient.PhoneNumber = request.PhoneNumber;
        patient.CreatedAt = request.CreatedAt;
        patient.LastUpdatedAt = DateTime.UtcNow;
    }

    public static UpdatePatientResponse ToUpdatePatientResponse(this Patient patient)
    {
        return new UpdatePatientResponse(
            Id: patient.Id,
            FullName: patient.FullName,
            Email: patient.Email,
            PhoneNumber: patient.PhoneNumber,
            CreatedAt: patient.CreatedAt,
            UpdatedAt: patient.LastUpdatedAt);
    }
}
