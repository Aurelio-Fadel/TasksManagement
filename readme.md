# Tasks Management

## Task and People Manager in .NET 8

This application is a manager for people and tasks, allowing you to register people and assign tasks to them. I developed this application to test and enhance my skills in .NET 8, databases, and APIs while providing a practical solution for task management.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)

## Technologies Used

- **.NET 8:** Development platform.
- **Entity Framework v8.0.10:** ORM for interacting with the database.
- **SQL Server:** Relational database management system.
- **Swagger:** Tool for API documentation.
- **AutoMapper:** Library for object mapping.
- **Dependency Injection:** Facilitates dependency injection.

## Installation

Follow the steps below to install the project:

1. Clone the repository:

   ```bash
   git clone https://github.com/Aurelio-Fadel/TasksManagement.git
   cd TasksManagement
   
2. Restore the project dependencies:
dotnet restore

3. Apply the migrations:
dotnet ef database update


## Usage

This application allows you to manage people and tasks. You can create people, assign tasks, and manage their statuses.

Endpoints
1. Get People
GET /api/person/getPeople

2. Create People
POST /api/person/createPeople

Example JSON:

json
{
    "name": "João Silva",
    "email": "joao.silva@email.com",
    "birth": "1985-05-15T00:00:00",
    "tasks": [
        {
            "title": "Finalizar relatório",
            "description": "Relatório financeiro do trimestre.",
            "status": "Em andamento"
        }
    ]
}

3. Update Person
PUT /api/person/updatePeople

Example JSON:
json
{
    "id": 1,
    "name": "João Guimarães",
    "email": "joao.silva@email.com",
    "birth": "1985-05-15T00:00:00",
    "tasks": [
        {
            "title": "Finalizar relatório",
            "description": "Relatório financeiro do trimestre.",
            "status": "Em andamento"
        }
    ]
}

4. Delete Person
DELETE /api/person/deletePeople/{personId}

5. Get Tasks
GET /api/task/getTasks

6. Create Task
POST /api/task/createTask

Example JSON:
json
{
    "title": "Finalizar relatório",
    "description": "Relatório financeiro do trimestre.",
    "status": "Em andamento",
    "creationDate": "2023-10-30T10:00:00",
    "personId": 1
}

7. Update Task
PUT /api/task/updateTask

Example JSON:
json
{
    "id": 1,
    "title": "Finalizar relatório",
    "description": "Relatório financeiro do trimestre.",
    "status": "Finalizado",
    "creationDate": "2023-10-30T10:00:00",
    "personId": 1
}

8. Delete Task
DELETE /api/task/deleteTask/{taskId}