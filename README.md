# CookBook Hub 🍳

A modern recipe sharing platform built with ASP.NET Core, Blazor, and PostgreSQL.

## Features
- 📖 Browse and search recipes
- 👨‍🍳 Create and share your own recipes
- ⭐ Rate and review recipes
- 🏷️ Organize by categories and tags
- 📸 Upload recipe images
- ❤️ Save favorite recipes
- 👤 User profiles and collections

## Tech Stack
- **Framework**: .NET 9 / ASP.NET Core
- **Frontend**: Blazor WebAssembly
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **Validation**: FluentValidation
- **Architecture**: Clean Architecture with Repository Pattern

## Getting Started

### Prerequisites
- .NET 9 SDK
- PostgreSQL
- Docker (optional)

### Running the Application
```bash
# Clone the repository
git clone <repository-url>
cd web-aspnet1

# Run the application
cd CookBookHub.ApiService
dotnet run
```

Access:
- **API**: http://localhost:5000/swagger
- **Web UI**: http://localhost:5001

## Project Structure
```
CookBookHub/
├── CookBookHub.Domain/          # Domain entities
├── CookBookHub.Infrastructure/  # Data access
├── CookBookHub.Application/     # Business logic
├── CookBookHub.ApiService/      # REST API
└── CookBookHub.Web/            # Blazor UI
```

## License
MIT License
