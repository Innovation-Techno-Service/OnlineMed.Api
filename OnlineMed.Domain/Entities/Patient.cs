using OnlineMed.Domain.Common;

namespace OnlineMed.Domain.Entities;

public class Patient : AuditableEntity
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = [];
}
