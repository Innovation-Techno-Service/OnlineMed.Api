using OnlineMed.Contracts.Requests.Patient;
using OnlineMed.Contracts.Responses.Patient;

namespace OnlineMed.Application.Interfaces;

public interface IPatientService
{
    Task<List<PatientResponse>> GetAllAsync(GetPatientRequest request);
    Task<PatientResponse?> GetByIdAsync(GetPatientByIdRequest request);
    Task<CreatePatientResponse> CreateAsync(CreatePatientRequest request);
    Task<UpdatePatientResponse> UpdateAsync(UpdatePatientRequest request);
    Task DeleteAsync(DeletePatientRequest request);
}
