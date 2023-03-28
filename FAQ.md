# Frequently Asked Questions (FAQ)

## General

### What is CookBook Hub?
CookBook Hub is a modern recipe sharing platform that allows users to discover, share, and manage recipes. Built with .NET 9 and Blazor, it provides a seamless experience for both home cooks and professional chefs.

### Is CookBook Hub free to use?
Yes, CookBook Hub is open-source and free to use. You can deploy your own instance or contribute to the project.

### What technologies does CookBook Hub use?
- Backend: .NET 9, ASP.NET Core, Entity Framework Core
- Frontend: Blazor WebAssembly
- Database: PostgreSQL
- Validation: FluentValidation
- Architecture: Clean Architecture with Repository Pattern

## Features

### Can I search for recipes by ingredients?
Yes, the search functionality allows you to find recipes by title, description, or ingredients.

### How do I create a recipe?
Navigate to the "Create Recipe" page, fill in the details including title, description, ingredients, and instructions, then click "Publish Recipe".

### Can I save my favorite recipes?
Yes, you can save recipes to your favorites by clicking the heart icon on any recipe card.

### How does the rating system work?
Users can rate recipes on a scale of 1-5 stars. The average rating is displayed on each recipe.

## Technical

### How do I run CookBook Hub locally?
```bash
# Clone the repository
git clone https://github.com/yourusername/cookbook-hub.git

# Set up the database
createdb cookbook_hub

# Run migrations
cd CookBookHub.Infrastructure
dotnet ef database update

# Run the application
cd ../CookBookHub.ApiService
dotnet run
```

See [DEPLOYMENT.md](DEPLOYMENT.md) for detailed instructions.

### How do I contribute?
See [CONTRIBUTING.md](CONTRIBUTING.md) for contribution guidelines.

### What database does it use?
CookBook Hub uses PostgreSQL by default, but can be configured to use other databases supported by Entity Framework Core.

### Is there an API?
Yes, CookBook Hub provides a RESTful API. See [API_DOCUMENTATION.md](API_DOCUMENTATION.md) for details.

### How do I deploy to production?
See [DEPLOYMENT.md](DEPLOYMENT.md) for deployment guides for Azure, AWS, and Docker.

## Development

### How do I add a new feature?
1. Create a feature branch
2. Implement your feature following the architecture
3. Write tests
4. Submit a pull request

### Where should I add business logic?
Business logic belongs in the Application layer, specifically in Service classes.

### How do I add a new entity?
1. Create the entity in `CookBookHub.Domain/Entities`
2. Add DbSet to `CookBookDbContext`
3. Create DTOs in `CookBookHub.Application/DTOs`
4. Add validators
5. Implement service and controller

### How do I run tests?
```bash
dotnet test
```

See [TESTING.md](TESTING.md) for more details.

## Troubleshooting

### Database connection fails
- Verify PostgreSQL is running
- Check connection string in `appsettings.json`
- Ensure database exists

### Migrations fail
```bash
dotnet ef database drop --force
dotnet ef database update
```

### API returns 500 errors
- Check logs for detailed error messages
- Verify all dependencies are registered
- Ensure database is accessible

### Frontend doesn't load
- Clear browser cache
- Check browser console for errors
- Verify API is running

## Security

### Is my data secure?
CookBook Hub follows security best practices. See [SECURITY.md](SECURITY.md) for details.

### How do I report a security vulnerability?
Email security@cookbookhub.com with details. See [SECURITY.md](SECURITY.md) for the full process.

### Is authentication implemented?
Authentication is planned for v2.0. Current version focuses on core recipe management features.

## Support

### Where can I get help?
- Open an issue on GitHub
- Check existing documentation
- Join our community discussions

### How do I report a bug?
Open an issue on GitHub with:
- Description of the bug
- Steps to reproduce
- Expected vs actual behavior
- Environment details

### Can I request a feature?
Yes! Open a feature request issue on GitHub with a detailed description of the proposed feature.
