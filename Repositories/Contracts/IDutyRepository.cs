using DutyAppDB.Models.Dtos;
using DutyAppDB.Models.Dtos.Duty;

namespace DutyAppDB.Repositories.Contracts;

public interface IDutyRepository
{
    Task<int> CreateDuty(CreateDutyDto request);
    Task<List<ReadOnlyDutyDto>> GetAllDuty();
    Task<ViewDutyDetailDto> GetDutyById(int id);
    Task<int> UpdateDuty(int id, UpdateDutyDto updatedDuty);
    Task<int> DeleteDuty(int id);
}
