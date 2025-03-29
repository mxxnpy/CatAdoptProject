# Patinhas API - Cat Adoption Backend

## Presentation
Backend API for a cat adoption NGO, built with ASP.NET Core and Entity Framework Core.

## Features
- Cat registration and management
- Adoption process tracking
- Cat search functionality
- RESTful API endpoints
- Swagger documentation

## Technical Stack
- ASP.NET Core 6.0
- Entity Framework Core
- SQLite Database
- C#

## Project Structure
```bash
Patinhas/
├── Patinhas.API/         # Main API project
│   ├── Controllers/      # API endpoints
│   ├── Data/             # Database context and models
│   ├── Services/         # Business logic
│   └── Migrations/       # Database migrations
└── Patinhas.Common/      # Shared models
```

## Getting Started

### Prerequisites
- .NET 6.0 SDK
- Visual Studio Code or Visual Studio
- SQLite (automatically included in the project)

### Installation

1. Clone the repository:
    ```bash
    git clone [repository-url]
    cd Patinhas
    ```

2. Restore packages and build:
    ```bash
    dotnet restore
    dotnet build
    ```

3. Run database migrations:
    ```bash
    dotnet ef database update
    ```

4. Run the application:
    ```bash
    dotnet run
    ```

### API Documentation
Access the Swagger UI at:

[http://localhost:5071/swagger](http://localhost:5071/swagger)

### Endpoints

- `GET /api/cats` - List all cats
- `GET /api/cats/{id}` - Get cat by ID
- `POST /api/cats` - Add new cat
- `PUT /api/cats/{id}` - Update cat
- `DELETE /api/cats/{id}` - Remove cat
- `POST /api/cats/{id}/adopt` - Mark cat as adopted
