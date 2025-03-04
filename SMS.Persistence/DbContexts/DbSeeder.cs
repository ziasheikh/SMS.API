using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain.Entities;

namespace SMS.Persistence.DbContexts
{
    public static class DbSeeder
    {
        public static void Seed(SMSDbContext context)
        {
            if (!context.Districts.Any())
            {
                // District
                var district = new District { Name = "Central District" };
                context.Districts.Add(district);
                context.SaveChanges();

                // Schools
                var school1 = new School { Name = "Greenwood High", DistrictId = district.Id };
                var school2 = new School { Name = "Riverside Academy", DistrictId = district.Id };

                context.Schools.AddRange(school1, school2);
                context.SaveChanges();

                // Teachers (11 Regular + 1 Substitute)
                var teachers = new List<Teacher>
                {
                    new Teacher { Name = "John Doe" },
                    new Teacher { Name = "Sarah Smith" },
                    new Teacher { Name = "Michael Johnson" },
                    new Teacher { Name = "Emma Brown" },
                    new Teacher { Name = "David Wilson" },
                    new Teacher { Name = "Sophia Miller" },
                    new Teacher { Name = "James Anderson" },
                    new Teacher { Name = "Olivia Thomas" },
                    new Teacher { Name = "William Martinez" },
                    new Teacher { Name = "Benjamin Harris" },
                    new Teacher { Name = "Charlotte White" },

                    // Substitute Teacher
                    new Teacher { Name = "Liam Substitute", IsSubstitute = true }
                };
                context.Teachers.AddRange(teachers);
                context.SaveChanges();

                // 20 Students
                var students = new List<Student>();
                for (int i = 1; i <= 20; i++)
                {
                    students.Add(new Student { Name = $"Student {i}" });
                }
                context.Students.AddRange(students);
                context.SaveChanges();

                // Classes and Assign Teachers
                var classes = new List<Class>
                {
                    new Class { Name = "Math 101", SchoolId = school1.Id, TeacherId = teachers[0].Id },
                    new Class { Name = "Science 101", SchoolId = school1.Id, TeacherId = teachers[1].Id },
                    new Class { Name = "History 101", SchoolId = school2.Id, TeacherId = teachers[2].Id },
                    new Class { Name = "Physics 102", SchoolId = school1.Id, TeacherId = teachers[3].Id },
                    new Class { Name = "Chemistry 103", SchoolId = school2.Id, TeacherId = teachers[4].Id },
                    new Class { Name = "Biology 104", SchoolId = school1.Id, TeacherId = teachers[5].Id },
                    new Class { Name = "English 105", SchoolId = school1.Id, TeacherId = teachers[6].Id },
                    new Class { Name = "Geography 106", SchoolId = school2.Id, TeacherId = teachers[7].Id },
                    new Class { Name = "Economics 107", SchoolId = school1.Id, TeacherId = teachers[8].Id },
                    new Class { Name = "Computer Science 108", SchoolId = school2.Id, TeacherId = teachers[9].Id }
                };
                context.Classes.AddRange(classes);
                context.SaveChanges();

                // Assign Students to Classes
                var studentClasses = new List<StudentClass>();
                foreach (var student in students)
                {
                    foreach (var cls in classes)
                    {
                        studentClasses.Add(new StudentClass { StudentId = student.Id, ClassId = cls.Id });
                    }
                }
                context.StudentClasses.AddRange(studentClasses);
                context.SaveChanges();

                // Assign Grades Letter
                var grades = new List<Grade>();
                string[] letterGrades = { "A", "B", "C", "D", "F" };
                var random = new Random();

                foreach (var student in students)
                {
                    foreach (var cls in classes)
                    {
                        grades.Add(new Grade
                        {
                            StudentId = student.Id,
                            ClassId = cls.Id,
                            GradeLetter = letterGrades[random.Next(letterGrades.Length)]
                        });
                    }
                }
                context.Grades.AddRange(grades);
                context.SaveChanges();
            }
        }
    }
}
