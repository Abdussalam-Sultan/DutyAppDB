using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Repositories;
using DutyAppDB.Services.Contracts;
using DutyAppDB.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;
using DutyAppDB.Menu;

class Program
{
    static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        var services = new ServiceCollection();

        services.AddScoped<IDbConnection>(sp =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var connection = new MySqlConnection(connectionString);

            return connection;
        });

        services.AddScoped<IDutyRepository, DutyRepository>();
        services.AddScoped<IDutyService, DutyService>();

        services.AddScoped<IDutyAssignmentRepository, DutyAssignmentRepository>();
        services.AddScoped<IDutyAssignmentService, DutyAssignmentService>();

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentService, StudentService>();

        var serviceProvider = services.BuildServiceProvider();

        var dutyService = serviceProvider.GetRequiredService<IDutyService>();
        var dutyAssignmentService = serviceProvider.GetRequiredService<IDutyAssignmentService>();
        var studentService = serviceProvider.GetRequiredService<IStudentService>();

        Menu.MainMenu(dutyService, studentService, dutyAssignmentService);
        //Menu.MainMenu(studentService);
    }
}