using OnlineMed.Domain.Common;
using OnlineMed.Domain.Enums;

namespace OnlineMed.Domain.Entities;

public class Doctor : AuditableEntity
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Specialization { get; set; }
    public required string ConversationLanguages { get; set; }
    public int Experience { get; set; }
    public int Age { get; set; }
    public decimal Price { get; set; }
    public decimal Rating { get; set; }
    public Gender Gender { get; set; }
}
