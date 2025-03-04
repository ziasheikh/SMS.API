using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;
using SMS.Shared.DTOs;

namespace SMS.Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentReportDto> GetStudentReportAsync(int studentId);
    }
}
