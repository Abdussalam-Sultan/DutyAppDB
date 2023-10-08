using DutyAppDB.Models.Entities;
using System.Threading.Tasks;

namespace DutyAppDB.Services.Contracts
{
    public interface IDutyAssignmentService
    {
        Task AssignDutyToStudent();
       // Task ViewStudentAssignments();
    }
}
