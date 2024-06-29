# Batch4.Api.StudentResultManagementSystem

# Student Result Management System

## Overview

The Student Result Management System is a web application designed to manage student information, courses, and their corresponding results. It is built using ASP.NET Core with Entity Framework Core for database interactions. The application follows the N-Layer architecture, ensuring separation of concerns and maintainability.

## Features

- Manage student information (CRUD operations)
- Manage course information (CRUD operations)
- Manage student results (CRUD operations)
- Relationships between students, courses, and results

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger for API documentation and testing

## Project Structure

The project is structured into three main layers:

1. **Data Access Layer (DAL)**: Handles direct interaction with the database.
2. **Business Logic Layer (BLL)**: Contains business logic and coordinates between the DAL and the API controllers.
3. **API Layer (Controllers)**: Defines API endpoints and maps HTTP requests to BLL methods.

## Models

### StudentModel
        public int StudentId 
        public int RollNo 
        public string? Name 
        public GenderStatus? GenderStatus;
        public int Age 
        public DateTime DateOfBirth 
        public string? UserName 
        public string? Password 
        public string? PhoneNumber 
        public string? Address 

        public ICollection<StudentCourseModel> StudentCourses 
        public ICollection<ResultModel> Results 

### CourseModel
        public int CourseId 
        public string? CourseName 
        public string? Duration 
        public decimal Charges 
        public string? Description 

        public ICollection<StudentCourseModel> StudentCourses  = new List<StudentCourseModel>();
        public ICollection<ResultModel> Results  = new List<ResultModel>();     

### ResultModel
        public int ResultId 
        public int RollNo
        public string? Subject
        public decimal Score
        public EnumStatus Status

        public int CourseId
        [ForeignKey("CourseId")]
        public CourseModel Course

        public int StudentId
        [ForeignKey("StudentId")]
        public StudentModel Student

### StudentCourse (Join Table)

        
        public int StudentId 
        [ForeignKey("StudentId")]
        public StudentModel? Student 

        public int CourseId 
        [ForeignKey("CourseId")]
        public CourseModel? Course 