using Dapper;
using DutyAppDB.Models.Dtos;
using DutyAppDB.Models.Dtos.Students;
using DutyAppDB.Repositories.Contracts;
using System.Data;

namespace DutyAppDB.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly IDbConnection _dbConnection;

    public StudentRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<int> CreateStudent(CreateStudentDto request)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "INSERT INTO student (FirstName, LastName, MiddleName, Email) VALUES (@FirstName, @LastName, @MiddleName, @Email);";

            int rowsAffected = await _dbConnection.ExecuteAsync(sql, request);

            return rowsAffected;
        }
    }


    public async Task<List<ReadStudentDto>> GetAllStudent()
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "SELECT Id, FirstName, LastName, MiddleName, Email FROM student;";

            var result = await _dbConnection.QueryAsync<ReadStudentDto>(sql);

            return result.ToList();
        }
    }



    public async Task<int> UpdateStudent(int id, UpdateStudentDto updatedStudent)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "UPDATE student SET FirstName = @FirstName,LastName = @LastName," +
                " MiddleName = @MiddleName, Email = @Email WHERE Id = @Id;";

            updatedStudent.Id = id; // Assign the duty ID to the DTO

            int rowsAffected = await _dbConnection.ExecuteAsync(sql, updatedStudent);

            return rowsAffected;
        }
    }
    public async Task<int> DeleteStudent(int id)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "DELETE FROM student WHERE Id = @Id;";

            int rowsAffected = await _dbConnection.ExecuteAsync(sql, new { Id = id });

            return rowsAffected;
        }
    }
    public async Task<ReadStudentDetailDto> GetStudentById(int id)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "SELECT Id, FirstName, LastName, MiddleName, Email FROM student WHERE Id = @Id;";

            var result = await _dbConnection.QueryFirstOrDefaultAsync<ReadStudentDetailDto>(sql, new { Id = id });

            return result;
        }
    }


}
