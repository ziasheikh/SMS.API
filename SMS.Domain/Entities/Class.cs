using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SchoolId { get; set; }
        public School? School { get; set; }

        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public ICollection<StudentClass>? StudentClasses { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
