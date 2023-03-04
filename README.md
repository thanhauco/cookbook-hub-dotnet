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
│   ├── Entities/
│   └── Interfaces/
├── CookBookHub.Infrastructure/  # Data access
│   ├── Data/
│   ├── Repositories/
│   └── Seed/
├── CookBookHub.Application/     # Business logic
│   ├── DTOs/
│   ├── Services/
│   ├── Validators/
│   └── Interfaces/
├── CookBookHub.ApiService/      # REST API
│   └── Controllers/
└── CookBookHub.Web/            # Blazor UI
    ├── Components/
    │   ├── Pages/
    │   └── Layout/
    └── wwwroot/
```

## API Endpoints

See [API_DOCUMENTATION.md](API_DOCUMENTATION.md) for detailed API documentation.

### Quick Reference
- `GET /api/recipes` - Get all recipes
- `GET /api/recipes/{id}` - Get recipe by ID
- `POST /api/recipes` - Create new recipe
- `GET /api/categories` - Get all categories
- `GET /api/users` - Get all users
- `POST /api/reviews` - Create review

## Contributing

We welcome contributions! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## Architecture

See [ARCHITECTURE.md](ARCHITECTURE.md) for detailed architecture documentation.

## License
MIT License - see [LICENSE](LICENSE) for details
