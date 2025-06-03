using Microsoft.EntityFrameworkCore;
using OnlineMed.Application.Interfaces;
using OnlineMed.Application.Mappings;
using OnlineMed.Contracts.Requests.Patient;
using OnlineMed.Contracts.Responses.Patient;
using OnlineMed.Domain.Entities;
using OnlineMed.Domain.Exceptions;

namespace OnlineMed.Application.Services;

internal sealed class PatientService(IApplicationDbContext context) : IPatientService
{
    public async Task<List<PatientResponse>> GetAllAsync(GetPatientRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var query = GetQuery(request);

        return await query
            .Select(x => new PatientResponse(
                x.Id,
                x.FullName,
                x.Email,
                x.PhoneNumber,
                x.CreatedAt,
                x.LastUpdatedAt))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<PatientResponse?> GetByIdAsync(GetPatientByIdRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await GetOrThrowAsync(request.Id);

        return entity.ToResponse();
    }

    public async Task<CreatePatientResponse> CreateAsync(CreatePatientRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = request.ToEntity();
        context.Patients.Add(entity);
        await context.SaveChangesAsync();

        return entity.ToCreatePatientResponse();
    }

    public async Task<UpdatePatientResponse> UpdateAsync(UpdatePatientRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await GetOrThrowAsync(request.Id);
        entity.Update(request);
        await context.SaveChangesAsync();

        return entity.ToUpdatePatientResponse();
    }

    public async Task DeleteAsync(DeletePatientRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await GetOrThrowAsync(request.Id);
        context.Patients.Remove(entity);
        await context.SaveChangesAsync();
    }

    private async Task<Patient> GetOrThrowAsync(int id) =>
        await context.Patients.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new EntityNotFoundException<Patient>(id);

    private IQueryable<Patient> GetQuery(GetPatientRequest request)
    {
        var query = context.Patients.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(
                p => p.FullName.Contains(request.SearchTerm) ||
                     p.Email.Contains(request.SearchTerm) ||
                     (p.PhoneNumber != null && p.PhoneNumber.Contains(request.SearchTerm)));
        }

        return query;
    }
}
