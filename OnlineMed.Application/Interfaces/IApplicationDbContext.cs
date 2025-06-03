using Microsoft.EntityFrameworkCore;
using OnlineMed.Domain.Entities;

namespace OnlineMed.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Doctor> Doctors { get; set; }
    DbSet<Patient> Patients { get; set; }
    DbSet<Appointment> Appointments { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
