namespace DutyAppDB.Models.Entities;

public class DutyAssignment : BaseEntity
{
    public string DutyId { get; set; } = default!;
    public string StudentId { get; set; } = default!;
}