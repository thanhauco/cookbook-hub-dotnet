# CookBook Hub - Getting Started Guide

## Welcome! 👋

This guide will help you get started with CookBook Hub, whether you're a developer looking to contribute or a user wanting to deploy your own instance.

## For Users

### Quick Start

1. **Visit the Demo**: Try out CookBook Hub at [demo.cookbookhub.com](https://demo.cookbookhub.com)

2. **Browse Recipes**: Explore thousands of recipes from our community

3. **Create an Account**: Sign up to start sharing your own recipes

4. **Share Your First Recipe**: Click "Create Recipe" and fill in the details

### Key Features

- **Discover Recipes**: Search by ingredients, cuisine, or difficulty
- **Save Favorites**: Bookmark recipes you love
- **Rate & Review**: Share your cooking experience
- **Follow Chefs**: Stay updated with your favorite recipe creators

## For Developers

### Prerequisites

Before you begin, ensure you have:
- .NET 9 SDK installed
- PostgreSQL 15+ running
- Git installed
- Your favorite IDE (VS Code, Visual Studio, or Rider)

### Installation Steps

#### 1. Clone the Repository
```bash
git clone https://github.com/thanhauco/cookbook-hub.git
cd cookbook-hub
```

#### 2. Set Up the Database
```bash
# Create database
createdb cookbook_hub

# Update connection string in appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=cookbook_hub;Username=postgres;Password=yourpassword"
  }
}
```

#### 3. Run Migrations
```bash
cd CookBookHub.Infrastructure
dotnet ef database update
```

#### 4. Seed Sample Data
```bash
cd ../CookBookHub.ApiService
dotnet run --seed
```

#### 5. Start the Application
```bash
# Terminal 1 - API
cd CookBookHub.ApiService
dotnet run

# Terminal 2 - Web
cd CookBookHub.Web
dotnet run
```

#### 6. Access the Application
- API: http://localhost:5000
- Web UI: http://localhost:5001
- Swagger: http://localhost:5000/swagger

### Using Docker

For a simpler setup, use Docker:

```bash
docker-compose up -d
```

This will start:
- PostgreSQL database on port 5432
- API service on port 5000
- Web UI on port 5001

## Project Structure

```
CookBookHub/
├── CookBookHub.Domain/          # Domain entities and interfaces
├── CookBookHub.Infrastructure/  # Data access and repositories
├── CookBookHub.Application/     # Business logic and services
├── CookBookHub.ApiService/      # REST API controllers
└── CookBookHub.Web/            # Blazor WebAssembly UI
```

## Next Steps

### For Users
- Explore the [FAQ](FAQ.md) for common questions
- Check out the [Roadmap](ROADMAP.md) for upcoming features
- Join our community discussions

### For Developers
- Read the [Contributing Guide](CONTRIBUTING.md)
- Review the [Architecture Documentation](ARCHITECTURE.md)
- Check the [API Documentation](API_DOCUMENTATION.md)
- Run the test suite: `dotnet test`

## Common Tasks

### Creating a Recipe
1. Navigate to "Create Recipe"
2. Fill in title, description, and instructions
3. Add ingredients with quantities
4. Upload an image (optional)
5. Select category and difficulty
6. Click "Publish Recipe"

### Searching for Recipes
1. Use the search bar in the navigation
2. Enter keywords, ingredients, or chef names
3. Apply filters for category, difficulty, or cook time
4. Browse results and click to view details

### Managing Your Profile
1. Click your avatar in the top right
2. Select "Profile" to view your recipes
3. Click "Settings" to update your information
4. Manage your favorite recipes in "Favorites"

## Troubleshooting

### Database Connection Issues
- Verify PostgreSQL is running: `pg_isready`
- Check connection string in appsettings.json
- Ensure database exists: `psql -l`

### Build Errors
- Clean and rebuild: `dotnet clean && dotnet build`
- Restore packages: `dotnet restore`
- Check .NET version: `dotnet --version`

### Port Already in Use
- Change ports in launchSettings.json
- Or stop the conflicting process

## Getting Help

- **Documentation**: Check our comprehensive docs
- **Issues**: Report bugs on [GitHub Issues](https://github.com/thanhauco/cookbook-hub/issues)
- **Discussions**: Join [GitHub Discussions](https://github.com/thanhauco/cookbook-hub/discussions)
- **Email**: Contact support@cookbookhub.com

## Resources

- [API Documentation](API_DOCUMENTATION.md)
- [Architecture Guide](ARCHITECTURE.md)
- [Deployment Guide](DEPLOYMENT.md)
- [Testing Guide](TESTING.md)
- [Performance Guide](PERFORMANCE.md)

## License

CookBook Hub is open-source software licensed under the MIT license. See [LICENSE](LICENSE) for details.

---

Happy Cooking! 🍳
