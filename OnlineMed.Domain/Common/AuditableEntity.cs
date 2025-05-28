namespace OnlineMed.Domain.Common;

public class AuditableEntity : EntityBase
{
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
