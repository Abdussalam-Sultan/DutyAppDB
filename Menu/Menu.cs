using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;

namespace DutyAppDB.Menu;

public class Menu
{
    public static void MainMenu(IDutyService _dutyService, IStudentService _studentService, IDutyAssignmentService _dutyAssignmentService)
    {
        bool flag = true;

        try
        {
            while (flag)
            {
                PrintMenu();
                Helpers.InfoTextOutput("\nPlease enter your preferred option: ");
                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        StudentMenu(_studentService);
                        break;
                    case "2":
                        DutyMenu(_dutyService);
                        break;
                    case "3":
                        DutyAssignmentMenu(_dutyAssignmentService);
                        //Console.WriteLine("Not yet implemented");
                        break;

                    case "0":
                        flag = false;
                        break;
                    case "":
                        Console.WriteLine("\nPlease select an option\n");
                        break;
                    default:
                         Helpers.FailureTextOutput("Invalid input!");
                        //throw new InvalidOperationException("Unknown operation!");
                        break; 
                }
            }
        }
        catch (InvalidOperationException ioe)
        {
            Helpers.FailureTextOutput(ioe.Message);
        }
        catch (Exception ex)
        {
            Helpers.FailureTextOutput(ex.Message);
        }
    }

    public static void DutyMenu(IDutyService _dutyService)
    {
        var flag = true;

        while (flag)
        {
            PrintDutyMenu();
            Helpers.InfoTextOutput("\nPlease enter your option: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    _dutyService.CreateDuty();
                    Console.WriteLine("");
                    break;
                case "2":
                    _dutyService.GetAllDuty();
                    Console.WriteLine("");
                    break;
                case "3":
                    _dutyService.ViewDutyDetail();
                    Console.WriteLine("");
                    break;
                case "4":
                    _dutyService.UpdateDuty();
                    Console.WriteLine("");
                    break;
                case "5":
                    _dutyService.DeleteDuty();
                    Console.WriteLine("");
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Helpers.FailureTextOutput("Invalid input!");
                    break;
            }
        }
    }

    public static void DutyAssignmentMenu(IDutyAssignmentService _dutyAssignmentService)
    {
        var flag = true;

        while (flag)
        {
            PrintDutyAssignmentMenu();
            Helpers.InfoTextOutput("\nPlease enter your option: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    _dutyAssignmentService.AssignDutyToStudent();
                    Console.WriteLine("");
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Helpers.FailureTextOutput("Invalid input!");
                    break;
            }
        }
    }

    public static void StudentMenu(IStudentService _studentService)
    {
        var flag = true;

        while (flag)
        {
            PrintStudentMenu();
            Helpers.InfoTextOutput("\nPlease enter your option: ");
            string option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    _studentService.CreateStudent();
                    Console.WriteLine("");
                    break;
                case "2":
                    _studentService.GetAllStudent();
                    Console.WriteLine("");
                    break;
                case "3":
                    _studentService.ReadStudentDetail();
                    Console.WriteLine("");
                    break;
                case "4":
                    _studentService.UpdateStudent();
                    Console.WriteLine("");
                    break;
                case "5":
                    _studentService.DeleteStudent();
                    Console.WriteLine("");
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Helpers.FailureTextOutput("Invalid input!");
                    break;
            }
        }
    }

    static void PrintMenu()
    {
        Console.WriteLine("Enter 1 to Student Menu");
        Console.WriteLine("Enter 2 to Duty Menu");
        Console.WriteLine("Enter 3 to Duty Assignment Menu");
        Console.WriteLine("Enter 0 to exit.");
    }

    static void PrintDutyMenu()
    {
        Console.WriteLine("Enter 1 to Create New Duty");
        Console.WriteLine("Enter 2 to View All Duties");
        Console.WriteLine("Enter 3 to View a Duty");
        Console.WriteLine("Enter 4 to Update a Duty");
        Console.WriteLine("Enter 5 to Delete a Duty");
        Console.WriteLine("Enter 0 to go back to main menu.");
    }
    static void PrintDutyAssignmentMenu()
    {
        Console.WriteLine("Enter 1 to Assign Duty to a Student");
        Console.WriteLine("Enter 0 to go back to main menu.");
    }

    static void PrintStudentMenu()
    {
        Console.WriteLine("Enter 1 to Create New Student");
        Console.WriteLine("Enter 2 to View All Students");
        Console.WriteLine("Enter 3 to View a Student");
        Console.WriteLine("Enter 4 to Update a Student");
        Console.WriteLine("Enter 5 to Delete a Student");
        Console.WriteLine("Enter 0 to go back to main menu.");
    }
}


