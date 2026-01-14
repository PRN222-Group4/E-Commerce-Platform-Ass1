using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Ass1.Data.Database.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Guid RoleId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation property
        public Role Role { get; set; } = null!;
    }
}
