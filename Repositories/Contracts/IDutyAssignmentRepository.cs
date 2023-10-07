using DutyAppDB.Models.Entities;
using System.Threading.Tasks;

namespace DutyAppDB.Repositories.Contracts
{
    public interface IDutyAssignmentRepository
    {
        Task<int> AssignDutyToStudent(DutyAssignment dutyAssignment);
    }
}
