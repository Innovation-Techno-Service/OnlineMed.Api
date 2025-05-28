namespace OnlineMed.Contracts.Common;

public record AuditInfo(
    DateTime CreatedAt,
    DateTime? LastUpdatedAt
);
