﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<StudentClass>? StudentClasses { get; set; }
    }
}
