using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DistrictId { get; set; }
        public District? District { get; set; }

        public ICollection<Class>? Classes { get; set; }
        public ICollection<Teacher>? Teachers { get; set; }
    }
}
