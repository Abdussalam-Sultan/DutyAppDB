namespace DutyAppDB.Models.Dtos.Duty;

public class CreateDutyDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    //public string TimePeriod { get; set; }
}