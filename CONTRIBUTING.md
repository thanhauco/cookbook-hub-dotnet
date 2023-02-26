# Contributing to CookBook Hub

Thank you for your interest in contributing to CookBook Hub! This document provides guidelines for contributing to the project.

## Getting Started

1. Fork the repository
2. Clone your fork: `git clone https://github.com/yourusername/cookbook-hub.git`
3. Create a feature branch: `git checkout -b feature/your-feature-name`
4. Make your changes
5. Commit your changes: `git commit -m "feat: add your feature"`
6. Push to your fork: `git push origin feature/your-feature-name`
7. Create a Pull Request

## Development Setup

### Prerequisites
- .NET 9 SDK
- PostgreSQL
- Your favorite IDE (Visual Studio, VS Code, Rider)

### Running Locally
```bash
cd CookBookHub.ApiService
dotnet run
```

## Coding Standards

### C# Code Style
- Follow Microsoft's C# coding conventions
- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Keep methods focused and small

### Commit Messages
Follow the Conventional Commits specification:
- `feat:` New feature
- `fix:` Bug fix
- `docs:` Documentation changes
- `style:` Code style changes (formatting, etc.)
- `refactor:` Code refactoring
- `test:` Adding or updating tests
- `chore:` Maintenance tasks

Examples:
```
feat: add recipe search functionality
fix: resolve null reference in UserService
docs: update API documentation
```

## Pull Request Process

1. Update the README.md with details of changes if applicable
2. Update the API_DOCUMENTATION.md if you changed any endpoints
3. Ensure all tests pass
4. Request review from maintainers
5. Address any feedback from code review

## Code Review Guidelines

### For Contributors
- Keep PRs focused on a single feature or fix
- Write clear PR descriptions
- Respond to feedback promptly
- Be open to suggestions

### For Reviewers
- Be respectful and constructive
- Focus on code quality and maintainability
- Suggest improvements, don't demand them
- Approve when ready

## Testing

- Write unit tests for new features
- Ensure existing tests pass
- Aim for high code coverage
- Test edge cases

## Documentation

- Update documentation for new features
- Keep API documentation in sync with code
- Add code comments for complex logic
- Update architecture docs if needed

## Questions?

Feel free to open an issue for:
- Bug reports
- Feature requests
- Questions about the codebase
- Suggestions for improvements

## License

By contributing, you agree that your contributions will be licensed under the MIT License.
