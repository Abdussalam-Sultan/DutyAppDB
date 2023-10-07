using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutyAppDB.Services.Contracts
{
    public interface IStudentService
    {
        Task CreateStudent();
        Task GetAllStudent();
        Task UpdateStudent();
        Task DeleteStudent();
        Task ReadStudentDetail();
    }
}
