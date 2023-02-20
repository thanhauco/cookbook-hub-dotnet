# CookBook Hub - Architecture

## System Overview
CookBook Hub is a recipe sharing platform built with Clean Architecture principles, separating concerns into distinct layers.

## Architecture Layers

### 1. Domain Layer (`CookBookHub.Domain`)
- **Entities**: Core business objects (Recipe, User, Category, Review, Ingredient)
- **Interfaces**: Repository and Unit of Work contracts
- **Enums**: DifficultyLevel

### 2. Infrastructure Layer (`CookBookHub.Infrastructure`)
- **Data**: EF Core DbContext and configurations
- **Repositories**: Generic repository implementation
- **Seed**: Database seeding logic

### 3. Application Layer (`CookBookHub.Application`)
- **DTOs**: Data transfer objects for API communication
- **Services**: Business logic implementation
- **Validators**: FluentValidation rules
- **Interfaces**: Service contracts

### 4. API Layer (`CookBookHub.ApiService`)
- **Controllers**: REST API endpoints
- **Middleware**: Error handling and logging

### 5. Web Layer (`CookBookHub.Web`)
- **Pages**: Blazor WebAssembly components
- **Layout**: Navigation and footer components

## Data Flow

```
User Request
    ↓
API Controller
    ↓
Application Service
    ↓
Repository
    ↓
Database (PostgreSQL)
```

## Key Design Patterns

1. **Repository Pattern**: Abstraction over data access
2. **Unit of Work**: Transaction management
3. **Dependency Injection**: Loose coupling between layers
4. **DTO Pattern**: Data transfer between layers
5. **Clean Architecture**: Separation of concerns

## Database Schema

### Core Tables
- **Users**: User profiles and authentication
- **Categories**: Recipe categorization
- **Recipes**: Recipe information and metadata
- **Ingredients**: Recipe ingredients with quantities
- **Reviews**: User ratings and comments
- **RecipeFavorites**: User bookmarks

### Relationships
- User → Recipes (1:N)
- User → Reviews (1:N)
- Recipe → Category (N:1)
- Recipe → Ingredients (1:N)
- Recipe → Reviews (1:N)
- User → RecipeFavorites → Recipe (M:N)

## Technology Stack

- **.NET 9**: Framework
- **ASP.NET Core**: Web API
- **Blazor WebAssembly**: Frontend
- **Entity Framework Core**: ORM
- **PostgreSQL**: Database
- **FluentValidation**: Input validation

## Security Considerations

- Input validation on all DTOs
- SQL injection prevention via EF Core
- XSS protection in Blazor
- CORS configuration for API
- Rate limiting (planned)

## Performance Optimizations

- Eager loading for related entities
- Async/await throughout
- Pagination for large datasets (planned)
- Caching for frequently accessed data (planned)
