# CookBook Hub 🍳

[![Build Status](https://img.shields.io/github/workflow/status/thanhauco/cookbook-hub/CI-CD)](https://github.com/thanhauco/cookbook-hub/actions)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
[![Version](https://img.shields.io/badge/version-1.0.0-green.svg)](CHANGELOG.md)
[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/)

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

## Documentation

- [API Documentation](API_DOCUMENTATION.md) - REST API endpoints and examples
- [Architecture](ARCHITECTURE.md) - System design and patterns
- [Contributing](CONTRIBUTING.md) - How to contribute to the project
- [Changelog](CHANGELOG.md) - Version history and changes
- [Deployment](DEPLOYMENT.md) - Deployment guides for various platforms
- [Security](SECURITY.md) - Security policy and vulnerability reporting
- [Testing](TESTING.md) - Testing strategies and examples
- [Performance](PERFORMANCE.md) - Performance optimization guide
- [FAQ](FAQ.md) - Frequently asked questions
- [Roadmap](ROADMAP.md) - Future plans and features
- [Code of Conduct](CODE_OF_CONDUCT.md) - Community guidelines

## License
MIT License - see [LICENSE](LICENSE) for details
