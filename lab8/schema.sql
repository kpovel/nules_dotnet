CREATE TABLE CourseWork (
    Id INT PRIMARY KEY IDENTITY,
    Student NVARCHAR(100),
    Group NVARCHAR(50),
    Title NVARCHAR(200),
    Subject NVARCHAR(100),
    Supervisor NVARCHAR(100),
    Year INT,
    Grade INT
)

