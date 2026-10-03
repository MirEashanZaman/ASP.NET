CREATE DATABASE StudentCourseDB;
GO
USE StudentCourseDB;
GO

CREATE TABLE Student (
    StudentId INT PRIMARY KEY,
    StudentName VARCHAR(50)
);

CREATE TABLE Course (
    CourseId INT PRIMARY KEY,
    CourseName VARCHAR(50)
);

CREATE TABLE CourseTakenByStudent (
    Id INT PRIMARY KEY,
    StudentId INT FOREIGN KEY REFERENCES Student(StudentId),
    CourseId INT FOREIGN KEY REFERENCES Course(CourseId),
    FinalMark INT
);

INSERT INTO Student VALUES (1, 'Eashan'), (2, 'Nabeeha'), (3, 'Aryan');
INSERT INTO Course VALUES (101, 'ASP .NET'), (102, 'C#'), (103, 'Web Technologies');
INSERT INTO CourseTakenByStudent VALUES
(1, 1, 101, 85),
(2, 1, 102, 78),
(3, 2, 101, 60),
(4, 3, 103, 92),
(5, 2, 102, 70);
GO