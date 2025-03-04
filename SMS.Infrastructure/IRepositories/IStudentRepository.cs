using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentWithDetailsAsync(int studentId);
    }
}
