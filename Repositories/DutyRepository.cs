using Dapper;
using DutyAppDB.Models.Dtos;
using DutyAppDB.Models.Dtos.Duty;
using DutyAppDB.Repositories.Contracts;
using System.Data;

namespace DutyAppDB.Repositories;

public class DutyRepository : IDutyRepository
{
    private readonly IDbConnection _dbConnection;

    public DutyRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<int> CreateDuty(CreateDutyDto request)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "INSERT INTO duty (Name, Description) VALUES (@Name, @Description);";

            int rowsAffected = await _dbConnection.ExecuteAsync(sql, request);

            return rowsAffected;
        }
    }


    public async Task<List<ReadOnlyDutyDto>> GetAllDuty()
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "SELECT Id, Name, Description FROM duty;";

            var result = await _dbConnection.QueryAsync<ReadOnlyDutyDto>(sql);

            return result.ToList();
        }
    }



   public async Task<int> UpdateDuty(int id, UpdateDutyDto updatedDuty)
    {
    using (_dbConnection)
        {
        _dbConnection.Open();

        var sql = "UPDATE duty SET Name = @Name, Description = @Description WHERE Id = @Id;";

        updatedDuty.Id = id; // Assign the duty ID to the DTO

        int rowsAffected = await _dbConnection.ExecuteAsync(sql, updatedDuty);

        return rowsAffected;
        }
    }
    public async Task<int> DeleteDuty(int id)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "DELETE FROM duty WHERE Id = @Id;";

            int rowsAffected = await _dbConnection.ExecuteAsync(sql, new { Id = id });

            return rowsAffected;
        }
    }
    public async Task<ViewDutyDetailDto> GetDutyById(int id)
    {
        using (_dbConnection)
        {
            _dbConnection.Open();

            var sql = "SELECT Id, Name, Description FROM duty WHERE Id = @Id;";

            var result = await _dbConnection.QueryFirstOrDefaultAsync<ViewDutyDetailDto>(sql, new { Id = id });

            return result;
        }
    }


}
