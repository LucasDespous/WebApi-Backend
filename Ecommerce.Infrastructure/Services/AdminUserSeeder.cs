using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Infrastructure.Services;

public class AdminUserSeeder
{
    private readonly EcommerceDbContext _context;
    private readonly PasswordHasher _passwordHasher;
    private readonly IConfiguration _configuration;

    public AdminUserSeeder(EcommerceDbContext context, PasswordHasher passwordHasher, IConfiguration configuration)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var email = _configuration["AdminUser:Email"]?.Trim().ToLowerInvariant();
        var password = _configuration["AdminUser:Password"];

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            return;
        }

        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        if (user is null)
        {
            user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = _configuration["AdminUser:FirstName"] ?? "Lucas",
                LastName = _configuration["AdminUser:LastName"] ?? "Despous",
                Email = email,
                PasswordHash = _passwordHasher.Hash(password),
                Role = UserRole.Admin
            };

            await _context.Users.AddAsync(user, cancellationToken);
        }
        else
        {
            user.Role = UserRole.Admin;
            user.PasswordHash = _passwordHasher.Hash(password);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
