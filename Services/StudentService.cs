using ConsoleTables;
using DutyAppDB.Models.Dtos.Duty;
using DutyAppDB.Models.Dtos.Students;
using DutyAppDB.Models.Entities;
using DutyAppDB.Repositories;
using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;

namespace DutyAppDB.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task CreateStudent()
    {
        try
        {
            Console.Write("Enter the Student FirstName: ");
            string dutyName = Console.ReadLine()!;

            Console.Write("Enter the Student LastName: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter the Student MiddleName: ");
            string middleName = Console.ReadLine();
            Console.Write("Enter the Student Email: ");
            string? email = Console.ReadLine();
            //Console.Write("Enter the Duty LastName: ");
            //string lastName = Console.ReadLine();



            if (email.EndsWith("@gmail.com"))
            {
                var student = new CreateStudentDto
                {
                    FirstName = dutyName,
                    LastName = lastName,
                    MiddleName = middleName,
                    Email = email,
                    //DateOfBirth
                    //Gender
                };

                int rowsAffected = await _studentRepository.CreateStudent(student);

                if (rowsAffected == 1)
                {
                    Helpers.SuccessTextOutput("Student created successfully!");
                }
                else
                {
                    Helpers.FailureTextOutput("Could not create student!");
                }
            }
            else
            {
                Helpers.FailureTextOutput("Email is invalid");
            }

            
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public async Task GetAllStudent()
    {
        try
        {
            var students = await _studentRepository.GetAllStudent();

            if (students.Count > 0)
            {
                //students = students.OrderBy(student => student.FirstName).ToList();
                var table = new ConsoleTable("ID", "FIRST NAME", "LAST NAME", "MIDDLE NAME", "EMAIL");

                foreach (var student in students)
                {
                    table.AddRow(student.Id, student.FirstName, student.LastName,
                        student.MiddleName, student.Email);
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

    public async Task UpdateStudent()
    {
        try
        {
            Console.Write("Enter the ID of the Student to update: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Helpers.FailureTextOutput("Invalid duty ID entered.");
                return;
            }

            Console.Write("Enter the updated First Name: ");
            string updatedFirstName = Console.ReadLine()!;

            Console.Write("Enter the updated Last Name: ");
            string? updatedLastName = Console.ReadLine();
            Console.Write("Enter the updated Middle Name: ");
            string updatedMiddleName = Console.ReadLine()!;
            Console.Write("Enter the updated Email: ");
            string updatedEmail = Console.ReadLine()!;
            //Console.Write("Enter the updated Date Of Birth: ");
            //string updatedDateOfBirth = Console.ReadLine()!;
            //Console.Write("Enter the updated Gender: ");
            //string updatedGender = Console.ReadLine()!;

            var updatedStudent = new UpdateStudentDto
            {
                FirstName = updatedFirstName,
                LastName = updatedLastName,
                MiddleName = updatedMiddleName,
                Email = updatedEmail,
                //DateOfBirth = updatedDateOfBirth,
                //Gender = updatedGender

            };

            int rowsAffected = await _studentRepository.UpdateStudent(studentId, updatedStudent);

            if (rowsAffected == 1)
            {
                Helpers.SuccessTextOutput("Student updated successfully!");
            }
            else
            {
                Helpers.FailureTextOutput("Could not updateStudent. Make sure the Student ID exists.");
            }
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public async Task DeleteStudent()
    {
        try
        {
            Console.Write("Enter the ID of the Student to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Helpers.FailureTextOutput("Invalid Student ID entered.");
                return;
            }

            Console.Write("Are you sure you want to delete this student? (yes/no): ");
            string confirmation = Console.ReadLine()?.ToLower();

            if (confirmation == "yes")
            {
                int rowsAffected = await _studentRepository.DeleteStudent(studentId);

                if (rowsAffected == 1)
                {
                    Helpers.SuccessTextOutput("Student deleted successfully!");
                }
                else
                {
                    Helpers.InfoTextOutput("No studentwith that ID found.");
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
    public async Task ReadStudentDetail()
    {
        try
        {
            Console.Write("Enter the ID of the student to view: ");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Helpers.FailureTextOutput("Invalid student ID entered.");
                return;
            }

            var student = await _studentRepository.GetStudentById(studentId);

            if (student != null)
            {
                Console.WriteLine($"\n\nDuty ID: {student.Id}");
                Console.WriteLine($"FirstName: {student.FirstName}");
                Console.WriteLine($"LastName: {student.LastName}");
                Console.WriteLine($"MiddleName: {student.MiddleName}");
                Console.WriteLine($"Email: {student.Email}");
                //Console.WriteLine()
            }
            else
            {
                Helpers.InfoTextOutput("Student not found.");
            }
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }


}
