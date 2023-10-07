﻿using DutyAppDB.Models.Entities;
using DutyAppDB.Repositories;
using DutyAppDB.Repositories.Contracts;
using DutyAppDB.Services.Contracts;
using DutyAppDB.Shared;
using System.Threading.Tasks;

namespace DutyAppDB.Services
{
    public class DutyAssignmentService : IDutyAssignmentService
    {
        private readonly IDutyRepository _dutyRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IDutyAssignmentRepository _dutyAssignmentRepository;

        public DutyAssignmentService(IDutyAssignmentRepository dutyAssignmentRepository)
        {
            _dutyAssignmentRepository = dutyAssignmentRepository;
        }

        public async Task AssignDutyToStudent()
        {
            try
            {
                Console.Write("Enter the ID of the Duty to assign: ");
                if (!int.TryParse(Console.ReadLine(), out int dutyId))
                {
                    Helpers.FailureTextOutput("Invalid input for Duty ID.");
                    return;
                }


                Console.Write("Enter the ID of the Student to assign: ");
                if (!int.TryParse(Console.ReadLine(), out int studentId))
                {
                    Helpers.FailureTextOutput("Invalid input for Student ID.");
                    return;
                }

                var existingDuty = await _dutyRepository.GetDutyById(dutyId);
                var existingStudent = await _studentRepository.GetStudentById(studentId);

                if (existingDuty == null)
                {
                    Helpers.FailureTextOutput($"Duty with ID {dutyId} not found.");
                    return;
                }

                if (existingStudent == null)
                {
                    Helpers.FailureTextOutput($"Student with ID {studentId} not found.");
                    return;
                }


                var dutyAssignment = new DutyAssignment
                {
                    DutyId = dutyId.ToString(),
                    StudentId = studentId.ToString()
                };

                int rowsAffected = await _dutyAssignmentRepository.AssignDutyToStudent(dutyAssignment);

                if (rowsAffected == 1)
                {
                    Helpers.SuccessTextOutput("Duty assigned to student successfully!");
                }
                else
                {
                    Helpers.FailureTextOutput("Could not assign duty to student.");
                }
            }
            catch (Exception ex)
            {
                Helpers.FailureTextOutput(ex.Message);
            }
        }
    }
}

