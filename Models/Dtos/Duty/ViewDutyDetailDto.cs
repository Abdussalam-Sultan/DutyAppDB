namespace DutyAppDB.Models.Dtos.Duty;

public class ViewDutyDetailDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? LastModified { get; set; }
}