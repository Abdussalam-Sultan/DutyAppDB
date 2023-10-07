using DutyAppDB.Models.Entities;
using DutyAppDB.Repositories.Contracts;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace DutyAppDB.Repositories
{
    public class DutyAssignmentRepository : IDutyAssignmentRepository
    {
        private readonly IDbConnection _dbConnection;

        public DutyAssignmentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> AssignDutyToStudent(DutyAssignment dutyAssignment)
        {
            using (_dbConnection)
            {
                _dbConnection.Open();

                var sql = "INSERT INTO DutyAssignments (DutyId, StudentId) VALUES (@DutyId, @StudentId);";

                int rowsAffected = await _dbConnection.ExecuteAsync(sql, dutyAssignment);

                return rowsAffected;
            }
        }
    }
}
