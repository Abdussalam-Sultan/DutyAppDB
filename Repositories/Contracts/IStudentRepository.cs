using DutyAppDB.Models.Dtos.Students;

namespace DutyAppDB.Repositories.Contracts;

public interface IStudentRepository
{
    Task<int> CreateStudent(CreateStudentDto request);
    Task<List<ReadStudentDto>> GetAllStudent();
    Task<ReadStudentDetailDto> GetStudentById(int id);
    Task<int> UpdateStudent(int id, UpdateStudentDto updatedStudent);
    Task<int> DeleteStudent(int id);
}