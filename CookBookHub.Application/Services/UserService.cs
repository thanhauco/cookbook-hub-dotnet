using Microsoft.EntityFrameworkCore;
using CookBookHub.Application.DTOs;
using CookBookHub.Application.Interfaces;
using CookBookHub.Domain.Entities;
using CookBookHub.Domain.Interfaces;
using CookBookHub.Infrastructure.Data;

namespace CookBookHub.Application.Services;

public class UserService : IUserService
{
    private readonly CookBookDbContext _context;
    private readonly IRepository<User> _userRepository;

    public UserService(CookBookDbContext context, IRepository<User> userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = await _context.Users
            .Include(u => u.Recipes)
            .Include(u => u.Reviews)
            .Where(u => u.IsActive)
            .ToListAsync(cancellationToken);

        return users.Select(MapToDto);
    }

    public async Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .Include(u => u.Recipes)
            .Include(u => u.Reviews)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        return user == null ? null : MapToDto(user);
    }

    public async Task<UserDto?> GetUserByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .Include(u => u.Recipes)
            .Include(u => u.Reviews)
            .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);

        return user == null ? null : MapToDto(user);
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == dto.Username || u.Email == dto.Email, cancellationToken);

        if (existingUser != null)
            throw new InvalidOperationException("Username or email already exists");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            Email = dto.Email,
            FullName = dto.FullName,
            Bio = dto.Bio,
            AvatarUrl = dto.AvatarUrl,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        await _userRepository.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return MapToDto(user);
    }

    public async Task UpdateUserAsync(Guid id, CreateUserDto dto, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {id} not found");

        user.Username = dto.Username;
        user.Email = dto.Email;
        user.FullName = dto.FullName;
        user.Bio = dto.Bio;
        user.AvatarUrl = dto.AvatarUrl;

        await _userRepository.UpdateAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {id} not found");

        user.IsActive = false;
        await _userRepository.UpdateAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private static UserDto MapToDto(User user)
    {
        return new UserDto(
            user.Id,
            user.Username,
            user.Email,
            user.FullName,
            user.Bio,
            user.AvatarUrl,
            user.Recipes.Count,
            user.Reviews.Count
        );
    }
}
