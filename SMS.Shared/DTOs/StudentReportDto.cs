using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Shared.DTOs
{
    public class StudentReportDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public List<ClassReportDto> Classes { get; set; }
    }

}
