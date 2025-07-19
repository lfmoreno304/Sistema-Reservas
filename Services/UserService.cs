using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using ReservaInteligente.Data;
using ReservaInteligente.Models.DTOs;
using ReservaInteligente.Models.Entities;

namespace ReservaInteligente.Services;

public class UserService
{
    private readonly ApplicationDbContext _context;
    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<User?> AuthenticateUserAsync(LoginRequest loginRequest)
    {
        var user = await _context.Users.Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
        if (user == null)
            return null;
        if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
        {
            return null;
        }
        return user;
    }
    public async Task<string> RegisterUserAsync(UserRegisterDTO user)
    {
        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
        {
            return "Email already exists";
        }
        var role = await _context.Roles.FindAsync(user.RoleId);
        if (role == null)
        {
            return "Role not found";
        }

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

        var userToAdd = new User
        {
            Name = user.Name,
            Email = user.Email,
            Password = hashedPassword,
            Role = role
        };

        _context.Users.Add(userToAdd);
        await _context.SaveChangesAsync();
        return "User created successfully";
    }
    public async Task<User?> GetUserAsync(int id)
    {
      
        return await _context.Users.FindAsync(id);
    }
}
