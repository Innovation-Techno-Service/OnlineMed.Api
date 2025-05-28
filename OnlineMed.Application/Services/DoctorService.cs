using Microsoft.EntityFrameworkCore;
using OnlineMed.Application.Interfaces;
using OnlineMed.Application.Mappings;
using OnlineMed.Contracts.Requests.Doctor;
using OnlineMed.Contracts.Responses.Doctor;
using OnlineMed.Domain.Entities;
using OnlineMed.Domain.Exceptions;

namespace OnlineMed.Application.Services;

internal sealed class DoctorService(IApplicationDbContext context) : IDoctorService
{
    public async Task<List<DoctorResponse>> GetAllAsync(GetDoctorsRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var query = GetQuery(request);

        return await query
            .Select(x => new DoctorResponse(
                x.Id,
                x.FullName,
                x.Email,
                x.PhoneNumber,
                x.Specialization,
                x.ConversationLanguages,
                x.Experience,
                x.Age,
                x.Price,
                x.Rating,
                x.Gender,
                x.CreatedAt,
                x.LastUpdatedAt))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<DoctorResponse> GetByIdAsync(GetDoctorByIdRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await GetOrThrowAsync(request.Id);

        return entity.ToResponse();
    }

    public async Task<CreateDoctorResponse> CreateAsync(CreateDoctorRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = request.ToEntity();
        context.Doctors.Add(entity);
        await context.SaveChangesAsync();

        var createdDoctor = await GetOrThrowAsync(entity.Id);

        return createdDoctor.ToCreateDoctorResponse();
    }

    public async Task<UpdateDoctorResponse> UpdateAsync(UpdateDoctorRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var entity = await GetOrThrowAsync(request.Id);
        entity.Update(request);
        await context.SaveChangesAsync();

        return entity.ToUpdateDoctorResponse();
    }

    public async Task DeleteAsync(DeleteDoctorRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var entity = await GetOrThrowAsync(request.Id);
        context.Doctors.Remove(entity);
        await context.SaveChangesAsync();
    }

    private async Task<Doctor> GetOrThrowAsync(int id) =>
        await context.Doctors.FirstOrDefaultAsync(x => x.Id == id)
        ?? throw new EntityNotFoundException<Doctor>(id);

    private IQueryable<Doctor> GetQuery(GetDoctorsRequest request)
    {
        var query = context.Doctors.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            query = query.Where(
                d => d.FullName.Contains(request.SearchTerm) || 
                     d.Email.Contains(request.SearchTerm) ||
                     d.PhoneNumber.Contains(request.SearchTerm) ||
                     d.Specialization.Contains(request.SearchTerm) ||
                     d.ConversationLanguages.Contains(request.SearchTerm));
        }

        if (request.MinExperience.HasValue)
        {
            query = query.Where(d => d.Experience >= request.MinExperience.Value);
        }

        if (request.MaxExperience.HasValue)
        {
            query = query.Where(d => d.Experience <= request.MaxExperience.Value);
        }

        if (request.MinAge.HasValue)
        {
            query = query.Where(d => d.Age >= request.MinAge.Value);
        }

        if (request.MaxAge.HasValue)
        {
            query = query.Where(d => d.Age <= request.MaxAge.Value);
        }

        if (request.MinPrice.HasValue)
        {
            query = query.Where(d => d.Price >= request.MinPrice.Value);
        }

        if (request.MaxPrice.HasValue)
        {
            query = query.Where(d => d.Price <= request.MaxPrice.Value);
        }

        if (request.MinRating.HasValue)
        {
            query = query.Where(d => d.Rating >= request.MinRating.Value);
        }

        if (request.MaxRating.HasValue)
        {
            query = query.Where(d => d.Rating <= request.MaxRating.Value);
        }

        if (request.Gender.HasValue)
        {
            query = query.Where(d => d.Gender == request.Gender);
        }

        return query;
    }
}
