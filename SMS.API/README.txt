I have implemented Clean Architecture in the Homework task assigned to me. Chosen this to ensure scalability,
maintainability, and separation of concerns.

Project Structure
1. SMS.API (Presentation Layer)
Contains: Controllers
Purpose: Handles HTTP requests and responses.
Example: StudentsController has a GetStudentReport method that fetches a student’s report card.

2. SMS.Domain (Core Domain Layer)
Contains: Entities & Core Business Rules
Purpose: Represents the business models such as Student, Teacher, Class, School, District, etc.
Example: The Student entity has properties like Id, Name, Classes, Grades, etc.

3. SMS.Application (Business Logic Layer)
Contains: Services & Interfaces (IServices)
Purpose: Implements business logic and coordinates use cases.
Example: IStudentService and StudentService handle logic for fetching student details and generating a report.

4. SMS.Infrastructure (Infrastructure Layer)

Contains: Repositories & IRepositories
Purpose: Handles database interactions and external services.
Example: IStudentRepository defines the contract, and StudentRepository implements fetching students from the database.

5. SMS.Persistence (Data Access Layer)
Contains: DbContext & Migrations
Purpose: Manages Entity Framework Core interactions and database schema.
Example: ApplicationDbContext includes DbSets for Students, Teachers, Classes, etc., and migrations are used to
update the database schema.

6. SMS.Shared (Common Layer)
Contains: DTOs (Data Transfer Objects)
Purpose: Defines structures for data exchange between layers.
Example: StudentReportDto ensures only necessary data is passed when retrieving a student’s report.


Flow of a Student Report Request (GetStudentReport)
The API receives a request in StudentController.
It calls StudentService from SMS.Application.
StudentService fetches data from StudentRepository in SMS.Infrastructure.
StudentRepository queries the database via ApplicationDbContext in SMS.Persistence.
The retrieved data is mapped to a StudentReportDto from SMS.Shared and returned to the API.
The API returns the report as an HTTP response.


Database Structure

Entity Relationships:
District & Schools: One-to-Many (A District has multiple Schools, a School belongs to one District).
School & Classes: One-to-Many (A School has multiple Classes, a Class belongs to one School).
School & Teachers: One-to-Many (A School has multiple Teachers, a Teacher belongs to one School).
Class & Teacher: One-to-One (A Class has one primary Teacher, a Teacher can teach multiple Classes).
Student & Classes: Many-to-Many (A Student can enroll in multiple Classes, a Class has multiple Students).
This relationship is handled via StudentClass.
Class & Grades: One-to-Many (A Class has multiple Grades, a Grade belongs to one Class).
Student & Grades: One-to-Many (A Student has multiple Grades, a Grade belongs to one Student).

Tables:
Districts (Id, Name)
Schools (Id, Name, DistrictId)
Teachers (Id, Name, IsSubstitute, SchoolId)
Students (Id, Name)
Classes (Id, Name, SchoolId, TeacherId)
StudentClasses (StudentId, ClassId) (Join Table for Many-to-Many relationship)
Grades (Id, StudentId, ClassId, GradeLetter)