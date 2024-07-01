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

## Database Schema

### Tables

- **Tbl_Student**: Stores student information.
- **Tbl_Course**: Stores course information.
- **Tbl_Result**: Stores result information and links students to their results and courses.

## API Endpoints

### Students

- `GET /api/student`: Get all students.
- `GET /api/student/{id}`: Get a student by ID.
- `POST /api/student`: Create a new student.
- `PUT /api/student/{id}`: Update a student by ID.
- `DELETE /api/student/{id}`: Delete a student by ID.

### Results

- `GET /api/result`: Get all results.
- `GET /api/result/{id}`: Get a result by ID.
- `GET /api/result/rollno/{rollNo}/course/{courseId}`: Get a result by roll number and course ID.
- `POST /api/result`: Create a new result.
- `PUT /api/result/{id}`: Update a result by ID.
- `DELETE /api/result/{id}`: Delete a result by ID.

