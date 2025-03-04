using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Infrastructure.Interfaces;
using SMS.Persistence.DbContexts;

namespace SMS.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SMSDbContext _context;

        public StudentRepository(SMSDbContext context)
        {
            _context = context;
        }

        public async Task<Student?> GetStudentWithDetailsAsync(int studentId)
        {
            var student = await _context.Students
                .Where(s => s.Id == studentId)
                .Include(s => s.StudentClasses)
                    .ThenInclude(sc => sc.Class)
                        .ThenInclude(c => c.Teacher)
                .Include(s => s.StudentClasses)
                    .ThenInclude(sc => sc.Class)
                        .ThenInclude(c => c.Grades)
                .FirstOrDefaultAsync();

            return student ?? null;
        }

    }
}
