using System;
using System.Threading.Tasks;
using BCrypt.Net;
using E_Commerce_Platform_Ass1.Data.Database.Entities;
using E_Commerce_Platform_Ass1.Data.Repositories.Interfaces;

namespace E_Commerce_Platform_Ass1.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> RegisterAsync(string name, string email, string password)
        {
            var existing = await _userRepository.GetByEmailAsync(email);
            if (existing != null)
            {
                return false;
            }

            // Get default "User" role
            var userRole = await _roleRepository.GetByNameAsync("User");
            if (userRole == null)
            {
                throw new InvalidOperationException("Default 'User' role not found. Please seed roles first.");
            }

            var user = new User
            {
                id = Guid.NewGuid(),
                name = name,
                email = email,
                password_hash = HashPassword(password),
                role_id = userRole.id,
                status = true,
                create_at = DateTime.UtcNow
            };

            await _userRepository.CreateAsync(user);
            return true;
        }

        public async Task<AuthenticatedUser?> ValidateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            if (!VerifyPassword(password, user.password_hash))
            {
                return null;
            }

            return new AuthenticatedUser
            {
                Id = user.id,
                Name = user.name,
                Email = user.email,
                Role = user.Role?.name ?? "Unknown"
            };
        }

        private static string HashPassword(string password)
        {
            // BCrypt tự sinh salt và lưu kèm trong hash
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}

