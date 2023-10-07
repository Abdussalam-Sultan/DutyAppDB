namespace DutyAppDB.Models.Dtos.Duty;

public class UpdateDutyDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}