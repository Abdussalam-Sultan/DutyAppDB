using DutyAppDB.Enums;

namespace DutyAppDB.Models.Entities;

public class Student : BaseEntity
{
    public string StudentCode { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public string Email { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public Gender Gender { get; set; }
}