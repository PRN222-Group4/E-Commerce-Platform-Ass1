using System;

namespace E_Commerce_Platform_Ass1.Service.Services
{
    public class AuthenticatedUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}

