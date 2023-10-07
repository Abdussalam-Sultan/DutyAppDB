namespace DutyAppDB.Services.Contracts;

public interface IDutyService
{
    Task CreateDuty();
    Task GetAllDuty();
    Task UpdateDuty();
    Task DeleteDuty();
    Task ViewDutyDetail();
}
