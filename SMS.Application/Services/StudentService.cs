using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Interfaces;
using SMS.Domain.Entities;
using SMS.Infrastructure.Interfaces;
using SMS.Persistence.DbContexts;
using SMS.Shared.DTOs;

namespace SMS.Application.Repositories
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentReportDto> GetStudentReportAsync(int studentId)
        {
            var student = await _studentRepository.GetStudentWithDetailsAsync(studentId);
            if (student == null) throw new KeyNotFoundException("Student not found.");

            return new StudentReportDto
            {
                StudentId = student.Id,
                StudentName = student.Name,
                Classes = student.StudentClasses.Select(sc => new ClassReportDto
                {
                    ClassName = sc.Class.Name,
                    TeacherName = sc.Class.Teacher.Name,
                    Grade = sc.Class.Grades.FirstOrDefault(g => g.StudentId == student.Id)?.GradeLetter ?? "N/A"
                }).ToList()
            };

        }
    }
}
