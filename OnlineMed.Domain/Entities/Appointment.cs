using OnlineMed.Domain.Common;

namespace OnlineMed.Domain.Entities;

public class Appointment : AuditableEntity
{
    public int PatientId { get; set; }
    public Patient? Patient { get; set; } = null!;

    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; } = null!;

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public decimal Price { get; set; }
}
