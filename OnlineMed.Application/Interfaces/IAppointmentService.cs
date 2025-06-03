using OnlineMed.Contracts.Requests.Appointment;
using OnlineMed.Contracts.Responses.Appointment;

namespace OnlineMed.Application.Interfaces;

public interface IAppointmentService
{
    Task<List<AppointmentResponse>> GetAsync(GetAppointmentsRequest request);
    Task<AppointmentResponse> GetByIdAsync(GetAppointmentByIdRequest request);
    Task<CreateAppointmentResponse> CreateAsync(CreateAppointmentRequest request);
    Task<UpdateAppointmentResponse> UpdateAsync(UpdateAppointmentRequest request);
    Task DeleteAsync(DeleteAppointmentRequest request);
}
