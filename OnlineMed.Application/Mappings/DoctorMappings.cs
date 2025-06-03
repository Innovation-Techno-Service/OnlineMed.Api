using OnlineMed.Contracts.Requests.Doctor;
using OnlineMed.Contracts.Responses.Doctor;
using OnlineMed.Domain.Entities;
using OnlineMed.Domain.Enums;

namespace OnlineMed.Application.Mappings;

internal static class DoctorMappings
{
    public static Doctor ToEntity(this CreateDoctorRequest request)
    {
        return new Doctor
        {
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Specialization = request.Specialization,
            ConversationLanguages = request.ConversationLanguages,
            Experience = request.Experience,
            Age = request.Age,
            PricePerHour = request.Price,
            Rating = request.Rating,
            Gender = request.Gender,
            CreatedAt = request.CreatedAt,
            LastUpdatedAt = default
        };
    }

    public static CreateDoctorResponse ToCreateDoctorResponse(this Doctor doctor)
    {
        return new CreateDoctorResponse(
            Id: doctor.Id,
            FullName: doctor.FullName,
            Email: doctor.Email,
            PhoneNumber: doctor.PhoneNumber,
            Specialization: doctor.Specialization,
            ConversationLanguages: doctor.ConversationLanguages,
            Experience: doctor.Experience,
            Age: doctor.Age,
            Price: doctor.PricePerHour,
            Rating: doctor.Rating,
            Gender: doctor.Gender,
            CreatedAt: doctor.CreatedAt);
    }

    public static DoctorResponse ToResponse(this Doctor doctor)
    {
        return new DoctorResponse(
            Id: doctor.Id,
            FullName: doctor.FullName,
            Email: doctor.Email,
            PhoneNumber: doctor.PhoneNumber,
            Specialization: doctor.Specialization,
            ConversationLanguages: doctor.ConversationLanguages,
            Experience: doctor.Experience,
            Age: doctor.Age,
            Price: doctor.PricePerHour,
            Rating: doctor.Rating,
            Gender: doctor.Gender,
            CreatedAt: doctor.CreatedAt,
            LastUpdatedAt: doctor.LastUpdatedAt);
    }

    public static void Update(this Doctor doctor, UpdateDoctorRequest request)
    {
        doctor.Id = request.Id;
        doctor.FullName = request.FullName;
        doctor.Email = request.Email;
        doctor.PhoneNumber = request.PhoneNumber;
        doctor.Specialization = request.Specialization;
        doctor.ConversationLanguages = request.ConversationLanguages;
        doctor.Experience = request.Experience;
        doctor.Age = request.Age;
        doctor.PricePerHour = request.Price;
        doctor.Rating = request.Rating;
        doctor.Gender = request.Gender;
        doctor.CreatedAt = request.CreatedAt;
        doctor.LastUpdatedAt = DateTime.UtcNow;
    }

    public static UpdateDoctorResponse ToUpdateDoctorResponse(this Doctor doctor)
    {
        return new UpdateDoctorResponse(
            Id: doctor.Id,
            FullName: doctor.FullName,
            Email: doctor.Email,
            PhoneNumber: doctor.PhoneNumber,
            Specialization: doctor.Specialization,
            ConversationLanguages: doctor.ConversationLanguages,
            Experience: doctor.Experience,
            Age: doctor.Age,
            Price: doctor.PricePerHour,
            Rating: doctor.Rating,
            Gender: doctor.Gender,
            CreatedAt: doctor.CreatedAt,
            LastUpdatedAt: doctor.LastUpdatedAt);
    }
}
