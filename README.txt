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


RAW Data that will be populated after running the DBSeeder followed by migrations
Districts
Central District

Schools
Greenwood High (District: Central District)
Riverside Academy (District: Central District)

Teachers (11 Regular + 1 Substitute)
John Doe (Regular)
Sarah Smith (Regular)
Michael Johnson (Regular)
Emma Brown (Regular)
David Wilson (Regular)
Sophia Miller (Regular)
James Anderson (Regular)
Olivia Thomas (Regular)
William Martinez (Regular)
Benjamin Harris (Regular)
Charlotte White (Regular)
Liam Substitute (Substitute)

Students
Student 1
Student 2
Student 3
Student 4
Student 5
Student 6
Student 7
Student 8
Student 9
Student 10
Student 11
Student 12
Student 13
Student 14
Student 15
Student 16
Student 17
Student 18
Student 19
Student 20

Classes
Math 101 (Greenwood High, Teacher: John Doe)
Science 101 (Greenwood High, Teacher: Sarah Smith)
History 101 (Riverside Academy, Teacher: Michael Johnson)
Physics 102 (Greenwood High, Teacher: Emma Brown)
Chemistry 103 (Riverside Academy, Teacher: David Wilson)
Biology 104 (Greenwood High, Teacher: Sophia Miller)
English 105 (Greenwood High, Teacher: James Anderson)
Geography 106 (Riverside Academy, Teacher: Olivia Thomas)
Economics 107 (Greenwood High, Teacher: William Martinez)
Computer Science 108 (Riverside Academy, Teacher: Benjamin Harris)
Student-Class Assignments (Every student in every class)
Each student (1-20) is assigned to all 10 classes.

Grades (Randomized for Each Student per Class)
Each student has a random letter grade for each class. Example for Student 1:
Math 101 → A
Science 101 → B
History 101 → C
Physics 102 → A
Chemistry 103 → F
Biology 104 → B
English 105 → D
Geography 106 → C
Economics 107 → A
Computer Science 108 → B
