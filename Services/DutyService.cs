using ConsoleTables;
using DutyAppDB.Models.Dtos;
using DutyAppDB.Models.Dtos.Duty;
using DutyAppDB.Models.Entities;
using DutyAppDB.Repositories;
using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;

namespace DutyAppDB.Services;

public class DutyService : IDutyService
{
    private readonly IDutyRepository _dutyRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IDutyAssignmentRepository _dutyAssignmentRepository;

    public DutyService(IDutyRepository dutyRepository)
    {
        _dutyRepository = dutyRepository;
    }

    public async Task CreateDuty()
    {
        try
        {
            Console.Write("Enter the Duty Name: ");
            string dutyName = Console.ReadLine()!;

            Console.Write("Enter the Duty Description: ");
            string? description = Console.ReadLine();

            var duty = new CreateDutyDto
            {
                Name = dutyName,
                Description = description
            };

            int rowsAffected = await _dutyRepository.CreateDuty(duty);

            if (rowsAffected == 1)
            {
                Helpers.SuccessTextOutput("Duty created successfully!");
            }
            else
            {
                Helpers.FailureTextOutput("Could not create duty!");
            }
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public async Task GetAllDuty()
    {
        try
        {
            var duties = await _dutyRepository.GetAllDuty();

            if (duties.Count > 0)
            {
                //duties = duties.OrderBy(duty => duty.Name).ToList();
                var table = new ConsoleTable("ID", "DUTY NAME", "DESCRIPTION");

                foreach (var duty in duties)
                {
                    table.AddRow(duty.Id, duty.Name, duty.Description);
                }

                table.Write(Format.Alternative);
                return;
            }

            Helpers.InfoTextOutput("No records found");
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public async Task UpdateDuty()
    {
        try
        {
            Console.Write("Enter the ID of the duty to update: ");
            if (!int.TryParse(Console.ReadLine(), out int dutyId))
            {
                Helpers.FailureTextOutput("Invalid duty ID entered.");
                return;
            }

            Console.Write("Enter the updated Duty Name: ");
            string updatedDutyName = Console.ReadLine()!;

            Console.Write("Enter the updated Duty Description: ");
            string? updatedDescription = Console.ReadLine();

            var updatedDuty = new UpdateDutyDto
            {
                Name = updatedDutyName,
                Description = updatedDescription
            };

            int rowsAffected = await _dutyRepository.UpdateDuty(dutyId, updatedDuty);

            if (rowsAffected == 1)
            {
                Helpers.SuccessTextOutput("Duty updated successfully!");
            }
            else
            {
                Helpers.FailureTextOutput("Could not update duty. Make sure the duty ID exists.");
            }
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public async Task DeleteDuty()
    {
        try
        {
            Console.Write("Enter the ID of the duty to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int dutyId))
            {
                Helpers.FailureTextOutput("Invalid duty ID entered.");
                return;
            }

            Console.Write("Are you sure you want to delete this duty? (yes/no): ");
            string confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "yes")
            {
                int rowsAffected = await _dutyRepository.DeleteDuty(dutyId);

                if (rowsAffected == 1)
                {
                    Helpers.SuccessTextOutput("Duty deleted successfully!");
                }
                else
                {
                    Helpers.InfoTextOutput("No duty with that ID found.");
                }
            }
            else
            {
                Helpers.InfoTextOutput("Deletion canceled.");
            }
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }
    public async Task ViewDutyDetail()
    {
        try
        {
            Console.Write("Enter the ID of the duty to view: ");
            if (!int.TryParse(Console.ReadLine(), out int dutyId))
            {
                Helpers.FailureTextOutput("Invalid duty ID entered.");
                return;
            }

            var duty = await _dutyRepository.GetDutyById(dutyId);

            if (duty != null)
            {
                Console.WriteLine($"\n\nDuty ID: {duty.Id}");
                Console.WriteLine($"Name: {duty.Name}");
                Console.WriteLine($"Description: {duty.Description}");
            }
            else
            {
                Helpers.InfoTextOutput("Duty not found.");
            }
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }
}
