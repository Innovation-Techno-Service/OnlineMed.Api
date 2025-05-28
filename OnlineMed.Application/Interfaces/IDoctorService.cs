using OnlineMed.Contracts.Requests.Doctor;
using OnlineMed.Contracts.Responses.Doctor;

namespace OnlineMed.Application.Interfaces;

public interface IDoctorService
{
    Task<List<DoctorResponse>> GetAllAsync(GetDoctorsRequest request);
    Task<DoctorResponse> GetByIdAsync(GetDoctorByIdRequest request);
    Task<CreateDoctorResponse> CreateAsync(CreateDoctorRequest request);
    Task<UpdateDoctorResponse> UpdateAsync(UpdateDoctorRequest request);
    Task DeleteAsync(DeleteDoctorRequest request);
}
