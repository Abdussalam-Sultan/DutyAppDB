namespace DutyAppDB.Models.Entities;

public class Duty : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}