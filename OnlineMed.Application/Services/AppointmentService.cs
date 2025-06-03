using Microsoft.EntityFrameworkCore;
using OnlineMed.Application.Interfaces;
using OnlineMed.Application.Mappings;
using OnlineMed.Contracts.Requests.Appointment;
using OnlineMed.Contracts.Responses.Appointment;
using OnlineMed.Domain.Entities;
using OnlineMed.Domain.Exceptions;

namespace OnlineMed.Application.Services;

internal sealed class AppointmentService(IApplicationDbContext context) : IAppointmentService
{
    public async Task<List<AppointmentResponse>> GetAsync(GetAppointmentsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var query = GetQuery(request);

        return await query
            .Include(a => a.Patient)
            .Include(a => a.Doctor)
            .Select(x => new AppointmentResponse(
                x.Id,
                x.PatientId,
                x.Patient!.FullName,
                x.DoctorId,
                x.Doctor!.FullName,
                x.Price,
                x.StartTime,
                x.EndTime,
                x.CreatedAt,
                x.LastUpdatedAt))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<AppointmentResponse> GetByIdAsync(GetAppointmentByIdRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await GetOrThrowAsync(request.Id);

        return entity.ToResponse();
    }

    public async Task<CreateAppointmentResponse> CreateAsync(CreateAppointmentRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = request.ToEntity();
        context.Appointments.Add(entity);
        await context.SaveChangesAsync();

        return entity.ToCreateAppointmentResponse();
    }

    public async Task<UpdateAppointmentResponse> UpdateAsync(UpdateAppointmentRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await GetOrThrowAsync(request.Id);
        entity.Update(request);
        await context.SaveChangesAsync();

        return entity.ToUpdateAppointmentResponse();
    }

    public async Task DeleteAsync(DeleteAppointmentRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await GetOrThrowAsync(request.Id);
        context.Appointments.Remove(entity);
        await context.SaveChangesAsync();
    }

    private async Task<Appointment> GetOrThrowAsync(int id) =>
        await context.Appointments.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException<Appointment>(id);

    private IQueryable<Appointment> GetQuery(GetAppointmentsRequest request)
    {
        var query = context.Appointments.AsQueryable();

        if (request.DoctorId.HasValue)
        {
            query = query.Where(x => x.DoctorId == request.DoctorId.Value);
        }

        if (request.PatientId.HasValue)
        {
            query = query.Where(x => x.PatientId == request.PatientId.Value);
        }

        if (request.MinPrice.HasValue)
        {
            query = query.Where(x => x.Price >= request.MinPrice.Value);
        }

        if (request.MaxPrice.HasValue)
        {
            query = query.Where(x => x.Price <= request.MaxPrice.Value);
        }

        if (request.StartTime.HasValue)
        {
            query = query.Where(x => x.StartTime.Date == request.StartTime.Value.Date);
        }

        if (request.EndTime.HasValue)
        {
            query = query.Where(x => x.EndTime.Date == request.EndTime.Value.Date);
        }

        return query;
    }
}
